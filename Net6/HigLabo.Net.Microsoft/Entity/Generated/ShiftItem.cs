using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/shiftitem?view=graph-rest-1.0
    /// </summary>
    public partial class ShiftItem
    {
        public ShiftActivity[]? Activities { get; set; }
        public string? DisplayName { get; set; }
        public DateTimeOffset? EndDateTime { get; set; }
        public string? Notes { get; set; }
        public DateTimeOffset? StartDateTime { get; set; }
        public ScheduleEntityTheme? Theme { get; set; }
    }
}
