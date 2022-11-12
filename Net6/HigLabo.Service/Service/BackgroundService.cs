using System;
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
        public class BackgroundServiceLog
        {
            private Object _LockObject = new Object();
            private List<ServiceCommand> _CommandList = new List<ServiceCommand>();
            internal Int64 _CommandCount = 0;
            internal Int64 _TotalExecutedTicks = 0;

            public Int64 CommandCount
            {
                get { return Interlocked.Read(ref _CommandCount); }
            }
            public Int64 ExecutedTicks
            {
                get { return Interlocked.Read(ref _TotalExecutedTicks); }
            }
            public Int64 MaxCommandCount { get; set; } = 1000;

            internal void AddCommand(ServiceCommand command)
            {
                Interlocked.Increment(ref _CommandCount);
                lock (_LockObject)
                {
                    if (_CommandList.Contains(command)) { return; }
                    _CommandList.Add(command);
                    if (_CommandList.Count > this.MaxCommandCount)
                    {
                        var length = _CommandList.Count - this.MaxCommandCount;
                        for (int i = 0; i < length; i++)
                        {
                            _CommandList.RemoveAt(0);
                        }
                    }
                }
            }
            public List<ServiceCommand> GetCommandList()
            {
                var l = new List<ServiceCommand>();
                lock (_LockObject)
                {
                    foreach (var cm in _CommandList)
                    {
                        l.Add(cm);
                    }
                }
                return l;
            }
        }
        public event EventHandler<ServiceCommandEventArgs> Executed;
        public event EventHandler<ServiceCommandEventArgs> Error;

        private Thread _Thread = null;
        private AutoResetEvent _AutoResetEvent = new AutoResetEvent(true);
        private Object _LockObject = new Object();
        private Queue<ServiceCommand> _CommandList = new ();
        private ServiceCommand _CurrentCommand = null;
        private Int64 _ExecutingCommandCount = 0;
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
        public Int32 ThreadSleepSecondsPerCommand { get; set; }
        public Int32 CommandCount
        {
            get
            {
                lock (_LockObject)
                {
                    return _CommandList.Count + (Int32)_ExecutingCommandCount;
                }
            }
        }
        public BackgroundServiceLog Log { get; set; } = new BackgroundServiceLog();

        public BackgroundService(String name, Int32 threadSleepSecondsPerCommand)
        {
            this.Name = name;
            this.ThreadSleepSecondsPerCommand = threadSleepSecondsPerCommand;
        }
        public void StartThread()
        {
            this.StartThread(thd => { });
        }
        public void StartThread(ThreadPriority priority)
        {
            this.StartThread(thd => thd.Priority = priority);
        }
        public void StartThread(Action<Thread> setPropertyFunc)
        {
            if (_Thread != null) { throw new InvalidOperationException("You can't call StartThread method twice."); }

            _Thread = new Thread(() => this.Start());
            _Thread.Name = String.Format("{0}({1})", nameof(BackgroundService), this.Name);
            _Thread.IsBackground = true;
            _Thread.Priority = ThreadPriority.BelowNormal;

            if (setPropertyFunc != null)
            {
                setPropertyFunc(_Thread);
            }
            _Thread.Start();
            _IsStarted = true;
        }
        private void Start()
        {
            var l = new List<ServiceCommand>();
            var skipCommandList = new List<ServiceCommand>();

            while (true)
            {
                if (_IsSuspend == 1)
                {
                    _AutoResetEvent.WaitOne();
                    continue;
                }

                var now = DateTimeOffset.Now;
                DateTimeOffset? minNextStartTime = null;

                l.Clear();
                skipCommandList.Clear();
                lock (_LockObject)
                {
                    while (_CommandList.TryDequeue(out var cm))
                    {
                        if (cm == null) { continue; }
                        //Not execute command until schedule time will come.
                        if (cm.ScheduleTime > now)
                        {
                            skipCommandList.Add(cm);
                            if (minNextStartTime == null || minNextStartTime > cm.ScheduleTime)
                            {
                                minNextStartTime = cm.ScheduleTime;
                            }
                            continue;
                        }
                        else
                        {
                            Interlocked.Exchange(ref _ExecutingCommandCount, l.Count);
                            l.Add(cm);
                        }
                    }
                    foreach (var cm in skipCommandList)
                    {
                        _CommandList.Enqueue(cm);
                    }
                }

                foreach (var cm in l)
                {
                    try
                    {
                        var sw = Stopwatch.StartNew();
                        cm.StartTime = DateTimeOffset.Now;
                        _CurrentCommand = cm;
                        cm.Execute();
                        cm.EndTime = DateTimeOffset.Now;
                        sw.Stop();

                        this.Log.AddCommand(cm);
                        Interlocked.Add(ref this.Log._TotalExecutedTicks, sw.ElapsedTicks);
                        this.Executed?.Invoke(this, new ServiceCommandEventArgs(cm, null));
                    }
                    catch (Exception ex)
                    {
                        cm.EndTime = DateTimeOffset.Now;
                        try
                        {
                            this.Error?.Invoke(this, new ServiceCommandEventArgs(cm, ex));
                        }
                        catch { }
                    }
                    finally
                    {
                        _CurrentCommand = null;
                    }
                    if (this.ThreadSleepSecondsPerCommand > 0)
                    {
                        Thread.Sleep(this.ThreadSleepSecondsPerCommand);
                    }
                }

                if (minNextStartTime.HasValue)
                {
                    var ts = minNextStartTime.Value - DateTimeOffset.Now;
                    if (ts.TotalMilliseconds > 0)
                    {
                        _AutoResetEvent.WaitOne((Int32)ts.TotalMilliseconds);
                    }
                    else
                    {
                        continue;
                    }
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
            _AutoResetEvent.Set();
        }
        public void AddCommand(ServiceCommand command)
        {
            lock (_LockObject)
            {
                _CommandList.Enqueue(command);
            }
            _AutoResetEvent.Set();
        }
        public void AddCommand(IEnumerable<ServiceCommand> commandList)
        {
            lock (_LockObject)
            {
                foreach (var command in commandList)
                {
                    if (command == null) { continue; }
                    _CommandList.Enqueue(command);
                }
            }
            _AutoResetEvent.Set();
        }
  
        public ServiceCommand GetCurrentCommand()
        {
            return _CurrentCommand;
        }
        public List<ServiceCommand> GetCommandList()
        {
            var l = new List<ServiceCommand>();
            lock (_LockObject)
            {
                foreach (var item in _CommandList)
                {
                    l.Add(item);
                }
            }
            return l;
        }

    }
}
