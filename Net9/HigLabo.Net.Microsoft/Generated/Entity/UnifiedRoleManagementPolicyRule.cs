using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/unifiedrolemanagementpolicyrule?view=graph-rest-1.0
/// </summary>
public partial class UnifiedRoleManagementPolicyRule
{
    public string? Id { get; set; }
    public UnifiedRoleManagementPolicyRuleTarget? Target { get; set; }
}
