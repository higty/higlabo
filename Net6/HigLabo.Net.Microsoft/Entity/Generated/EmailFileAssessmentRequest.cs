using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/emailfileassessmentrequest?view=graph-rest-1.0
    /// </summary>
    public partial class EmailFileAssessmentRequest
    {
        public enum EmailFileAssessmentRequestMailDestinationRoutingReason
        {
            None,
            MailFlowRule,
            SafeSender,
            BlockedSender,
            AdvancedSpamFiltering,
            DomainAllowList,
            DomainBlockList,
            NotInAddressBook,
            FirstTimeSender,
            AutoPurgeToInbox,
            AutoPurgeToJunk,
            AutoPurgeToDeleted,
            Outbound,
            NotJunk,
            Junk,
        }
        public enum EmailFileAssessmentRequestThreatCategory
        {
            Spam,
            Phishing,
            Malware,
        }
        public enum EmailFileAssessmentRequestThreatAssessmentContentType
        {
            Mail,
            Url,
            File,
        }
        public enum EmailFileAssessmentRequestThreatExpectedAssessment
        {
            Block,
            Unblock,
        }
        public enum EmailFileAssessmentRequestThreatAssessmentRequestSource
        {
            Administrator,
        }
        public enum EmailFileAssessmentRequestThreatAssessmentStatus
        {
            Pending,
            Completed,
        }

        public string? ContentData { get; set; }
        public EmailFileAssessmentRequestMailDestinationRoutingReason DestinationRoutingReason { get; set; }
        public string? RecipientEmail { get; set; }
        public EmailFileAssessmentRequestThreatCategory Category { get; set; }
        public EmailFileAssessmentRequestThreatAssessmentContentType ContentType { get; set; }
        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public EmailFileAssessmentRequestThreatExpectedAssessment ExpectedAssessment { get; set; }
        public string? Id { get; set; }
        public EmailFileAssessmentRequestThreatAssessmentRequestSource RequestSource { get; set; }
        public EmailFileAssessmentRequestThreatAssessmentStatus Status { get; set; }
        public ThreatAssessmentResult[]? Results { get; set; }
    }
}
