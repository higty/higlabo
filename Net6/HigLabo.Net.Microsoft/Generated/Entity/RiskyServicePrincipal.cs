using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/riskyserviceprincipal?view=graph-rest-1.0
    /// </summary>
    public partial class RiskyServicePrincipal
    {
        public enum RiskyServicePrincipalRiskDetail
        {
            Hidden,
            None,
            UnknownFutureValue,
            AdminConfirmedServicePrincipalCompromised,
            AdminDismissedAllRiskForServicePrincipal,
        }
        public enum RiskyServicePrincipalRiskLevel
        {
            Low,
            Medium,
            High,
            Hidden,
            None,
            UnknownFutureValue,
            Eq,
        }
        public enum RiskyServicePrincipalRiskState
        {
            None,
            ConfirmedSafe,
            Remediated,
            Dismissed,
            AtRisk,
            ConfirmedCompromised,
            UnknownFutureValue,
        }

        public string? AppId { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public bool? IsEnabled { get; set; }
        public bool? IsProcessing { get; set; }
        public RiskyServicePrincipalRiskDetail RiskDetail { get; set; }
        public DateTimeOffset? RiskLastUpdatedDateTime { get; set; }
        public RiskyServicePrincipalRiskLevel RiskLevel { get; set; }
        public RiskyServicePrincipalRiskState RiskState { get; set; }
        public string? ServicePrincipalType { get; set; }
        public RiskyServicePrincipalHistoryItem[]? History { get; set; }
    }
}
