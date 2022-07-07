using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsMicrosoftstoreforbusinessappCreateParameter : IRestApiParameter
    {
        public enum IntuneAppsMicrosoftstoreforbusinessappCreateParameterMobileAppPublishingState
        {
            NotPublished,
            Processing,
            Published,
        }
        public enum IntuneAppsMicrosoftstoreforbusinessappCreateParameterMicrosoftStoreForBusinessLicenseType
        {
            Offline,
            Online,
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
        public IntuneAppsMicrosoftstoreforbusinessappCreateParameterMobileAppPublishingState PublishingState { get; set; }
        public Int32? UsedLicenseCount { get; set; }
        public Int32? TotalLicenseCount { get; set; }
        public string? ProductKey { get; set; }
        public IntuneAppsMicrosoftstoreforbusinessappCreateParameterMicrosoftStoreForBusinessLicenseType LicenseType { get; set; }
        public string? PackageIdentityName { get; set; }
    }
    public partial class IntuneAppsMicrosoftstoreforbusinessappCreateResponse : RestApiResponse
    {
        public enum MicrosoftStoreForBusinessAppMobileAppPublishingState
        {
            NotPublished,
            Processing,
            Published,
        }
        public enum MicrosoftStoreForBusinessAppMicrosoftStoreForBusinessLicenseType
        {
            Offline,
            Online,
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
        public string? ProductKey { get; set; }
        public MicrosoftStoreForBusinessLicenseType? LicenseType { get; set; }
        public string? PackageIdentityName { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-microsoftstoreforbusinessapp-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMicrosoftstoreforbusinessappCreateResponse> IntuneAppsMicrosoftstoreforbusinessappCreateAsync()
        {
            var p = new IntuneAppsMicrosoftstoreforbusinessappCreateParameter();
            return await this.SendAsync<IntuneAppsMicrosoftstoreforbusinessappCreateParameter, IntuneAppsMicrosoftstoreforbusinessappCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-microsoftstoreforbusinessapp-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMicrosoftstoreforbusinessappCreateResponse> IntuneAppsMicrosoftstoreforbusinessappCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsMicrosoftstoreforbusinessappCreateParameter();
            return await this.SendAsync<IntuneAppsMicrosoftstoreforbusinessappCreateParameter, IntuneAppsMicrosoftstoreforbusinessappCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-microsoftstoreforbusinessapp-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMicrosoftstoreforbusinessappCreateResponse> IntuneAppsMicrosoftstoreforbusinessappCreateAsync(IntuneAppsMicrosoftstoreforbusinessappCreateParameter parameter)
        {
            return await this.SendAsync<IntuneAppsMicrosoftstoreforbusinessappCreateParameter, IntuneAppsMicrosoftstoreforbusinessappCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-microsoftstoreforbusinessapp-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMicrosoftstoreforbusinessappCreateResponse> IntuneAppsMicrosoftstoreforbusinessappCreateAsync(IntuneAppsMicrosoftstoreforbusinessappCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsMicrosoftstoreforbusinessappCreateParameter, IntuneAppsMicrosoftstoreforbusinessappCreateResponse>(parameter, cancellationToken);
        }
    }
}
