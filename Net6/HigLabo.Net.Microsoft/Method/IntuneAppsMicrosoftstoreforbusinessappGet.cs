using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsMicrosoftstoreforbusinessappGetParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class IntuneAppsMicrosoftstoreforbusinessappGetResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-microsoftstoreforbusinessapp-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMicrosoftstoreforbusinessappGetResponse> IntuneAppsMicrosoftstoreforbusinessappGetAsync()
        {
            var p = new IntuneAppsMicrosoftstoreforbusinessappGetParameter();
            return await this.SendAsync<IntuneAppsMicrosoftstoreforbusinessappGetParameter, IntuneAppsMicrosoftstoreforbusinessappGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-microsoftstoreforbusinessapp-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMicrosoftstoreforbusinessappGetResponse> IntuneAppsMicrosoftstoreforbusinessappGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsMicrosoftstoreforbusinessappGetParameter();
            return await this.SendAsync<IntuneAppsMicrosoftstoreforbusinessappGetParameter, IntuneAppsMicrosoftstoreforbusinessappGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-microsoftstoreforbusinessapp-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMicrosoftstoreforbusinessappGetResponse> IntuneAppsMicrosoftstoreforbusinessappGetAsync(IntuneAppsMicrosoftstoreforbusinessappGetParameter parameter)
        {
            return await this.SendAsync<IntuneAppsMicrosoftstoreforbusinessappGetParameter, IntuneAppsMicrosoftstoreforbusinessappGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-microsoftstoreforbusinessapp-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMicrosoftstoreforbusinessappGetResponse> IntuneAppsMicrosoftstoreforbusinessappGetAsync(IntuneAppsMicrosoftstoreforbusinessappGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsMicrosoftstoreforbusinessappGetParameter, IntuneAppsMicrosoftstoreforbusinessappGetResponse>(parameter, cancellationToken);
        }
    }
}
