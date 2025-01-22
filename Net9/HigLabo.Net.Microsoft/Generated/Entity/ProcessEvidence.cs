using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/security-processevidence?view=graph-rest-1.0
/// </summary>
public partial class ProcessEvidence
{
    public enum ProcessEvidenceSecurityDetectionStatus
    {
        Detected,
        Blocked,
        Prevented,
        UnknownFutureValue,
    }

    public ProcessEvidenceSecurityDetectionStatus DetectionStatus { get; set; }
    public FileDetails? ImageFile { get; set; }
    public string? MdeDeviceId { get; set; }
    public DateTimeOffset? ParentProcessCreationDateTime { get; set; }
    public Int64? ParentProcessId { get; set; }
    public FileDetails? ParentProcessImageFile { get; set; }
    public string? ProcessCommandLine { get; set; }
    public DateTimeOffset? ProcessCreationDateTime { get; set; }
    public Int64? ProcessId { get; set; }
    public UserAccount? UserAccount { get; set; }
}
