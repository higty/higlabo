using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/userconsentrequest?view=graph-rest-1.0
    /// </summary>
    public partial class UserConsentRequest
    {
        public string? ApprovalId { get; set; }
        public DateTimeOffset? CompletedDateTime { get; set; }
        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? CustomData { get; set; }
        public string? Id { get; set; }
        public string? Reason { get; set; }
        public string? Status { get; set; }
        public Approval? Approval { get; set; }
    }
}
