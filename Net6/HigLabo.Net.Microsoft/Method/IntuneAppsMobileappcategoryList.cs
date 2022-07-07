using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsMobileappcategoryListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceAppManagement_MobileAppCategories,
            DeviceAppManagement_MobileApps_MobileAppId_Categories,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_MobileAppCategories: return $"/deviceAppManagement/mobileAppCategories";
                    case ApiPath.DeviceAppManagement_MobileApps_MobileAppId_Categories: return $"/deviceAppManagement/mobileApps/{MobileAppId}/categories";
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
    public partial class IntuneAppsMobileappcategoryListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-apps-mobileappcategory?view=graph-rest-1.0
        /// </summary>
        public partial class MobileAppCategory
        {
            public string? Id { get; set; }
            public string? DisplayName { get; set; }
            public DateTimeOffset? LastModifiedDateTime { get; set; }
        }

        public MobileAppCategory[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcategory-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcategoryListResponse> IntuneAppsMobileappcategoryListAsync()
        {
            var p = new IntuneAppsMobileappcategoryListParameter();
            return await this.SendAsync<IntuneAppsMobileappcategoryListParameter, IntuneAppsMobileappcategoryListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcategory-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcategoryListResponse> IntuneAppsMobileappcategoryListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsMobileappcategoryListParameter();
            return await this.SendAsync<IntuneAppsMobileappcategoryListParameter, IntuneAppsMobileappcategoryListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcategory-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcategoryListResponse> IntuneAppsMobileappcategoryListAsync(IntuneAppsMobileappcategoryListParameter parameter)
        {
            return await this.SendAsync<IntuneAppsMobileappcategoryListParameter, IntuneAppsMobileappcategoryListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcategory-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcategoryListResponse> IntuneAppsMobileappcategoryListAsync(IntuneAppsMobileappcategoryListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsMobileappcategoryListParameter, IntuneAppsMobileappcategoryListResponse>(parameter, cancellationToken);
        }
    }
}
