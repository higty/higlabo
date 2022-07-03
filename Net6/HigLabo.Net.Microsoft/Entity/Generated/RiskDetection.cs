using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/riskdetection?view=graph-rest-1.0
    /// </summary>
    public partial class RiskDetection
    {
        public RiskDetectionActivityType Activity { get; set; }
        public DateTimeOffset ActivityDateTime { get; set; }
        public string AdditionalInfo { get; set; }
        public string CorrelationId { get; set; }
        public DateTimeOffset DetectedDateTime { get; set; }
        public RiskDetectionRiskDetectionTimingType DetectionTimingType { get; set; }
        public string Id { get; set; }
        public string IpAddress { get; set; }
        public DateTimeOffset LastUpdatedDateTime { get; set; }
        public SignInLocation? Location { get; set; }
        public string RequestId { get; set; }
        public RiskDetectionRiskDetail RiskDetail { get; set; }
        public string RiskEventType { get; set; }
        public RiskDetectionRiskLevel RiskLevel { get; set; }
        public RiskDetectionRiskState RiskState { get; set; }
        public string Source { get; set; }
        public RiskDetectionTokenIssuerType TokenIssuerType { get; set; }
        public string UserDisplayName { get; set; }
        public string UserId { get; set; }
        public string UserPrincipalName { get; set; }
    }
}
