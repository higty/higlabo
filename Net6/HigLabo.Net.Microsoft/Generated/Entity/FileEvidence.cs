using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/security-fileevidence?view=graph-rest-1.0
    /// </summary>
    public partial class FileEvidence
    {
        public enum FileEvidenceSecurityDetectionStatus
        {
            Detected,
            Blocked,
            Prevented,
            UnknownFutureValue,
        }

        public FileEvidenceSecurityDetectionStatus DetectionStatus { get; set; }
        public FileDetails? FileDetails { get; set; }
        public string? MdeDeviceId { get; set; }
    }
}
