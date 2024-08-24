using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/cloudpcprovisioningpolicy?view=graph-rest-1.0
    /// </summary>
    public partial class CloudPcProvisioningPolicy
    {
        public enum CloudPcProvisioningPolicyCloudPcProvisioningPolicyImageType
        {
            Gallery,
            Custom,
        }
        public enum CloudPcProvisioningPolicyCloudPcProvisioningType
        {
            Dedicated,
            Shared,
            UnknownFutureValue,
        }

        public string? AlternateResourceUrl { get; set; }
        public string? CloudPcGroupDisplayName { get; set; }
        public string? CloudPcNamingTemplate { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public CloudPcDomainJoinConfiguration[]? DomainJoinConfigurations { get; set; }
        public bool? EnableSingleSignOn { get; set; }
        public Int32? GracePeriodInHours { get; set; }
        public string? Id { get; set; }
        public string? ImageDisplayName { get; set; }
        public string? ImageId { get; set; }
        public CloudPcProvisioningPolicy? ImageType { get; set; }
        public bool? LocalAdminEnabled { get; set; }
        public MicrosoftManagedDesktop? MicrosoftManagedDesktop { get; set; }
        public CloudPcProvisioningPolicyCloudPcProvisioningType ProvisioningType { get; set; }
        public CloudPcWindowsSetting? WindowsSetting { get; set; }
        public CloudPcProvisioningPolicyAssignment[]? Assignments { get; set; }
    }
}
