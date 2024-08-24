using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/exchangeprotectionpolicy?view=graph-rest-1.0
    /// </summary>
    public partial class ExChangeProtectionPolicy
    {
        public enum ExChangeProtectionPolicyProtectionPolicyStatus
        {
            Inactive,
            ActiveWithErrors,
            Updating,
            Active,
            UnknownFutureValue,
        }

        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public IdentitySet? CreatedBy { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public ExChangeProtectionPolicy? Status { get; set; }
        public MailboxProtectionRule[]? MailboxInclusionRules { get; set; }
        public MailboxProtectionUnit[]? MailboxProtectionUnits { get; set; }
    }
}
