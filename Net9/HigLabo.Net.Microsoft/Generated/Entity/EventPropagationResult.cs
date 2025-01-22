using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/security-eventpropagationresult?view=graph-rest-1.0
/// </summary>
public partial class EventPropagationResult
{
    public enum EventPropagationResultSecurityEventPropagationStatus
    {
        None,
        InProcessing,
        Failed,
        Success,
        UnknownFutureValue,
    }

    public EventPropagationResultSecurityEventPropagationStatus Status { get; set; }
    public string? StatusInformation { get; set; }
    public string? ServiceName { get; set; }
    public string? Location { get; set; }
}
