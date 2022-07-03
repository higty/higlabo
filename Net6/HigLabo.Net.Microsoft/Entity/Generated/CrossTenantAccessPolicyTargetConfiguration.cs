using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/crosstenantaccesspolicytargetconfiguration?view=graph-rest-1.0
    /// </summary>
    public partial class CrossTenantAccessPolicyTargetConfiguration
    {
        public CrossTenantAccessPolicyTargetConfigurationCrossTenantAccessPolicyTargetConfigurationAccessType AccessType { get; set; }
        public CrossTenantAccessPolicyTarget[] Targets { get; set; }
    }
}
