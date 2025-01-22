using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/customextensioncalloutinstance?view=graph-rest-1.0
/// </summary>
public partial class CustomExtensionCalloutInstance
{
    public enum CustomExtensionCalloutInstanceCustomExtensionCalloutInstanceStatus
    {
        CalloutSent,
        CallbackReceived,
        CalloutFailed,
        CallbackTimedOut,
        WaitingForCallback,
        UnknownFutureValue,
    }

    public string? CustomExtensionId { get; set; }
    public string? Detail { get; set; }
    public string? ExternalCorrelationId { get; set; }
    public string? Id { get; set; }
    public CustomExtensionCalloutInstanceCustomExtensionCalloutInstanceStatus Status { get; set; }
}
