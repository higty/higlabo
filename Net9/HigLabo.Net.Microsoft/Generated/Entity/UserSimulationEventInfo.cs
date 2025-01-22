using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/usersimulationeventinfo?view=graph-rest-1.0
/// </summary>
public partial class UserSimulationEventInfo
{
    public string? Browser { get; set; }
    public DateTimeOffset? EventDateTime { get; set; }
    public string? EventName { get; set; }
    public string? IpAddress { get; set; }
    public string? OsPlatformDeviceDetails { get; set; }
}
