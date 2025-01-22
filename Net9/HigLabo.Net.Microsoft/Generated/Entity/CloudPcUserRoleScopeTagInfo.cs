using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/cloudpcuserrolescopetaginfo?view=graph-rest-1.0
/// </summary>
public partial class CloudPcUserRoleScopeTagInfo
{
    public string? DisplayName { get; set; }
    public string? RoleScopeTagId { get; set; }
}
