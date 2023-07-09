using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/security-vmmetadata?view=graph-rest-1.0
    /// </summary>
    public partial class VmMetadata
    {
        public enum VmMetadataSecurityVmCloudProvider
        {
            Unknown,
            Azure,
            UnknownFutureValue,
        }

        public VmMetadataSecurityVmCloudProvider CloudProvider { get; set; }
        public string? ResourceId { get; set; }
        public string? SubscriptionId { get; set; }
        public string? VmId { get; set; }
    }
}
