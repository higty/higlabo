using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsIosvppappDeleteParameter : IRestApiParameter
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
    public partial class IntuneAppsIosvppappDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-iosvppapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsIosvppappDeleteResponse> IntuneAppsIosvppappDeleteAsync()
        {
            var p = new IntuneAppsIosvppappDeleteParameter();
            return await this.SendAsync<IntuneAppsIosvppappDeleteParameter, IntuneAppsIosvppappDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-iosvppapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsIosvppappDeleteResponse> IntuneAppsIosvppappDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsIosvppappDeleteParameter();
            return await this.SendAsync<IntuneAppsIosvppappDeleteParameter, IntuneAppsIosvppappDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-iosvppapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsIosvppappDeleteResponse> IntuneAppsIosvppappDeleteAsync(IntuneAppsIosvppappDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneAppsIosvppappDeleteParameter, IntuneAppsIosvppappDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-iosvppapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsIosvppappDeleteResponse> IntuneAppsIosvppappDeleteAsync(IntuneAppsIosvppappDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsIosvppappDeleteParameter, IntuneAppsIosvppappDeleteResponse>(parameter, cancellationToken);
        }
    }
}
