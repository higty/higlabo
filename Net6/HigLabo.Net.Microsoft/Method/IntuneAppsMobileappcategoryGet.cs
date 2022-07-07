using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsMobileappcategoryGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceAppManagement_MobileAppCategories_MobileAppCategoryId,
            DeviceAppManagement_MobileApps_MobileAppId_Categories_MobileAppCategoryId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_MobileAppCategories_MobileAppCategoryId: return $"/deviceAppManagement/mobileAppCategories/{MobileAppCategoryId}";
                    case ApiPath.DeviceAppManagement_MobileApps_MobileAppId_Categories_MobileAppCategoryId: return $"/deviceAppManagement/mobileApps/{MobileAppId}/categories/{MobileAppCategoryId}";
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
        public string MobileAppCategoryId { get; set; }
        public string MobileAppId { get; set; }
    }
    public partial class IntuneAppsMobileappcategoryGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcategory-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcategoryGetResponse> IntuneAppsMobileappcategoryGetAsync()
        {
            var p = new IntuneAppsMobileappcategoryGetParameter();
            return await this.SendAsync<IntuneAppsMobileappcategoryGetParameter, IntuneAppsMobileappcategoryGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcategory-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcategoryGetResponse> IntuneAppsMobileappcategoryGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsMobileappcategoryGetParameter();
            return await this.SendAsync<IntuneAppsMobileappcategoryGetParameter, IntuneAppsMobileappcategoryGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcategory-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcategoryGetResponse> IntuneAppsMobileappcategoryGetAsync(IntuneAppsMobileappcategoryGetParameter parameter)
        {
            return await this.SendAsync<IntuneAppsMobileappcategoryGetParameter, IntuneAppsMobileappcategoryGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcategory-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcategoryGetResponse> IntuneAppsMobileappcategoryGetAsync(IntuneAppsMobileappcategoryGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsMobileappcategoryGetParameter, IntuneAppsMobileappcategoryGetResponse>(parameter, cancellationToken);
        }
    }
}
