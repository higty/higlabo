using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/riskserviceprincipalactivity?view=graph-rest-1.0
    /// </summary>
    public partial class RiskServicePrincipalActivity
    {
        public enum RiskServicePrincipalActivityRiskDetail
        {
            Hidden,
            None,
            AdminConfirmedServicePrincipalCompromised,
            AdminDismissedAllRiskForServicePrincipal,
        }

        public RiskServicePrincipalActivityRiskDetail Detail { get; set; }
        public String[]? RiskEventType { get; set; }
    }
}
