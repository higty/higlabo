using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/cloudpconpremisesconnectionhealthcheck?view=graph-rest-1.0
/// </summary>
public partial class CloudPcOnPremisesConnectionHealthCheck
{
    public enum CloudPcOnPremisesConnectionHealthCheckCloudPcOnPremisesConnectionStatus
    {
        Pending,
        Running,
        Passed,
        Failed,
        Warning,
        Informational,
        UnknownFutureValue,
    }

    public string? AdditionalDetail { get; set; }
    public string? CorrelationId { get; set; }
    public string? DisplayName { get; set; }
    public DateTimeOffset? EndDateTime { get; set; }
    public CloudPcOnPremisesConnectionHealthCheckErrorType? ErrorType { get; set; }
    public string? RecommendedAction { get; set; }
    public DateTimeOffset? StartDateTime { get; set; }
    public CloudPcOnPremisesConnection? Status { get; set; }
}
