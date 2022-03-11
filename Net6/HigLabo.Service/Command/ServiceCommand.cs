using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Service
{
    public abstract class ServiceCommand
    {
        public String Title { get; set; } = "";
        public DateTimeOffset? ScheduleTime { get; set; } 
        public DateTimeOffset? StartTime { get; set; }
        public DateTimeOffset? EndTime { get; set; }
        public TimeSpan? Duration
        {
            get { return this.EndTime - this.StartTime; }
        }

        public ServiceCommand()
        {
            this.Title = this.GetType().Name;
        }
        public ServiceCommand(String title)
        {
            this.Title = title;
        }
        public abstract void Execute();
        public override string ToString()
        {
            var ts = this.EndTime - this.StartTime;
            var sb = new StringBuilder();
            if (String.IsNullOrEmpty(this.Title))
            {
                sb.Append(this.Title).Append(" ");
            }
            if (this.StartTime.HasValue)
            {
                sb.Append("StartTime=");
                sb.Append(this.StartTime.Value.ToString("MM/dd HH:mm:ss.fffffff"));
                sb.Append(" ");
            }
            if (ts.HasValue)
            {
                sb.AppendFormat("Duration={0}ms", ts.Value.TotalMilliseconds.ToString());
            }
            return sb.ToString();
        }
    }
}
