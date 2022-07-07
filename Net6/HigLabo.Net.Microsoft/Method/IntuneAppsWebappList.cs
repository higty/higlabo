using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsWebappListParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class IntuneAppsWebappListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-apps-webapp?view=graph-rest-1.0
        /// </summary>
        public partial class WebApp
        {
            public enum WebAppMobileAppPublishingState
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
            public string? AppUrl { get; set; }
            public bool? UseManagedBrowser { get; set; }
        }

        public WebApp[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-webapp-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsWebappListResponse> IntuneAppsWebappListAsync()
        {
            var p = new IntuneAppsWebappListParameter();
            return await this.SendAsync<IntuneAppsWebappListParameter, IntuneAppsWebappListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-webapp-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsWebappListResponse> IntuneAppsWebappListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsWebappListParameter();
            return await this.SendAsync<IntuneAppsWebappListParameter, IntuneAppsWebappListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-webapp-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsWebappListResponse> IntuneAppsWebappListAsync(IntuneAppsWebappListParameter parameter)
        {
            return await this.SendAsync<IntuneAppsWebappListParameter, IntuneAppsWebappListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-webapp-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsWebappListResponse> IntuneAppsWebappListAsync(IntuneAppsWebappListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsWebappListParameter, IntuneAppsWebappListResponse>(parameter, cancellationToken);
        }
    }
}
