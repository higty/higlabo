using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsManagediosstoreappGetParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class IntuneAppsManagediosstoreappGetResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-managediosstoreapp-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManagediosstoreappGetResponse> IntuneAppsManagediosstoreappGetAsync()
        {
            var p = new IntuneAppsManagediosstoreappGetParameter();
            return await this.SendAsync<IntuneAppsManagediosstoreappGetParameter, IntuneAppsManagediosstoreappGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-managediosstoreapp-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManagediosstoreappGetResponse> IntuneAppsManagediosstoreappGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsManagediosstoreappGetParameter();
            return await this.SendAsync<IntuneAppsManagediosstoreappGetParameter, IntuneAppsManagediosstoreappGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-managediosstoreapp-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManagediosstoreappGetResponse> IntuneAppsManagediosstoreappGetAsync(IntuneAppsManagediosstoreappGetParameter parameter)
        {
            return await this.SendAsync<IntuneAppsManagediosstoreappGetParameter, IntuneAppsManagediosstoreappGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-managediosstoreapp-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManagediosstoreappGetResponse> IntuneAppsManagediosstoreappGetAsync(IntuneAppsManagediosstoreappGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsManagediosstoreappGetParameter, IntuneAppsManagediosstoreappGetResponse>(parameter, cancellationToken);
        }
    }
}
