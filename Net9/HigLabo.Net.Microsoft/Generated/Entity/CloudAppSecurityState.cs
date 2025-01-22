using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/cloudappsecuritystate?view=graph-rest-1.0
/// </summary>
public partial class CloudAppSecurityState
{
    public string? DestinationServiceIp { get; set; }
    public string? DestinationServiceName { get; set; }
    public string? RiskScore { get; set; }
}
