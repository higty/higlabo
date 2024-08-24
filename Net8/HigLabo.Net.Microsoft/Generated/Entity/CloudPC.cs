using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/cloudpc?view=graph-rest-1.0
    /// </summary>
    public partial class CloudPC
    {
        public enum CloudPCCloudPcProvisioningType
        {
            Dedicated,
            Shared,
            UnknownFutureValue,
        }

        public string? AadDeviceId { get; set; }
        public string? DisplayName { get; set; }
        public DateTimeOffset? GracePeriodEndDateTime { get; set; }
        public string? Id { get; set; }
        public string? ImageDisplayName { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string? ManagedDeviceId { get; set; }
        public string? ManagedDeviceName { get; set; }
        public string? OnPremisesConnectionName { get; set; }
        public string? ProvisioningPolicyId { get; set; }
        public string? ProvisioningPolicyName { get; set; }
        public CloudPCCloudPcProvisioningType ProvisioningType { get; set; }
        public string? ServicePlanId { get; set; }
        public string? ServicePlanName { get; set; }
        public string? UserPrincipalName { get; set; }
    }
}
