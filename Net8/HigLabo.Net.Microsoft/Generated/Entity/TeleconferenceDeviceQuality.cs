using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/teleconferencedevicequality?view=graph-rest-1.0
/// </summary>
public partial class TeleconferenceDeviceQuality
{
    public Guid? CallChainId { get; set; }
    public string? CloudServiceDeploymentEnvironment { get; set; }
    public string? CloudServiceDeploymentId { get; set; }
    public string? CloudServiceInstanceName { get; set; }
    public string? CloudServiceName { get; set; }
    public string? DeviceDescription { get; set; }
    public string? DeviceName { get; set; }
    public Guid? MediaLegId { get; set; }
    public TeleconferenceDeviceMediaQuality[]? MediaQualityList { get; set; }
    public Guid? ParticipantId { get; set; }
}
