using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsIosstoreappDeleteParameter : IRestApiParameter
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
    public partial class IntuneAppsIosstoreappDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-iosstoreapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsIosstoreappDeleteResponse> IntuneAppsIosstoreappDeleteAsync()
        {
            var p = new IntuneAppsIosstoreappDeleteParameter();
            return await this.SendAsync<IntuneAppsIosstoreappDeleteParameter, IntuneAppsIosstoreappDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-iosstoreapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsIosstoreappDeleteResponse> IntuneAppsIosstoreappDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsIosstoreappDeleteParameter();
            return await this.SendAsync<IntuneAppsIosstoreappDeleteParameter, IntuneAppsIosstoreappDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-iosstoreapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsIosstoreappDeleteResponse> IntuneAppsIosstoreappDeleteAsync(IntuneAppsIosstoreappDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneAppsIosstoreappDeleteParameter, IntuneAppsIosstoreappDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-iosstoreapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsIosstoreappDeleteResponse> IntuneAppsIosstoreappDeleteAsync(IntuneAppsIosstoreappDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsIosstoreappDeleteParameter, IntuneAppsIosstoreappDeleteResponse>(parameter, cancellationToken);
        }
    }
}
