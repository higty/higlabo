using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/serviceprincipalriskdetection?view=graph-rest-1.0
    /// </summary>
    public partial class ServicePrincipalRiskDetection
    {
        public enum ServicePrincipalRiskDetectionActivityType
        {
            Signin,
            ServicePrincipal,
        }
        public enum ServicePrincipalRiskDetectionRiskDetectionTimingType
        {
            NotDefined,
            Realtime,
            NearRealtime,
            Offline,
            UnknownFutureValue,
        }
        public enum ServicePrincipalRiskDetectionRiskDetail
        {
            Hidden,
            None,
            AdminConfirmedServicePrincipalCompromised,
            AdminDismissedAllRiskForServicePrincipal,
        }
        public enum ServicePrincipalRiskDetectionRiskLevel
        {
            Hidden,
            Low,
            Medium,
            High,
            None,
        }
        public enum ServicePrincipalRiskDetectionRiskState
        {
            None,
            Dismissed,
            AtRisk,
            ConfirmedCompromised,
        }
        public enum ServicePrincipalRiskDetectionTokenIssuerType
        {
            AzureAD,
        }

        public ServicePrincipalRiskDetectionActivityType Activity { get; set; }
        public DateTimeOffset? ActivityDateTime { get; set; }
        public string? AdditionalInfo { get; set; }
        public string? AppId { get; set; }
        public string? CorrelationId { get; set; }
        public DateTimeOffset? DetectedDateTime { get; set; }
        public ServicePrincipalRiskDetectionRiskDetectionTimingType DetectionTimingType { get; set; }
        public string? Id { get; set; }
        public string? IpAddress { get; set; }
        public String[]? KeyIds { get; set; }
        public DateTimeOffset? LastUpdatedDateTime { get; set; }
        public SignInLocation? Location { get; set; }
        public string? RequestId { get; set; }
        public ServicePrincipalRiskDetectionRiskDetail RiskDetail { get; set; }
        public string? RiskEventType { get; set; }
        public ServicePrincipalRiskDetectionRiskLevel RiskLevel { get; set; }
        public ServicePrincipalRiskDetectionRiskState RiskState { get; set; }
        public string? ServicePrincipalDisplayName { get; set; }
        public string? ServicePrincipalId { get; set; }
        public string? Source { get; set; }
        public ServicePrincipalRiskDetectionTokenIssuerType TokenIssuerType { get; set; }
    }
}
