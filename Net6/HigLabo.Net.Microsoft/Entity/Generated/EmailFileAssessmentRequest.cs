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

        public string ContentData { get; set; }
        public Enum DestinationRoutingReason { get; set; }
        public string RecipientEmail { get; set; }
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
