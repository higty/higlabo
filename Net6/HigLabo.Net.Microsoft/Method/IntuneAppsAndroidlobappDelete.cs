using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsAndroidlobappDeleteParameter : IRestApiParameter
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
    public partial class IntuneAppsAndroidlobappDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-androidlobapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsAndroidlobappDeleteResponse> IntuneAppsAndroidlobappDeleteAsync()
        {
            var p = new IntuneAppsAndroidlobappDeleteParameter();
            return await this.SendAsync<IntuneAppsAndroidlobappDeleteParameter, IntuneAppsAndroidlobappDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-androidlobapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsAndroidlobappDeleteResponse> IntuneAppsAndroidlobappDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsAndroidlobappDeleteParameter();
            return await this.SendAsync<IntuneAppsAndroidlobappDeleteParameter, IntuneAppsAndroidlobappDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-androidlobapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsAndroidlobappDeleteResponse> IntuneAppsAndroidlobappDeleteAsync(IntuneAppsAndroidlobappDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneAppsAndroidlobappDeleteParameter, IntuneAppsAndroidlobappDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-androidlobapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsAndroidlobappDeleteResponse> IntuneAppsAndroidlobappDeleteAsync(IntuneAppsAndroidlobappDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsAndroidlobappDeleteParameter, IntuneAppsAndroidlobappDeleteResponse>(parameter, cancellationToken);
        }
    }
}
