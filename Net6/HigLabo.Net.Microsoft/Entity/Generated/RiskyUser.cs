using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/riskyuser?view=graph-rest-1.0
    /// </summary>
    public partial class RiskyUser
    {
        public string Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsProcessing { get; set; }
        public RiskyUserRiskDetail RiskDetail { get; set; }
        public DateTimeOffset RiskLastUpdatedDateTime { get; set; }
        public RiskyUserRiskLevel RiskLevel { get; set; }
        public RiskyUserRiskState RiskState { get; set; }
        public string UserDisplayName { get; set; }
        public string UserPrincipalName { get; set; }
    }
}
