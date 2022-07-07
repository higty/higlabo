using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/shiftactivity?view=graph-rest-1.0
    /// </summary>
    public partial class ShiftActivity
    {
        public bool? IsPaid { get; set; }
        public DateTimeOffset? StartDateTime { get; set; }
        public DateTimeOffset? EndDateTime { get; set; }
        public string? Code { get; set; }
        public string? DisplayName { get; set; }
    }
}
