using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/cloudpcauditactor?view=graph-rest-1.0
/// </summary>
public partial class CloudPcAuditActor
{
    public string? ApplicationDisplayName { get; set; }
    public string? ApplicationId { get; set; }
    public string? IpAddress { get; set; }
    public string? RemoteTenantId { get; set; }
    public string? RemoteUserId { get; set; }
    public string? ServicePrincipalName { get; set; }
    public string? UserId { get; set; }
    public String[]? UserPermissions { get; set; }
    public string? UserPrincipalName { get; set; }
    public CloudPcUserRoleScopeTagInfo[]? UserRoleScopeTags { get; set; }
}
