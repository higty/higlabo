using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/scheduleitem?view=graph-rest-1.0
    /// </summary>
    public partial class ScheduleItem
    {
        public enum ScheduleItemFreeBusyStatus
        {
            Free,
            Tentative,
            Busy,
            Oof,
            WorkingElsewhere,
            Unknown,
        }

        public DateTimeTimeZone? End { get; set; }
        public bool? IsPrivate { get; set; }
        public string? Location { get; set; }
        public DateTimeTimeZone? Start { get; set; }
        public ScheduleItemFreeBusyStatus Status { get; set; }
        public string? Subject { get; set; }
    }
}
