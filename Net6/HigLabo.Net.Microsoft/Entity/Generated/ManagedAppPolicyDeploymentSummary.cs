using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-mam-managedapppolicydeploymentsummary?view=graph-rest-1.0
    /// </summary>
    public partial class ManagedAppPolicyDeploymentSummary
    {
        public string? DisplayName { get; set; }
        public Int32? ConfigurationDeployedUserCount { get; set; }
        public DateTimeOffset? LastRefreshTime { get; set; }
        public ManagedAppPolicyDeploymentSummaryPerApp[]? ConfigurationDeploymentSummaryPerApp { get; set; }
        public string? Id { get; set; }
        public string? Version { get; set; }
    }
}
