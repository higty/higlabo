using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsMobilelobappListParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class IntuneAppsMobilelobappListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-apps-mobilelobapp?view=graph-rest-1.0
        /// </summary>
        public partial class MobileLobApp
        {
            public enum MobileLobAppMobileAppPublishingState
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
        }

        public MobileLobApp[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobilelobapp-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobilelobappListResponse> IntuneAppsMobilelobappListAsync()
        {
            var p = new IntuneAppsMobilelobappListParameter();
            return await this.SendAsync<IntuneAppsMobilelobappListParameter, IntuneAppsMobilelobappListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobilelobapp-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobilelobappListResponse> IntuneAppsMobilelobappListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsMobilelobappListParameter();
            return await this.SendAsync<IntuneAppsMobilelobappListParameter, IntuneAppsMobilelobappListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobilelobapp-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobilelobappListResponse> IntuneAppsMobilelobappListAsync(IntuneAppsMobilelobappListParameter parameter)
        {
            return await this.SendAsync<IntuneAppsMobilelobappListParameter, IntuneAppsMobilelobappListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobilelobapp-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobilelobappListResponse> IntuneAppsMobilelobappListAsync(IntuneAppsMobilelobappListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsMobilelobappListParameter, IntuneAppsMobilelobappListResponse>(parameter, cancellationToken);
        }
    }
}
