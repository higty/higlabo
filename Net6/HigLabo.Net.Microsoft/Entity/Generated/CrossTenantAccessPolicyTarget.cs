using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/crosstenantaccesspolicytarget?view=graph-rest-1.0
    /// </summary>
    public partial class CrossTenantAccessPolicyTarget
    {
        public enum CrossTenantAccessPolicyTargetCrossTenantAccessPolicyTargetType
        {
            User,
            Group,
            Application,
            UnknownFutureValue,
        }

        public string? Target { get; set; }
        public CrossTenantAccessPolicyTargetCrossTenantAccessPolicyTargetType TargetType { get; set; }
    }
}
