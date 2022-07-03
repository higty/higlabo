using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-mam-managedapppolicydeploymentsummaryperapp?view=graph-rest-1.0
    /// </summary>
    public partial class ManagedAppPolicyDeploymentSummaryPerApp
    {
        public MobileAppIdentifier? MobileAppIdentifier { get; set; }
        public Int32? ConfigurationAppliedUserCount { get; set; }
    }
}
