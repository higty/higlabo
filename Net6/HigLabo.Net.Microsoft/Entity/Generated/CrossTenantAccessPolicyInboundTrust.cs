using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/crosstenantaccesspolicyinboundtrust?view=graph-rest-1.0
    /// </summary>
    public partial class CrossTenantAccessPolicyInboundTrust
    {
        public bool? IsCompliantDeviceAccepted { get; set; }
        public bool? IsHybridAzureADJoinedDeviceAccepted { get; set; }
        public bool? IsMfaAccepted { get; set; }
    }
}
