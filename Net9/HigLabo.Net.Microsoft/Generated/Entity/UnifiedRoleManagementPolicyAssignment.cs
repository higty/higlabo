using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/unifiedrolemanagementpolicyassignment?view=graph-rest-1.0
/// </summary>
public partial class UnifiedRoleManagementPolicyAssignment
{
    public string? Id { get; set; }
    public string? PolicyId { get; set; }
    public string? RoleDefinitionId { get; set; }
    public string? ScopeId { get; set; }
    public string? ScopeType { get; set; }
    public UnifiedRoleManagementPolicy? Policy { get; set; }
}
