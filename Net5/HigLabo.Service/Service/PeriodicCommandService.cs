using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.Service
{
    public class PeriodicCommandService
    {
        private Thread _Thread = null;
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
                if (this.Available == false)
                {
                    Thread.Sleep(this.GetNextExecuteTimeSpan());
                    continue;
                }
                var now = DateTime.UtcNow;
                var scheduleTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0, DateTimeKind.Utc);
                foreach (var cm in _CommandList)
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
        }
        private TimeSpan GetNextExecuteTimeSpan()
        {
            var now = DateTime.UtcNow;
            var scheduleTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0).AddMinutes(1);
            return scheduleTime - DateTime.UtcNow;
        }

        public void AddCommand(PeriodicCommand command)
        {
            _CommandList.Add(command);
        }
        public void AddCommand(IEnumerable<PeriodicCommand> commandList)
        {
            foreach (var command in commandList)
            {
                _CommandList.Add(command);
            }
        }
    }
}
