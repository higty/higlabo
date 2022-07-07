using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsWindowsuniversalappxDeleteParameter : IRestApiParameter
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
    public partial class IntuneAppsWindowsuniversalappxDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-windowsuniversalappx-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsWindowsuniversalappxDeleteResponse> IntuneAppsWindowsuniversalappxDeleteAsync()
        {
            var p = new IntuneAppsWindowsuniversalappxDeleteParameter();
            return await this.SendAsync<IntuneAppsWindowsuniversalappxDeleteParameter, IntuneAppsWindowsuniversalappxDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-windowsuniversalappx-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsWindowsuniversalappxDeleteResponse> IntuneAppsWindowsuniversalappxDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsWindowsuniversalappxDeleteParameter();
            return await this.SendAsync<IntuneAppsWindowsuniversalappxDeleteParameter, IntuneAppsWindowsuniversalappxDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-windowsuniversalappx-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsWindowsuniversalappxDeleteResponse> IntuneAppsWindowsuniversalappxDeleteAsync(IntuneAppsWindowsuniversalappxDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneAppsWindowsuniversalappxDeleteParameter, IntuneAppsWindowsuniversalappxDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-windowsuniversalappx-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsWindowsuniversalappxDeleteResponse> IntuneAppsWindowsuniversalappxDeleteAsync(IntuneAppsWindowsuniversalappxDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsWindowsuniversalappxDeleteParameter, IntuneAppsWindowsuniversalappxDeleteResponse>(parameter, cancellationToken);
        }
    }
}
