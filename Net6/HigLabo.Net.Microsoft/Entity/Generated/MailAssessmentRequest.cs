using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/mailassessmentrequest?view=graph-rest-1.0
    /// </summary>
    public partial class MailAssessmentRequest
    {
        public enum MailAssessmentRequestMailDestinationRoutingReason
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
        public enum MailAssessmentRequestThreatCategory
        {
            Spam,
            Phishing,
            Malware,
        }
        public enum MailAssessmentRequestThreatAssessmentContentType
        {
            Mail,
            Url,
            File,
        }
        public enum MailAssessmentRequestThreatExpectedAssessment
        {
            Block,
            Unblock,
        }
        public enum MailAssessmentRequestThreatAssessmentRequestSource
        {
            Administrator,
        }
        public enum MailAssessmentRequestThreatAssessmentStatus
        {
            Pending,
            Completed,
        }

        public Enum DestinationRoutingReason { get; set; }
        public string MessageUri { get; set; }
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
