using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Service
{
    public abstract class ServiceCommand
    {
        public DateTimeOffset? ScheduleTime { get; set; } 
        public DateTimeOffset? CommandStartTime { get; set; }
        public DateTimeOffset? CommandEndTime { get; set; }
        public abstract void Execute();
    }
}
