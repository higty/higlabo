using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsMobileappcategoryCreateParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string MobileAppId { get; set; }
    }
    public partial class IntuneAppsMobileappcategoryCreateResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcategory-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcategoryCreateResponse> IntuneAppsMobileappcategoryCreateAsync()
        {
            var p = new IntuneAppsMobileappcategoryCreateParameter();
            return await this.SendAsync<IntuneAppsMobileappcategoryCreateParameter, IntuneAppsMobileappcategoryCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcategory-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcategoryCreateResponse> IntuneAppsMobileappcategoryCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsMobileappcategoryCreateParameter();
            return await this.SendAsync<IntuneAppsMobileappcategoryCreateParameter, IntuneAppsMobileappcategoryCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcategory-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcategoryCreateResponse> IntuneAppsMobileappcategoryCreateAsync(IntuneAppsMobileappcategoryCreateParameter parameter)
        {
            return await this.SendAsync<IntuneAppsMobileappcategoryCreateParameter, IntuneAppsMobileappcategoryCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-mobileappcategory-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMobileappcategoryCreateResponse> IntuneAppsMobileappcategoryCreateAsync(IntuneAppsMobileappcategoryCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsMobileappcategoryCreateParameter, IntuneAppsMobileappcategoryCreateResponse>(parameter, cancellationToken);
        }
    }
}
