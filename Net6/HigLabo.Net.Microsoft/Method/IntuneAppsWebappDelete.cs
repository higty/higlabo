using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsWebappDeleteParameter : IRestApiParameter
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
    public partial class IntuneAppsWebappDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-webapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsWebappDeleteResponse> IntuneAppsWebappDeleteAsync()
        {
            var p = new IntuneAppsWebappDeleteParameter();
            return await this.SendAsync<IntuneAppsWebappDeleteParameter, IntuneAppsWebappDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-webapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsWebappDeleteResponse> IntuneAppsWebappDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsWebappDeleteParameter();
            return await this.SendAsync<IntuneAppsWebappDeleteParameter, IntuneAppsWebappDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-webapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsWebappDeleteResponse> IntuneAppsWebappDeleteAsync(IntuneAppsWebappDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneAppsWebappDeleteParameter, IntuneAppsWebappDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-webapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsWebappDeleteResponse> IntuneAppsWebappDeleteAsync(IntuneAppsWebappDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsWebappDeleteParameter, IntuneAppsWebappDeleteResponse>(parameter, cancellationToken);
        }
    }
}
