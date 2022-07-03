using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/timeoffitem?view=graph-rest-1.0
    /// </summary>
    public partial class TimeOffItem
    {
        public String? TimeOffReasonId { get; set; }
        public DateTimeOffset StartDateTime { get; set; }
        public DateTimeOffset EndDateTime { get; set; }
        public ScheduleEntityTheme? Theme { get; set; }
    }
}
