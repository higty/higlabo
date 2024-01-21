using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Web
{
    public class SelectedTimeDuration
    {
        public TimeOnly? StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }

        public SelectedTimeDuration() { }
        public SelectedTimeDuration(TimeOnly? startTime, TimeOnly? endTime)
        {
            this.StartTime = startTime; 
            this.EndTime = endTime;
        }
    }
}
