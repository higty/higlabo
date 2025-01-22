using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/cloudpcsourcedeviceimage?view=graph-rest-1.0
/// </summary>
public partial class CloudPcSourceDeviceImage
{
    public string? DisplayName { get; set; }
    public string? ResourceId { get; set; }
    public string? SubscriptionDisplayName { get; set; }
    public string? SubscriptionId { get; set; }
}
