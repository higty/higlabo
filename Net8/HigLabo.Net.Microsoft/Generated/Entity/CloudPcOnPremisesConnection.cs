using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/cloudpconpremisesconnection?view=graph-rest-1.0
/// </summary>
public partial class CloudPcOnPremisesConnection
{
    public enum CloudPcOnPremisesConnectionCloudPcOnPremisesConnectionStatus
    {
        Passed,
        Pending,
        Running,
        Failed,
        Warning,
        Informational,
    }

    public string? AdDomainName { get; set; }
    public string? AdDomainPassword { get; set; }
    public string? AdDomainUsername { get; set; }
    public string? AlternateResourceUrl { get; set; }
    public CloudPcOnPremisesConnectionType? ConnectionType { get; set; }
    public string? DisplayName { get; set; }
    public CloudPcOnPremisesConnectionCloudPcOnPremisesConnectionStatus HealthCheckStatus { get; set; }
    public CloudPcOnPremisesConnectionStatusDetail? HealthCheckStatusDetail { get; set; }
    public string? Id { get; set; }
    public bool? InUse { get; set; }
    public string? OrganizationalUnit { get; set; }
    public string? ResourceGroupId { get; set; }
    public string? SubnetId { get; set; }
    public string? SubscriptionId { get; set; }
    public string? SubscriptionName { get; set; }
    public string? VirtualNetworkId { get; set; }
    public string? VirtualNetworkLocation { get; set; }
}
