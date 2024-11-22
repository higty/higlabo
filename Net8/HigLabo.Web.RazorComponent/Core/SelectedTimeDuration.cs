using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Web;

public class SelectedTimeDuration
{
    public TimeSpan? StartTime { get; set; }
    public TimeSpan? EndTime { get; set; }

    public SelectedTimeDuration() { }
    public SelectedTimeDuration(TimeSpan? startTime, TimeSpan? endTime)
    {
        this.StartTime = startTime; 
        this.EndTime = endTime;
    }
}
