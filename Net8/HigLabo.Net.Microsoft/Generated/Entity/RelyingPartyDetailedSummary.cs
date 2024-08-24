using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/relyingpartydetailedsummary?view=graph-rest-1.0
    /// </summary>
    public partial class RelyingPartyDetailedSummary
    {
        public enum RelyingPartyDetailedSummaryMigrationStatus
        {
            Ready,
            NeedsReview,
            AdditionalStepsRequired,
            UnknownFutureValue,
            Eq,
        }

        public Int64? FailedSignInCount { get; set; }
        public string? Id { get; set; }
        public RelyingPartyDetailedSummaryMigrationStatus MigrationStatus { get; set; }
        public KeyValuePair[]? MigrationValidationDetails { get; set; }
        public string? RelyingPartyId { get; set; }
        public string? RelyingPartyName { get; set; }
        public String[]? ReplyUrls { get; set; }
        public string? ServiceId { get; set; }
        public Double? SignInSuccessRate { get; set; }
        public Int64? SuccessfulSignInCount { get; set; }
        public Int64? TotalSignInCount { get; set; }
        public Int64? UniqueUserCount { get; set; }
    }
}
