using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/unifiedroleassignment?view=graph-rest-1.0
/// </summary>
public partial class UnifiedRoleAssignment
{
    public string? AppScopeId { get; set; }
    public string? DirectoryScopeId { get; set; }
    public string? Id { get; set; }
    public string? RoleDefinitionId { get; set; }
    public string? PrincipalId { get; set; }
    public AppScope? AppScope { get; set; }
    public DirectoryObject? DirectoryScope { get; set; }
    public DirectoryObject? Principal { get; set; }
    public UnifiedRoleDefinition? RoleDefinition { get; set; }
}
