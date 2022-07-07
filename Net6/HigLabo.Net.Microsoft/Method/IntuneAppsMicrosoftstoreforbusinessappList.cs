using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsMicrosoftstoreforbusinessappListParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class IntuneAppsMicrosoftstoreforbusinessappListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-apps-microsoftstoreforbusinessapp?view=graph-rest-1.0
        /// </summary>
        public partial class MicrosoftStoreForBusinessApp
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

        public MicrosoftStoreForBusinessApp[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-microsoftstoreforbusinessapp-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMicrosoftstoreforbusinessappListResponse> IntuneAppsMicrosoftstoreforbusinessappListAsync()
        {
            var p = new IntuneAppsMicrosoftstoreforbusinessappListParameter();
            return await this.SendAsync<IntuneAppsMicrosoftstoreforbusinessappListParameter, IntuneAppsMicrosoftstoreforbusinessappListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-microsoftstoreforbusinessapp-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMicrosoftstoreforbusinessappListResponse> IntuneAppsMicrosoftstoreforbusinessappListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsMicrosoftstoreforbusinessappListParameter();
            return await this.SendAsync<IntuneAppsMicrosoftstoreforbusinessappListParameter, IntuneAppsMicrosoftstoreforbusinessappListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-microsoftstoreforbusinessapp-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMicrosoftstoreforbusinessappListResponse> IntuneAppsMicrosoftstoreforbusinessappListAsync(IntuneAppsMicrosoftstoreforbusinessappListParameter parameter)
        {
            return await this.SendAsync<IntuneAppsMicrosoftstoreforbusinessappListParameter, IntuneAppsMicrosoftstoreforbusinessappListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-microsoftstoreforbusinessapp-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMicrosoftstoreforbusinessappListResponse> IntuneAppsMicrosoftstoreforbusinessappListAsync(IntuneAppsMicrosoftstoreforbusinessappListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsMicrosoftstoreforbusinessappListParameter, IntuneAppsMicrosoftstoreforbusinessappListResponse>(parameter, cancellationToken);
        }
    }
}
