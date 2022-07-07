using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsAndroidlobappListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
    }
    public partial class IntuneAppsAndroidlobappListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-apps-androidlobapp?view=graph-rest-1.0
        /// </summary>
        public partial class AndroidLobApp
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

        public AndroidLobApp[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-androidlobapp-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsAndroidlobappListResponse> IntuneAppsAndroidlobappListAsync()
        {
            var p = new IntuneAppsAndroidlobappListParameter();
            return await this.SendAsync<IntuneAppsAndroidlobappListParameter, IntuneAppsAndroidlobappListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-androidlobapp-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsAndroidlobappListResponse> IntuneAppsAndroidlobappListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsAndroidlobappListParameter();
            return await this.SendAsync<IntuneAppsAndroidlobappListParameter, IntuneAppsAndroidlobappListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-androidlobapp-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsAndroidlobappListResponse> IntuneAppsAndroidlobappListAsync(IntuneAppsAndroidlobappListParameter parameter)
        {
            return await this.SendAsync<IntuneAppsAndroidlobappListParameter, IntuneAppsAndroidlobappListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-androidlobapp-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsAndroidlobappListResponse> IntuneAppsAndroidlobappListAsync(IntuneAppsAndroidlobappListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsAndroidlobappListParameter, IntuneAppsAndroidlobappListResponse>(parameter, cancellationToken);
        }
    }
}
