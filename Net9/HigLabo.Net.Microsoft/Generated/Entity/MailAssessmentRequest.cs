using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/mailassessmentrequest?view=graph-rest-1.0
/// </summary>
public partial class MailAssessmentRequest
{
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

    public MailAssessmentRequestThreatCategory Category { get; set; }
    public MailAssessmentRequestThreatAssessmentContentType ContentType { get; set; }
    public IdentitySet? CreatedBy { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public MailAssessmentRequestMailDestinationRoutingReason DestinationRoutingReason { get; set; }
    public MailAssessmentRequestThreatExpectedAssessment ExpectedAssessment { get; set; }
    public string? Id { get; set; }
    public string? MessageUri { get; set; }
    public string? RecipientEmail { get; set; }
    public MailAssessmentRequestThreatAssessmentRequestSource RequestSource { get; set; }
    public MailAssessmentRequestThreatAssessmentStatus Status { get; set; }
    public ThreatAssessmentResult[]? Results { get; set; }
}
