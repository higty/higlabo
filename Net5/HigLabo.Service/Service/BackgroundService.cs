using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace HigLabo.Service
{
    public enum BackgroundCommandServiceState
    {
        Ready,
        Executing,
        Suspend,
    }
    public class BackgroundService
    {
        public class ServiceCommandExecuteResult
        {
            public String Name { get; set; }
            public DateTimeOffset StartTime { get; set; }
            public TimeSpan Duration { get; set; }

            public ServiceCommandExecuteResult(ServiceCommand command)
            {
                this.Name = command.GetType().Name;
                this.StartTime = command.CommandStartTime.Value;
                this.Duration = command.CommandEndTime.Value - command.CommandStartTime.Value;
            }
            public override string ToString()
            {
                return String.Format("{0} (StartTime={1}, Duration={2}ms)"
                    , this.Name, this.StartTime.ToString("MM/dd HH:mm:ss.fffffff")
                    , this.Duration.TotalMilliseconds);
            }
        }

        public event EventHandler<ServiceCommandEventArgs> Executed;
        public event EventHandler<ServiceCommandEventArgs> Error;

        private Thread _Thread = null;
        private AutoResetEvent _AutoResetEvent = new AutoResetEvent(true);
        private Int32 _ThreadSleepSecondsPerCommand = 0;
        private ConcurrentQueue<ServiceCommand> _CommandList = new ConcurrentQueue<ServiceCommand>();
        private ServiceCommand _CurrentCommand = null;
        private List<ServiceCommand> _PreviousCommandList = new List<ServiceCommand>();
        private DateTimeOffset _PreviousResetTime = DateTimeOffset.Now;
        private Int64 _ExecutedCommandCount = 0;
        private Int64 _ExecutedSeconds = 0;
        private Boolean _IsStarted = false;
        private Int64 _IsSuspend = 0;

        public String Name { get; private set; }
        public BackgroundCommandServiceState State
        {
            get
            {
                if (_IsStarted)
                {
                    if (_IsSuspend == 1) { return BackgroundCommandServiceState.Suspend; }
                    else { return BackgroundCommandServiceState.Executing; }
                }
                else
                {
                    return BackgroundCommandServiceState.Ready;
                }
            }
        }
        public Int64 ExecutedCommandCount
        {
            get { return Interlocked.Read(ref _ExecutedCommandCount); }
        }
        public Int64 ExecutedSeconds
        {
            get { return Interlocked.Read(ref _ExecutedSeconds); }
        }
        public Int32 CommandCount
        {
            get { return _CommandList.Count; }
        }

        public BackgroundService(String name, Int32 threadSleepSecondsPerCommand)
        {
            this.Name = name;
            _ThreadSleepSecondsPerCommand = threadSleepSecondsPerCommand;
        }
        public void StartThread()
        {
            if (_Thread != null) { throw new InvalidOperationException(); }

            _Thread = new Thread(() => this.Start());
            _Thread.Name = String.Format("{0}({1})", nameof(BackgroundService), this.Name);
            _Thread.IsBackground = true;
            _Thread.Priority = ThreadPriority.BelowNormal;
            _Thread.Start();
            _IsStarted = true;
        }
        private void Start()
        {
            while (true)
            {
                var l = new List<ServiceCommand>();
                while (_CommandList.TryDequeue(out var cm))
                {
                    if (cm == null) { continue; }
                    l.Add(cm);
                }

                var now = DateTimeOffset.Now;
                DateTimeOffset? minNextStartTime = null;
                foreach (var cm in l)
                {
                    if (cm.ScheduleTime > now)
                    {
                        _CommandList.Enqueue(cm);
                        if (minNextStartTime == null || minNextStartTime > cm.ScheduleTime)
                        {
                            minNextStartTime = cm.ScheduleTime;
                        }
                    }
                    try
                    {
                        var sw = Stopwatch.StartNew();
                        cm.CommandStartTime = DateTimeOffset.Now;
                        _CurrentCommand = cm;
                        cm.Execute();
                        cm.CommandEndTime = DateTimeOffset.Now;
                        sw.Stop();

                        Interlocked.Increment(ref _ExecutedCommandCount);
                        Interlocked.Add(ref _ExecutedSeconds, sw.ElapsedTicks / TimeSpan.TicksPerSecond);
                        if (_PreviousResetTime.Day != now.Day)
                        {
                            Interlocked.Exchange(ref _ExecutedCommandCount, 0);
                            Interlocked.Exchange(ref _ExecutedSeconds, 0);
                        }
                        _PreviousResetTime = now;
                        this.Executed?.Invoke(this, new ServiceCommandEventArgs(cm, null));
                    }
                    catch (Exception ex)
                    {
                        cm.CommandEndTime = DateTimeOffset.Now;
                        this.Error?.Invoke(this, new ServiceCommandEventArgs(cm, ex));
                    }
                    finally
                    {
                        _CurrentCommand = null;
                    }
                    if (_ThreadSleepSecondsPerCommand > 0)
                    {
                        Thread.Sleep(_ThreadSleepSecondsPerCommand);
                    }
                }
                _PreviousCommandList = l;

                if (minNextStartTime.HasValue)
                {
                    var ts = minNextStartTime.Value - DateTimeOffset.Now;
                    _AutoResetEvent.WaitOne((Int32)ts.TotalMilliseconds);
                }
                else
                {
                    _AutoResetEvent.WaitOne();
                }
            }
        }
        public void Suspend()
        {
            Interlocked.Exchange(ref _IsSuspend, 1);
        }
        public void Resume()
        {
            Interlocked.Exchange(ref _IsSuspend, 0);
        }
        public void AddCommand(ServiceCommand command)
        {
            if (_Thread == null) { return; }
            if (_IsSuspend == 1) { return; }
            _CommandList.Enqueue(command);
            _AutoResetEvent.Set();
        }
        public void AddCommand(IEnumerable<ServiceCommand> commandList)
        {
            if (_Thread == null) { return; }
            if (_IsSuspend == 1) { return; }
            foreach (var command in commandList)
            {
                _CommandList.Enqueue(command);
            }
            _AutoResetEvent.Set();
        }
        public (String Name, DateTimeOffset? StartTime) GetCurrentCommandData()
        {
            var cm = _CurrentCommand;
            if (cm == null) { return ("", null); }
            return (cm.GetType().Name, cm.CommandStartTime);
        }
        public List<String> GetCommandNameList()
        {
            var l = new List<String>();
            foreach (var item in _CommandList)
            {
                l.Add(item.GetType().Name);
            }
            return l;
        }
        public List<ServiceCommandExecuteResult> GetPreviousCommandList()
        {
            var l = new List<ServiceCommandExecuteResult>();
            var commandList = _PreviousCommandList;
            foreach (var cm in commandList)
            {
                l.Add(new ServiceCommandExecuteResult(cm));
            }
            return l;
        }
    }
}
