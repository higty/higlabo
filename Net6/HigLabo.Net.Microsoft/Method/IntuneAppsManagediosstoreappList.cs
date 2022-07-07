using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsManagediosstoreappListParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class IntuneAppsManagediosstoreappListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-apps-managediosstoreapp?view=graph-rest-1.0
        /// </summary>
        public partial class ManagedIOSStoreApp
        {
            public enum ManagedIOSStoreAppMobileAppPublishingState
            {
                NotPublished,
                Processing,
                Published,
            }
            public enum ManagedIOSStoreAppManagedAppAvailability
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
            public string? BundleId { get; set; }
            public string? AppStoreUrl { get; set; }
            public IosDeviceType? ApplicableDeviceType { get; set; }
            public IosMinimumOperatingSystem? MinimumSupportedOperatingSystem { get; set; }
        }

        public ManagedIOSStoreApp[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-managediosstoreapp-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManagediosstoreappListResponse> IntuneAppsManagediosstoreappListAsync()
        {
            var p = new IntuneAppsManagediosstoreappListParameter();
            return await this.SendAsync<IntuneAppsManagediosstoreappListParameter, IntuneAppsManagediosstoreappListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-managediosstoreapp-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManagediosstoreappListResponse> IntuneAppsManagediosstoreappListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsManagediosstoreappListParameter();
            return await this.SendAsync<IntuneAppsManagediosstoreappListParameter, IntuneAppsManagediosstoreappListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-managediosstoreapp-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManagediosstoreappListResponse> IntuneAppsManagediosstoreappListAsync(IntuneAppsManagediosstoreappListParameter parameter)
        {
            return await this.SendAsync<IntuneAppsManagediosstoreappListParameter, IntuneAppsManagediosstoreappListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-managediosstoreapp-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManagediosstoreappListResponse> IntuneAppsManagediosstoreappListAsync(IntuneAppsManagediosstoreappListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsManagediosstoreappListParameter, IntuneAppsManagediosstoreappListResponse>(parameter, cancellationToken);
        }
    }
}
