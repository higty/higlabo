using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.Service
{
    public class PeriodicCommandService
    {
        private Thread _Thread = null;

        private Object _LockObject = new Object();
        private DateTime _LatestExecuteTime = DateTime.MinValue;
        private List<PeriodicCommand> _CommandList = new List<PeriodicCommand>();

        public event EventHandler<ServiceCommandEventArgs> Error;
        public String Name { get; set; }
        public Boolean IsStarted { get; set; } = false;
        public Boolean Available { get; set; } = true;
        public Int32 IntervalSeconds { get; set; } = 60;

        public PeriodicCommandService(String name)
        {
            this.Name = name;
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
            _Thread = new Thread(() => this.Start());
            _Thread.Name = String.Format("{0}({1})", nameof(PeriodicCommandService), this.Name);
            _Thread.Priority = ThreadPriority.BelowNormal;
            _Thread.IsBackground = true;
            if (setPropertyFunc != null)
            {
                setPropertyFunc(_Thread);
            }
            _Thread.Start();
            this.IsStarted = true;
        }
        private void Start()
        {

            while (true)
            {
                try
                {
                    var now = DateTime.UtcNow;
                    _LatestExecuteTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
                    if (this.Available == false)
                    {
                        Thread.Sleep(this.GetNextExecuteTimeSpan());
                        continue;
                    }
                    Trace.WriteLine(String.Format("{0} {1} started.", now.ToString("yyyy/MM/dd HH:mm:ss"), this.Name));

                    var l = new List<PeriodicCommand>();
                    lock (this._LockObject)
                    {
                        foreach (var item in _CommandList)
                        {
                            l.Add(item);
                        }
                    }
                    foreach (var cm in l)
                    {
                        try
                        {
                            if (cm.IsExecute(_LatestExecuteTime))
                            {
                                if (cm.Service != null)
                                {
                                    cm.Service.AddCommand(cm);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            this.Error?.Invoke(this, new ServiceCommandEventArgs(cm, ex));
                            Trace.WriteLine(ex.ToString());
                        }
                    }
                    Thread.Sleep(this.GetNextExecuteTimeSpan());
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                    Thread.Sleep(this.GetNextExecuteTimeSpan());
                }
            }
        }
        private TimeSpan GetNextExecuteTimeSpan()
        {
            var now = DateTime.UtcNow;
            var scheduleTime = _LatestExecuteTime.AddSeconds(this.IntervalSeconds);
            return scheduleTime - now;
        }

        public void AddCommand(PeriodicCommand command)
        {
            lock (this._LockObject)
            {
                _CommandList.Add(command);
            }
        }
        public void AddCommand(IEnumerable<PeriodicCommand> commandList)
        {
            lock (this._LockObject)
            {
                foreach (var command in commandList)
                {
                    _CommandList.Add(command);
                }
            }
        }
    }
}
