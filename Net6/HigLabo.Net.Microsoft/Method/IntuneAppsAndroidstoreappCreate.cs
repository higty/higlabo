using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsAndroidstoreappCreateParameter : IRestApiParameter
    {
        public enum IntuneAppsAndroidstoreappCreateParameterMobileAppPublishingState
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
        public IntuneAppsAndroidstoreappCreateParameterMobileAppPublishingState PublishingState { get; set; }
        public string? PackageId { get; set; }
        public string? AppStoreUrl { get; set; }
        public AndroidMinimumOperatingSystem? MinimumSupportedOperatingSystem { get; set; }
    }
    public partial class IntuneAppsAndroidstoreappCreateResponse : RestApiResponse
    {
        public enum AndroidStoreAppMobileAppPublishingState
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
        public string? PackageId { get; set; }
        public string? AppStoreUrl { get; set; }
        public AndroidMinimumOperatingSystem? MinimumSupportedOperatingSystem { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-androidstoreapp-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsAndroidstoreappCreateResponse> IntuneAppsAndroidstoreappCreateAsync()
        {
            var p = new IntuneAppsAndroidstoreappCreateParameter();
            return await this.SendAsync<IntuneAppsAndroidstoreappCreateParameter, IntuneAppsAndroidstoreappCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-androidstoreapp-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsAndroidstoreappCreateResponse> IntuneAppsAndroidstoreappCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsAndroidstoreappCreateParameter();
            return await this.SendAsync<IntuneAppsAndroidstoreappCreateParameter, IntuneAppsAndroidstoreappCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-androidstoreapp-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsAndroidstoreappCreateResponse> IntuneAppsAndroidstoreappCreateAsync(IntuneAppsAndroidstoreappCreateParameter parameter)
        {
            return await this.SendAsync<IntuneAppsAndroidstoreappCreateParameter, IntuneAppsAndroidstoreappCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-androidstoreapp-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsAndroidstoreappCreateResponse> IntuneAppsAndroidstoreappCreateAsync(IntuneAppsAndroidstoreappCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsAndroidstoreappCreateParameter, IntuneAppsAndroidstoreappCreateResponse>(parameter, cancellationToken);
        }
    }
}
