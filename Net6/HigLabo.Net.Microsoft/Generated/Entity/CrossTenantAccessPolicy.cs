using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/crosstenantaccesspolicy?view=graph-rest-1.0
    /// </summary>
    public partial class CrossTenantAccessPolicy
    {
        public string? DisplayName { get; set; }
        public String[]? AllowedCloudEndpoints { get; set; }
        public CrossTenantAccessPolicyConfigurationDefault? Default { get; set; }
        public CrossTenantAccessPolicyConfigurationPartner[]? Partners { get; set; }
    }
}
