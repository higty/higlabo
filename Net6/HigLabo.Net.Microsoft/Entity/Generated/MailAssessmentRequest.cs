using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/mailassessmentrequest?view=graph-rest-1.0
    /// </summary>
    public partial class MailAssessmentRequest
    {
        public MailAssessmentRequestMailDestinationRoutingReason DestinationRoutingReason { get; set; }
        public string MessageUri { get; set; }
        public string RecipientEmail { get; set; }
        public MailAssessmentRequestThreatCategory Category { get; set; }
        public MailAssessmentRequestThreatAssessmentContentType ContentType { get; set; }
        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public MailAssessmentRequestThreatExpectedAssessment ExpectedAssessment { get; set; }
        public string Id { get; set; }
        public MailAssessmentRequestThreatAssessmentRequestSource RequestSource { get; set; }
        public MailAssessmentRequestThreatAssessmentStatus Status { get; set; }
    }
}
