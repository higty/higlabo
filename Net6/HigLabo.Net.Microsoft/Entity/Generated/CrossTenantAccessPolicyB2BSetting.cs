using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/crosstenantaccesspolicyb2bsetting?view=graph-rest-1.0
    /// </summary>
    public partial class CrossTenantAccessPolicyB2BSetting
    {
        public CrossTenantAccessPolicyTargetConfiguration? Applications { get; set; }
        public CrossTenantAccessPolicyTargetConfiguration? UsersAndGroups { get; set; }
    }
}
