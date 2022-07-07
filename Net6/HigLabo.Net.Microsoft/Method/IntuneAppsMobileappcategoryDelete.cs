using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsMobileappcategoryDeleteParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string MobileAppCategoryId { get; set; }
        public string MobileAppId { get; set; }
    }
    public partial class IntuneAppsMobileappcategoryDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcategory-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcategoryDeleteResponse> IntuneAppsMobileappcategoryDeleteAsync()
        {
            var p = new IntuneAppsMobileappcategoryDeleteParameter();
            return await this.SendAsync<IntuneAppsMobileappcategoryDeleteParameter, IntuneAppsMobileappcategoryDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcategory-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcategoryDeleteResponse> IntuneAppsMobileappcategoryDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsMobileappcategoryDeleteParameter();
            return await this.SendAsync<IntuneAppsMobileappcategoryDeleteParameter, IntuneAppsMobileappcategoryDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcategory-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcategoryDeleteResponse> IntuneAppsMobileappcategoryDeleteAsync(IntuneAppsMobileappcategoryDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneAppsMobileappcategoryDeleteParameter, IntuneAppsMobileappcategoryDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcategory-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcategoryDeleteResponse> IntuneAppsMobileappcategoryDeleteAsync(IntuneAppsMobileappcategoryDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsMobileappcategoryDeleteParameter, IntuneAppsMobileappcategoryDeleteResponse>(parameter, cancellationToken);
        }
    }
}
