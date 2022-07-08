using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/scheduleinformation?view=graph-rest-1.0
    /// </summary>
    public partial class ScheduleInformation
    {
        public string? AvailabilityView { get; set; }
        public FreeBusyError? Error { get; set; }
        public string? ScheduleId { get; set; }
        public ScheduleItem[]? ScheduleItems { get; set; }
        public WorkingHours? WorkingHours { get; set; }
    }
}
