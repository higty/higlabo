using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsManagedandroidstoreappListParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class IntuneAppsManagedandroidstoreappListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-apps-managedandroidstoreapp?view=graph-rest-1.0
        /// </summary>
        public partial class ManagedAndroidStoreApp
        {
            public enum ManagedAndroidStoreAppMobileAppPublishingState
            {
                NotPublished,
                Processing,
                Published,
            }
            public enum ManagedAndroidStoreAppManagedAppAvailability
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
            public string? PackageId { get; set; }
            public string? AppStoreUrl { get; set; }
            public AndroidMinimumOperatingSystem? MinimumSupportedOperatingSystem { get; set; }
        }

        public ManagedAndroidStoreApp[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-managedandroidstoreapp-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManagedandroidstoreappListResponse> IntuneAppsManagedandroidstoreappListAsync()
        {
            var p = new IntuneAppsManagedandroidstoreappListParameter();
            return await this.SendAsync<IntuneAppsManagedandroidstoreappListParameter, IntuneAppsManagedandroidstoreappListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-managedandroidstoreapp-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManagedandroidstoreappListResponse> IntuneAppsManagedandroidstoreappListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsManagedandroidstoreappListParameter();
            return await this.SendAsync<IntuneAppsManagedandroidstoreappListParameter, IntuneAppsManagedandroidstoreappListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-managedandroidstoreapp-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManagedandroidstoreappListResponse> IntuneAppsManagedandroidstoreappListAsync(IntuneAppsManagedandroidstoreappListParameter parameter)
        {
            return await this.SendAsync<IntuneAppsManagedandroidstoreappListParameter, IntuneAppsManagedandroidstoreappListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-managedandroidstoreapp-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManagedandroidstoreappListResponse> IntuneAppsManagedandroidstoreappListAsync(IntuneAppsManagedandroidstoreappListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsManagedandroidstoreappListParameter, IntuneAppsManagedandroidstoreappListResponse>(parameter, cancellationToken);
        }
    }
}
