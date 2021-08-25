using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private List<PeriodicCommand> _CommandList = new List<PeriodicCommand>();

        public String Name { get; set; }

        public Boolean Available { get; set; } = true;

        public PeriodicCommandService(String name)
        {
            this.Name = name;
        }
        public void StartThread()
        {
            _Thread = new Thread(() => this.Start());
            _Thread.Name = String.Format("{0}({1})", nameof(PeriodicCommandService), this.Name);
            _Thread.Priority = ThreadPriority.BelowNormal;
            _Thread.IsBackground = true;
            _Thread.Start();
        }
        private void Start()
        {
            while (true)
            {
                try
                {
                    if (this.Available == false)
                    {
                        Thread.Sleep(this.GetNextExecuteTimeSpan());
                        continue;
                    }
                    var now = DateTime.UtcNow;
                    Trace.WriteLine(String.Format("{0} {1} started.", now.ToString("yyyy/MM/dd HH:mm:ss"), this.Name));
                    var scheduleTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0, DateTimeKind.Utc);

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
                            if (cm.IsExecute(scheduleTime))
                            {
                                if (cm.Service != null)
                                {
                                    cm.Service.AddCommand(cm);
                                }
                            }
                        }
                        catch { }
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
            var scheduleTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0).AddMinutes(1);
            return scheduleTime - DateTime.UtcNow;
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
