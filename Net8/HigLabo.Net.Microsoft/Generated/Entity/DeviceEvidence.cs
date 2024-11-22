using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/security-deviceevidence?view=graph-rest-1.0
/// </summary>
public partial class DeviceEvidence
{
    public enum DeviceEvidenceSecurityDefenderAvStatus
    {
        NotReporting,
        Disabled,
        NotUpdated,
        Updated,
        Unknown,
        NotSupported,
        UnknownFutureValue,
    }
    public enum DeviceEvidenceSecurityDeviceHealthStatus
    {
        Active,
        Inactive,
        ImpairedCommunication,
        NoSensorData,
        NoSensorDataImpairedCommunication,
        Unknown,
        UnknownFutureValue,
    }
    public enum DeviceEvidenceSecurityOnboardingStatus
    {
        InsufficientInfo,
        Onboarded,
        CanBeOnboarded,
        Unsupported,
        UnknownFutureValue,
    }
    public enum DeviceEvidenceSecurityDeviceRiskScore
    {
        None,
        Informational,
        Low,
        Medium,
        High,
        UnknownFutureValue,
    }

    public string? AzureAdDeviceId { get; set; }
    public DeviceEvidenceSecurityDefenderAvStatus DefenderAvStatus { get; set; }
    public string? DeviceDnsName { get; set; }
    public DateTimeOffset? FirstSeenDateTime { get; set; }
    public DeviceEvidenceSecurityDeviceHealthStatus HealthStatus { get; set; }
    public LoggedOnUser[]? LoggedOnUsers { get; set; }
    public string? MdeDeviceId { get; set; }
    public DeviceEvidenceSecurityOnboardingStatus OnboardingStatus { get; set; }
    public Int64? OsBuild { get; set; }
    public string? OsPlatform { get; set; }
    public Int32? RbacGroupId { get; set; }
    public string? RbacGroupName { get; set; }
    public DeviceEvidenceSecurityDeviceRiskScore RiskScore { get; set; }
    public string? Version { get; set; }
    public VmMetadata? VmMetadata { get; set; }
}
