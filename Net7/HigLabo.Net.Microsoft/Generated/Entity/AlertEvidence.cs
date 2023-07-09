using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/security-alertevidence?view=graph-rest-1.0
    /// </summary>
    public partial class AlertEvidence
    {
        public enum AlertEvidenceSecurityEvidenceRemediationStatus
        {
            None,
            Remediated,
            Prevented,
            Blocked,
            NotFound,
            UnknownFutureValue,
        }
        public enum AlertEvidenceSecurityEvidenceVerdict
        {
            Unknown,
            Suspicious,
            Malicious,
            NoThreatsFound,
            UnknownFutureValue,
        }

        public DateTimeOffset? CreatedDateTime { get; set; }
        public AlertEvidenceSecurityEvidenceRemediationStatus RemediationStatus { get; set; }
        public string? RemediationStatusDetails { get; set; }
        public SecurityEvidenceRole[]? Roles { get; set; }
        public String[]? Tags { get; set; }
        public AlertEvidenceSecurityEvidenceVerdict Verdict { get; set; }
    }
}
