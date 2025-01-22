using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/oauth2permissiongrant?view=graph-rest-1.0
/// </summary>
public partial class OAuth2PermissionGrant
{
    public string? ClientId { get; set; }
    public string? ConsentType { get; set; }
    public string? Id { get; set; }
    public string? PrincipalId { get; set; }
    public string? ResourceId { get; set; }
    public string? Scope { get; set; }
}
