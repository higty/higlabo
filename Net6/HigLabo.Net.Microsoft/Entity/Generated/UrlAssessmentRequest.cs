using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/urlassessmentrequest?view=graph-rest-1.0
    /// </summary>
    public partial class UrlAssessmentRequest
    {
        public enum UrlAssessmentRequestThreatCategory
        {
            Spam,
            Phishing,
            Malware,
        }
        public enum UrlAssessmentRequestThreatAssessmentContentType
        {
            Mail,
            Url,
            File,
        }
        public enum UrlAssessmentRequestThreatExpectedAssessment
        {
            Block,
            Unblock,
        }
        public enum UrlAssessmentRequestThreatAssessmentRequestSource
        {
            Administrator,
        }
        public enum UrlAssessmentRequestThreatAssessmentStatus
        {
            Pending,
            Completed,
        }

        public string? Url { get; set; }
        public UrlAssessmentRequestThreatCategory Category { get; set; }
        public UrlAssessmentRequestThreatAssessmentContentType ContentType { get; set; }
        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public UrlAssessmentRequestThreatExpectedAssessment ExpectedAssessment { get; set; }
        public string? Id { get; set; }
        public UrlAssessmentRequestThreatAssessmentRequestSource RequestSource { get; set; }
        public UrlAssessmentRequestThreatAssessmentStatus Status { get; set; }
        public ThreatAssessmentResult[]? Results { get; set; }
    }
}
