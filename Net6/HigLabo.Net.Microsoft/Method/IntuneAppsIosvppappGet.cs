using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsIosvppappGetParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class IntuneAppsIosvppappGetResponse : RestApiResponse
    {
        public enum IosVppAppMobileAppPublishingState
        {
            NotPublished,
            Processing,
            Published,
        }
        public enum IosVppAppVppTokenAccountType
        {
            Business,
            Education,
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
        public Int32? UsedLicenseCount { get; set; }
        public Int32? TotalLicenseCount { get; set; }
        public DateTimeOffset? ReleaseDateTime { get; set; }
        public string? AppStoreUrl { get; set; }
        public VppLicensingType? LicensingType { get; set; }
        public IosDeviceType? ApplicableDeviceType { get; set; }
        public string? VppTokenOrganizationName { get; set; }
        public VppTokenAccountType? VppTokenAccountType { get; set; }
        public string? VppTokenAppleId { get; set; }
        public string? BundleId { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-iosvppapp-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsIosvppappGetResponse> IntuneAppsIosvppappGetAsync()
        {
            var p = new IntuneAppsIosvppappGetParameter();
            return await this.SendAsync<IntuneAppsIosvppappGetParameter, IntuneAppsIosvppappGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-iosvppapp-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsIosvppappGetResponse> IntuneAppsIosvppappGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsIosvppappGetParameter();
            return await this.SendAsync<IntuneAppsIosvppappGetParameter, IntuneAppsIosvppappGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-iosvppapp-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsIosvppappGetResponse> IntuneAppsIosvppappGetAsync(IntuneAppsIosvppappGetParameter parameter)
        {
            return await this.SendAsync<IntuneAppsIosvppappGetParameter, IntuneAppsIosvppappGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-iosvppapp-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsIosvppappGetResponse> IntuneAppsIosvppappGetAsync(IntuneAppsIosvppappGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsIosvppappGetParameter, IntuneAppsIosvppappGetResponse>(parameter, cancellationToken);
        }
    }
}
