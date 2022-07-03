using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/threatassessmentrequest?view=graph-rest-1.0
    /// </summary>
    public partial class ThreatAssessmentRequest
    {
        public ThreatAssessmentRequestThreatCategory Category { get; set; }
        public ThreatAssessmentRequestThreatAssessmentContentType ContentType { get; set; }
        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public ThreatAssessmentRequestThreatExpectedAssessment ExpectedAssessment { get; set; }
        public string Id { get; set; }
        public ThreatAssessmentRequestThreatAssessmentRequestSource RequestSource { get; set; }
        public ThreatAssessmentRequestThreatAssessmentStatus Status { get; set; }
    }
}
