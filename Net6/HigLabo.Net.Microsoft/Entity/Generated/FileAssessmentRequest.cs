using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/fileassessmentrequest?view=graph-rest-1.0
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

        public string ContentData { get; set; }
        public string FileName { get; set; }
        public Enum Category { get; set; }
        public Enum ContentType { get; set; }
        public IdentitySet CreatedBy { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public Enum ExpectedAssessment { get; set; }
        public string Id { get; set; }
        public Enum RequestSource { get; set; }
        public Enum Status { get; set; }
    }
}
