using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/crosstenantaccesspolicytargetconfiguration?view=graph-rest-1.0
    /// </summary>
    public partial class CrossTenantAccessPolicyTargetConfiguration
    {
        public enum CrossTenantAccessPolicyTargetConfigurationCrossTenantAccessPolicyTargetConfigurationAccessType
        {
            Allowed,
            Blocked,
            UnknownFutureValue,
        }

        public CrossTenantAccessPolicyTargetConfigurationCrossTenantAccessPolicyTargetConfigurationAccessType AccessType { get; set; }
        public CrossTenantAccessPolicyTarget[]? Targets { get; set; }
    }
}
