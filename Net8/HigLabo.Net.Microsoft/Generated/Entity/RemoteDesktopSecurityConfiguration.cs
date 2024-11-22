using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/remotedesktopsecurityconfiguration?view=graph-rest-1.0
/// </summary>
public partial class RemoteDesktopSecurityConfiguration
{
    public string? Id { get; set; }
    public bool? IsRemoteDesktopProtocolEnabled { get; set; }
    public TargetDeviceGroup[]? TargetDeviceGroups { get; set; }
}
