using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/defaultuserrolepermissions?view=graph-rest-1.0
/// </summary>
public partial class DefaultUserRolePermissions
{
    public bool? AllowedToCreateApps { get; set; }
    public bool? AllowedToCreateSecurityGroups { get; set; }
    public bool? AllowedToReadBitlockerKeysForOwnedDevice { get; set; }
    public bool? AllowedToReadOtherUsers { get; set; }
    public bool? AllowedToCreateTenants { get; set; }
    public String[]? PermissionGrantPoliciesAssigned { get; set; }
}
