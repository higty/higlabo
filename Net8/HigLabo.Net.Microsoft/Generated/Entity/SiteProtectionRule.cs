using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/siteprotectionrule?view=graph-rest-1.0
    /// </summary>
    public partial class SiteProtectionRule
    {
        public enum SiteProtectionRuleProtectionRuleStatus
        {
            Draft,
            Active,
            Completed,
            CompletedWithErrors,
            UnknownFutureValue,
        }

        public string? Id { get; set; }
        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public PublicError? Error { get; set; }
        public bool? IsAutoApplyEnabled { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string? SiteExpression { get; set; }
        public SiteProtectionRule? Status { get; set; }
    }
}
