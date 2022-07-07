using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsAndroidlobappGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceAppManagement_MobileApps_MobileAppId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_MobileApps_MobileAppId: return $"/deviceAppManagement/mobileApps/{MobileAppId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string MobileAppId { get; set; }
    }
    public partial class IntuneAppsAndroidlobappGetResponse : RestApiResponse
    {
        public enum AndroidLobAppMobileAppPublishingState
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
        public string? PackageId { get; set; }
        public AndroidMinimumOperatingSystem? MinimumSupportedOperatingSystem { get; set; }
        public string? VersionName { get; set; }
        public string? VersionCode { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-androidlobapp-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsAndroidlobappGetResponse> IntuneAppsAndroidlobappGetAsync()
        {
            var p = new IntuneAppsAndroidlobappGetParameter();
            return await this.SendAsync<IntuneAppsAndroidlobappGetParameter, IntuneAppsAndroidlobappGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-androidlobapp-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsAndroidlobappGetResponse> IntuneAppsAndroidlobappGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsAndroidlobappGetParameter();
            return await this.SendAsync<IntuneAppsAndroidlobappGetParameter, IntuneAppsAndroidlobappGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-androidlobapp-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsAndroidlobappGetResponse> IntuneAppsAndroidlobappGetAsync(IntuneAppsAndroidlobappGetParameter parameter)
        {
            return await this.SendAsync<IntuneAppsAndroidlobappGetParameter, IntuneAppsAndroidlobappGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-androidlobapp-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsAndroidlobappGetResponse> IntuneAppsAndroidlobappGetAsync(IntuneAppsAndroidlobappGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsAndroidlobappGetParameter, IntuneAppsAndroidlobappGetResponse>(parameter, cancellationToken);
        }
    }
}
