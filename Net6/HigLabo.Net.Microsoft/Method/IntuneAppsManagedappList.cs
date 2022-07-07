using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsManagedappListParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class IntuneAppsManagedappListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-apps-managedapp?view=graph-rest-1.0
        /// </summary>
        public partial class ManagedApp
        {
            public enum ManagedAppMobileAppPublishingState
            {
                NotPublished,
                Processing,
                Published,
            }
            public enum ManagedAppManagedAppAvailability
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
        }

        public ManagedApp[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-managedapp-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManagedappListResponse> IntuneAppsManagedappListAsync()
        {
            var p = new IntuneAppsManagedappListParameter();
            return await this.SendAsync<IntuneAppsManagedappListParameter, IntuneAppsManagedappListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-managedapp-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManagedappListResponse> IntuneAppsManagedappListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsManagedappListParameter();
            return await this.SendAsync<IntuneAppsManagedappListParameter, IntuneAppsManagedappListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-managedapp-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManagedappListResponse> IntuneAppsManagedappListAsync(IntuneAppsManagedappListParameter parameter)
        {
            return await this.SendAsync<IntuneAppsManagedappListParameter, IntuneAppsManagedappListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-managedapp-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManagedappListResponse> IntuneAppsManagedappListAsync(IntuneAppsManagedappListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsManagedappListParameter, IntuneAppsManagedappListResponse>(parameter, cancellationToken);
        }
    }
}
