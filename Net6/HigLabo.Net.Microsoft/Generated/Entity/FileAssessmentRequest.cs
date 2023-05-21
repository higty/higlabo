using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/fileassessmentrequest?view=graph-rest-1.0
    /// </summary>
    public partial class FileAssessmentRequest
    {
        public enum FileAssessmentRequestThreatCategory
        {
            Spam,
            Phishing,
            Malware,
        }
        public enum FileAssessmentRequestThreatAssessmentContentType
        {
            Mail,
            Url,
            File,
        }
        public enum FileAssessmentRequestThreatExpectedAssessment
        {
            Block,
            Unblock,
        }
        public enum FileAssessmentRequestThreatAssessmentRequestSource
        {
            Administrator,
        }
        public enum FileAssessmentRequestThreatAssessmentStatus
        {
            Pending,
            Completed,
        }

        public FileAssessmentRequestThreatCategory Category { get; set; }
        public string? ContentData { get; set; }
        public FileAssessmentRequestThreatAssessmentContentType ContentType { get; set; }
        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public FileAssessmentRequestThreatExpectedAssessment ExpectedAssessment { get; set; }
        public string? FileName { get; set; }
        public string? Id { get; set; }
        public FileAssessmentRequestThreatAssessmentRequestSource RequestSource { get; set; }
        public FileAssessmentRequestThreatAssessmentStatus Status { get; set; }
        public ThreatAssessmentResult[]? Results { get; set; }
    }
}
