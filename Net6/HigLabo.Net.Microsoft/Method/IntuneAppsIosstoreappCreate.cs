using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsIosstoreappCreateParameter : IRestApiParameter
    {
        public enum IntuneAppsIosstoreappCreateParameterMobileAppPublishingState
        {
            NotPublished,
            Processing,
            Published,
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
        public IntuneAppsIosstoreappCreateParameterMobileAppPublishingState PublishingState { get; set; }
        public string? BundleId { get; set; }
        public string? AppStoreUrl { get; set; }
        public IosDeviceType? ApplicableDeviceType { get; set; }
        public IosMinimumOperatingSystem? MinimumSupportedOperatingSystem { get; set; }
    }
    public partial class IntuneAppsIosstoreappCreateResponse : RestApiResponse
    {
        public enum IosStoreAppMobileAppPublishingState
        {
            NotPublished,
            Processing,
            Published,
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
        public string? BundleId { get; set; }
        public string? AppStoreUrl { get; set; }
        public IosDeviceType? ApplicableDeviceType { get; set; }
        public IosMinimumOperatingSystem? MinimumSupportedOperatingSystem { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-iosstoreapp-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsIosstoreappCreateResponse> IntuneAppsIosstoreappCreateAsync()
        {
            var p = new IntuneAppsIosstoreappCreateParameter();
            return await this.SendAsync<IntuneAppsIosstoreappCreateParameter, IntuneAppsIosstoreappCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-iosstoreapp-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsIosstoreappCreateResponse> IntuneAppsIosstoreappCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsIosstoreappCreateParameter();
            return await this.SendAsync<IntuneAppsIosstoreappCreateParameter, IntuneAppsIosstoreappCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-iosstoreapp-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsIosstoreappCreateResponse> IntuneAppsIosstoreappCreateAsync(IntuneAppsIosstoreappCreateParameter parameter)
        {
            return await this.SendAsync<IntuneAppsIosstoreappCreateParameter, IntuneAppsIosstoreappCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-iosstoreapp-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsIosstoreappCreateResponse> IntuneAppsIosstoreappCreateAsync(IntuneAppsIosstoreappCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsIosstoreappCreateParameter, IntuneAppsIosstoreappCreateResponse>(parameter, cancellationToken);
        }
    }
}
