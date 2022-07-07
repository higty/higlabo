using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsManagediosstoreappCreateParameter : IRestApiParameter
    {
        public enum IntuneAppsManagediosstoreappCreateParameterMobileAppPublishingState
        {
            NotPublished,
            Processing,
            Published,
        }
        public enum IntuneAppsManagediosstoreappCreateParameterManagedAppAvailability
        {
            Global,
            LineOfBusiness,
        }
        public enum ApiPath
        {
            DeviceAppManagement_MobileApps,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_MobileApps: return $"/deviceAppManagement/mobileApps";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public string? Publisher { get; set; }
        public MimeContent? LargeIcon { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public bool? IsFeatured { get; set; }
        public string? PrivacyInformationUrl { get; set; }
        public string? InformationUrl { get; set; }
        public string? Owner { get; set; }
        public string? Developer { get; set; }
        public string? Notes { get; set; }
        public IntuneAppsManagediosstoreappCreateParameterMobileAppPublishingState PublishingState { get; set; }
        public IntuneAppsManagediosstoreappCreateParameterManagedAppAvailability AppAvailability { get; set; }
        public string? Version { get; set; }
        public string? BundleId { get; set; }
        public string? AppStoreUrl { get; set; }
        public IosDeviceType? ApplicableDeviceType { get; set; }
        public IosMinimumOperatingSystem? MinimumSupportedOperatingSystem { get; set; }
    }
    public partial class IntuneAppsManagediosstoreappCreateResponse : RestApiResponse
    {
        public enum ManagedIOSStoreAppMobileAppPublishingState
        {
            NotPublished,
            Processing,
            Published,
        }
        public enum ManagedIOSStoreAppManagedAppAvailability
        {
            Global,
            LineOfBusiness,
        }

        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public string? Publisher { get; set; }
        public MimeContent? LargeIcon { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public bool? IsFeatured { get; set; }
        public string? PrivacyInformationUrl { get; set; }
        public string? InformationUrl { get; set; }
        public string? Owner { get; set; }
        public string? Developer { get; set; }
        public string? Notes { get; set; }
        public MobileAppPublishingState? PublishingState { get; set; }
        public ManagedAppAvailability? AppAvailability { get; set; }
        public string? Version { get; set; }
        public string? BundleId { get; set; }
        public string? AppStoreUrl { get; set; }
        public IosDeviceType? ApplicableDeviceType { get; set; }
        public IosMinimumOperatingSystem? MinimumSupportedOperatingSystem { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-managediosstoreapp-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManagediosstoreappCreateResponse> IntuneAppsManagediosstoreappCreateAsync()
        {
            var p = new IntuneAppsManagediosstoreappCreateParameter();
            return await this.SendAsync<IntuneAppsManagediosstoreappCreateParameter, IntuneAppsManagediosstoreappCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-managediosstoreapp-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManagediosstoreappCreateResponse> IntuneAppsManagediosstoreappCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsManagediosstoreappCreateParameter();
            return await this.SendAsync<IntuneAppsManagediosstoreappCreateParameter, IntuneAppsManagediosstoreappCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-managediosstoreapp-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManagediosstoreappCreateResponse> IntuneAppsManagediosstoreappCreateAsync(IntuneAppsManagediosstoreappCreateParameter parameter)
        {
            return await this.SendAsync<IntuneAppsManagediosstoreappCreateParameter, IntuneAppsManagediosstoreappCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-managediosstoreapp-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManagediosstoreappCreateResponse> IntuneAppsManagediosstoreappCreateAsync(IntuneAppsManagediosstoreappCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsManagediosstoreappCreateParameter, IntuneAppsManagediosstoreappCreateResponse>(parameter, cancellationToken);
        }
    }
}
