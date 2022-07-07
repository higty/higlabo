using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsIoslobappCreateParameter : IRestApiParameter
    {
        public enum IntuneAppsIoslobappCreateParameterMobileAppPublishingState
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
        public IntuneAppsIoslobappCreateParameterMobileAppPublishingState PublishingState { get; set; }
        public string? CommittedContentVersion { get; set; }
        public string? FileName { get; set; }
        public Int64? Size { get; set; }
        public string? BundleId { get; set; }
        public IosDeviceType? ApplicableDeviceType { get; set; }
        public IosMinimumOperatingSystem? MinimumSupportedOperatingSystem { get; set; }
        public DateTimeOffset? ExpirationDateTime { get; set; }
        public string? VersionNumber { get; set; }
        public string? BuildNumber { get; set; }
    }
    public partial class IntuneAppsIoslobappCreateResponse : RestApiResponse
    {
        public enum IosLobAppMobileAppPublishingState
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
        public string? CommittedContentVersion { get; set; }
        public string? FileName { get; set; }
        public Int64? Size { get; set; }
        public string? BundleId { get; set; }
        public IosDeviceType? ApplicableDeviceType { get; set; }
        public IosMinimumOperatingSystem? MinimumSupportedOperatingSystem { get; set; }
        public DateTimeOffset? ExpirationDateTime { get; set; }
        public string? VersionNumber { get; set; }
        public string? BuildNumber { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-ioslobapp-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsIoslobappCreateResponse> IntuneAppsIoslobappCreateAsync()
        {
            var p = new IntuneAppsIoslobappCreateParameter();
            return await this.SendAsync<IntuneAppsIoslobappCreateParameter, IntuneAppsIoslobappCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-ioslobapp-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsIoslobappCreateResponse> IntuneAppsIoslobappCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsIoslobappCreateParameter();
            return await this.SendAsync<IntuneAppsIoslobappCreateParameter, IntuneAppsIoslobappCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-ioslobapp-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsIoslobappCreateResponse> IntuneAppsIoslobappCreateAsync(IntuneAppsIoslobappCreateParameter parameter)
        {
            return await this.SendAsync<IntuneAppsIoslobappCreateParameter, IntuneAppsIoslobappCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-ioslobapp-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsIoslobappCreateResponse> IntuneAppsIoslobappCreateAsync(IntuneAppsIoslobappCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsIoslobappCreateParameter, IntuneAppsIoslobappCreateResponse>(parameter, cancellationToken);
        }
    }
}
