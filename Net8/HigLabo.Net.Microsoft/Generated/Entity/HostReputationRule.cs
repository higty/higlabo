using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/security-hostreputationrule?view=graph-rest-1.0
/// </summary>
public partial class HostReputationRule
{
    public enum HostReputationRuleSecurityHostReputationRuleSeverity
    {
        Unknown,
        Low,
        Medium,
        High,
        UnknownFutureValue,
    }

    public string? Description { get; set; }
    public string? RelatedDetailsUrl { get; set; }
    public string? Name { get; set; }
    public HostReputationRuleSecurityHostReputationRuleSeverity Severity { get; set; }
}
