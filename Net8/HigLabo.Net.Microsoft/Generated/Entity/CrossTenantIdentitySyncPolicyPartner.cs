using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/crosstenantidentitysyncpolicypartner?view=graph-rest-1.0
/// </summary>
public partial class CrossTenantIdentitySyncPolicyPartner
{
    public string? DisplayName { get; set; }
    public string? TenantId { get; set; }
    public CrossTenantUserSyncInbound? UserSyncInbound { get; set; }
}
