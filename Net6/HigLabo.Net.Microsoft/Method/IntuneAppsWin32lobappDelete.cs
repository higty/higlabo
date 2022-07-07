using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsWin32lobappDeleteParameter : IRestApiParameter
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
    public partial class IntuneAppsWin32lobappDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-win32lobapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsWin32lobappDeleteResponse> IntuneAppsWin32lobappDeleteAsync()
        {
            var p = new IntuneAppsWin32lobappDeleteParameter();
            return await this.SendAsync<IntuneAppsWin32lobappDeleteParameter, IntuneAppsWin32lobappDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-win32lobapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsWin32lobappDeleteResponse> IntuneAppsWin32lobappDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsWin32lobappDeleteParameter();
            return await this.SendAsync<IntuneAppsWin32lobappDeleteParameter, IntuneAppsWin32lobappDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-win32lobapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsWin32lobappDeleteResponse> IntuneAppsWin32lobappDeleteAsync(IntuneAppsWin32lobappDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneAppsWin32lobappDeleteParameter, IntuneAppsWin32lobappDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-win32lobapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsWin32lobappDeleteResponse> IntuneAppsWin32lobappDeleteAsync(IntuneAppsWin32lobappDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsWin32lobappDeleteParameter, IntuneAppsWin32lobappDeleteResponse>(parameter, cancellationToken);
        }
    }
}
