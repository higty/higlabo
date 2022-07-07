using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsMobileappListParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class IntuneAppsMobileappListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-apps-mobileapp?view=graph-rest-1.0
        /// </summary>
        public partial class MobileApp
        {
            public enum MobileAppMobileAppPublishingState
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
        }

        public MobileApp[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileapp-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappListResponse> IntuneAppsMobileappListAsync()
        {
            var p = new IntuneAppsMobileappListParameter();
            return await this.SendAsync<IntuneAppsMobileappListParameter, IntuneAppsMobileappListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileapp-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappListResponse> IntuneAppsMobileappListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsMobileappListParameter();
            return await this.SendAsync<IntuneAppsMobileappListParameter, IntuneAppsMobileappListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileapp-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappListResponse> IntuneAppsMobileappListAsync(IntuneAppsMobileappListParameter parameter)
        {
            return await this.SendAsync<IntuneAppsMobileappListParameter, IntuneAppsMobileappListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileapp-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappListResponse> IntuneAppsMobileappListAsync(IntuneAppsMobileappListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsMobileappListParameter, IntuneAppsMobileappListResponse>(parameter, cancellationToken);
        }
    }
}
