using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsIosvppappCreateParameter : IRestApiParameter
    {
        public enum IntuneAppsIosvppappCreateParameterMobileAppPublishingState
        {
            NotPublished,
            Processing,
            Published,
        }
        public enum IntuneAppsIosvppappCreateParameterVppTokenAccountType
        {
            Business,
            Education,
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
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
        public IntuneAppsIosvppappCreateParameterMobileAppPublishingState PublishingState { get; set; }
        public Int32? UsedLicenseCount { get; set; }
        public Int32? TotalLicenseCount { get; set; }
        public DateTimeOffset? ReleaseDateTime { get; set; }
        public string? AppStoreUrl { get; set; }
        public VppLicensingType? LicensingType { get; set; }
        public IosDeviceType? ApplicableDeviceType { get; set; }
        public string? VppTokenOrganizationName { get; set; }
        public IntuneAppsIosvppappCreateParameterVppTokenAccountType VppTokenAccountType { get; set; }
        public string? VppTokenAppleId { get; set; }
        public string? BundleId { get; set; }
    }
    public partial class IntuneAppsIosvppappCreateResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-iosvppapp-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsIosvppappCreateResponse> IntuneAppsIosvppappCreateAsync()
        {
            var p = new IntuneAppsIosvppappCreateParameter();
            return await this.SendAsync<IntuneAppsIosvppappCreateParameter, IntuneAppsIosvppappCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-iosvppapp-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsIosvppappCreateResponse> IntuneAppsIosvppappCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsIosvppappCreateParameter();
            return await this.SendAsync<IntuneAppsIosvppappCreateParameter, IntuneAppsIosvppappCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-iosvppapp-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsIosvppappCreateResponse> IntuneAppsIosvppappCreateAsync(IntuneAppsIosvppappCreateParameter parameter)
        {
            return await this.SendAsync<IntuneAppsIosvppappCreateParameter, IntuneAppsIosvppappCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-iosvppapp-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsIosvppappCreateResponse> IntuneAppsIosvppappCreateAsync(IntuneAppsIosvppappCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsIosvppappCreateParameter, IntuneAppsIosvppappCreateResponse>(parameter, cancellationToken);
        }
    }
}
