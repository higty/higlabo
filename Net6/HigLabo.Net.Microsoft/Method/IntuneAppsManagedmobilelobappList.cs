using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsManagedmobilelobappListParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class IntuneAppsManagedmobilelobappListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-apps-managedmobilelobapp?view=graph-rest-1.0
        /// </summary>
        public partial class ManagedMobileLobApp
        {
            public enum ManagedMobileLobAppMobileAppPublishingState
            {
                NotPublished,
                Processing,
                Published,
            }
            public enum ManagedMobileLobAppManagedAppAvailability
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
            public string? CommittedContentVersion { get; set; }
            public string? FileName { get; set; }
            public Int64? Size { get; set; }
        }

        public ManagedMobileLobApp[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-managedmobilelobapp-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManagedmobilelobappListResponse> IntuneAppsManagedmobilelobappListAsync()
        {
            var p = new IntuneAppsManagedmobilelobappListParameter();
            return await this.SendAsync<IntuneAppsManagedmobilelobappListParameter, IntuneAppsManagedmobilelobappListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-managedmobilelobapp-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManagedmobilelobappListResponse> IntuneAppsManagedmobilelobappListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsManagedmobilelobappListParameter();
            return await this.SendAsync<IntuneAppsManagedmobilelobappListParameter, IntuneAppsManagedmobilelobappListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-managedmobilelobapp-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManagedmobilelobappListResponse> IntuneAppsManagedmobilelobappListAsync(IntuneAppsManagedmobilelobappListParameter parameter)
        {
            return await this.SendAsync<IntuneAppsManagedmobilelobappListParameter, IntuneAppsManagedmobilelobappListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-managedmobilelobapp-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManagedmobilelobappListResponse> IntuneAppsManagedmobilelobappListAsync(IntuneAppsManagedmobilelobappListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsManagedmobilelobappListParameter, IntuneAppsManagedmobilelobappListResponse>(parameter, cancellationToken);
        }
    }
}
