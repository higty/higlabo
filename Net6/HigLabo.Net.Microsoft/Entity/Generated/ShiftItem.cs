using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/shiftitem?view=graph-rest-1.0
    /// </summary>
    public partial class ShiftItem
    {
        public String? Notes { get; set; }
        public String? DisplayName { get; set; }
        public DateTimeOffset StartDateTime { get; set; }
        public DateTimeOffset EndDateTime { get; set; }
        public ScheduleEntityTheme? Theme { get; set; }
        public ShiftActivity[] Activities { get; set; }
    }
}
