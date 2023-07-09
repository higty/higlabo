using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/timeoffitem?view=graph-rest-1.0
    /// </summary>
    public partial class TimeOffItem
    {
        public DateTimeOffset? EndDateTime { get; set; }
        public DateTimeOffset? StartDateTime { get; set; }
        public ScheduleEntityTheme? Theme { get; set; }
        public string? TimeOffReasonId { get; set; }
    }
}
