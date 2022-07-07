using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsAndroidstoreappListParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class IntuneAppsAndroidstoreappListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-apps-androidstoreapp?view=graph-rest-1.0
        /// </summary>
        public partial class AndroidStoreApp
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

        public AndroidStoreApp[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-androidstoreapp-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsAndroidstoreappListResponse> IntuneAppsAndroidstoreappListAsync()
        {
            var p = new IntuneAppsAndroidstoreappListParameter();
            return await this.SendAsync<IntuneAppsAndroidstoreappListParameter, IntuneAppsAndroidstoreappListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-androidstoreapp-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsAndroidstoreappListResponse> IntuneAppsAndroidstoreappListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsAndroidstoreappListParameter();
            return await this.SendAsync<IntuneAppsAndroidstoreappListParameter, IntuneAppsAndroidstoreappListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-androidstoreapp-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsAndroidstoreappListResponse> IntuneAppsAndroidstoreappListAsync(IntuneAppsAndroidstoreappListParameter parameter)
        {
            return await this.SendAsync<IntuneAppsAndroidstoreappListParameter, IntuneAppsAndroidstoreappListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-androidstoreapp-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsAndroidstoreappListResponse> IntuneAppsAndroidstoreappListAsync(IntuneAppsAndroidstoreappListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsAndroidstoreappListParameter, IntuneAppsAndroidstoreappListResponse>(parameter, cancellationToken);
        }
    }
}
