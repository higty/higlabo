using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/timeoff?view=graph-rest-1.0
    /// </summary>
    public partial class TimeOff
    {
        public DateTimeOffset? CreatedDateTime { get; set; }
        public TimeOffItem? DraftTimeOff { get; set; }
        public string? Id { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public TimeOffItem? SharedTimeOff { get; set; }
        public string? UserId { get; set; }
    }
}
