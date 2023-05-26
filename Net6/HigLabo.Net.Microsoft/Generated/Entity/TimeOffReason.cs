using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/timeoffreason?view=graph-rest-1.0
    /// </summary>
    public partial class TimeOffReason
    {
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public TimeOffReasonIconType? IconType { get; set; }
        public string? Id { get; set; }
        public bool? IsActive { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
    }
}
