using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/security-ediscoverycase?view=graph-rest-1.0
    /// </summary>
    public partial class EdiscoveryCase
    {
        public enum EdiscoveryCaseSecurityCaseStatus
        {
            Unknown,
            Active,
            PendingDelete,
            Closing,
            Closed,
            ClosedWithError,
        }

        public IdentitySet? ClosedBy { get; set; }
        public DateTimeOffset? ClosedDateTime { get; set; }
        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? ExternalId { get; set; }
        public string? Id { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public EdiscoveryCaseSecurityCaseStatus Status { get; set; }
        public EdiscoveryCustodian[]? Custodians { get; set; }
        public EdiscoveryNoncustodialDataSource[]? NoncustodialDataSources { get; set; }
        public CaseOperation[]? Operations { get; set; }
        public EdiscoveryReviewSet[]? ReviewSets { get; set; }
        public EdiscoverySearch[]? Searches { get; set; }
        public EdiscoveryCaseSettings? Settings { get; set; }
        public EdiscoveryReviewTag[]? Tags { get; set; }
    }
}
