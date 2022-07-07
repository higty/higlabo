using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsIoslobappDeleteParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string MobileAppId { get; set; }
    }
    public partial class IntuneAppsIoslobappDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-ioslobapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsIoslobappDeleteResponse> IntuneAppsIoslobappDeleteAsync()
        {
            var p = new IntuneAppsIoslobappDeleteParameter();
            return await this.SendAsync<IntuneAppsIoslobappDeleteParameter, IntuneAppsIoslobappDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-ioslobapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsIoslobappDeleteResponse> IntuneAppsIoslobappDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsIoslobappDeleteParameter();
            return await this.SendAsync<IntuneAppsIoslobappDeleteParameter, IntuneAppsIoslobappDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-ioslobapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsIoslobappDeleteResponse> IntuneAppsIoslobappDeleteAsync(IntuneAppsIoslobappDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneAppsIoslobappDeleteParameter, IntuneAppsIoslobappDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-ioslobapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsIoslobappDeleteResponse> IntuneAppsIoslobappDeleteAsync(IntuneAppsIoslobappDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsIoslobappDeleteParameter, IntuneAppsIoslobappDeleteResponse>(parameter, cancellationToken);
        }
    }
}
