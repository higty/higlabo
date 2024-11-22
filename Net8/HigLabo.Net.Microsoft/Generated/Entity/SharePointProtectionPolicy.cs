using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/sharepointprotectionpolicy?view=graph-rest-1.0
/// </summary>
public partial class SharePointProtectionPolicy
{
    public enum SharePointProtectionPolicyProtectionPolicyStatus
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
    public RetentionSetting[]? RetentionSettings { get; set; }
    public SharePointProtectionPolicy? Status { get; set; }
    public SiteProtectionRule[]? SiteInclusionRules { get; set; }
    public SiteProtectionUnit[]? SiteProtectionUnits { get; set; }
}
