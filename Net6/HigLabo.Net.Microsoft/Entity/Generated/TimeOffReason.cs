using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/timeoffreason?view=graph-rest-1.0
    /// </summary>
    public partial class TimeOffReason
    {
        public String? Id { get; set; }
        public String? DisplayName { get; set; }
        public TimeOffReasonIconType? IconType { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public DateTimeOffset LastModifiedDateTime { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
    }
}
