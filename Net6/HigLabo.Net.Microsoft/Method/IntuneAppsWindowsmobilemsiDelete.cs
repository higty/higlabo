using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsWindowsmobilemsiDeleteParameter : IRestApiParameter
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
    public partial class IntuneAppsWindowsmobilemsiDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-windowsmobilemsi-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsWindowsmobilemsiDeleteResponse> IntuneAppsWindowsmobilemsiDeleteAsync()
        {
            var p = new IntuneAppsWindowsmobilemsiDeleteParameter();
            return await this.SendAsync<IntuneAppsWindowsmobilemsiDeleteParameter, IntuneAppsWindowsmobilemsiDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-windowsmobilemsi-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsWindowsmobilemsiDeleteResponse> IntuneAppsWindowsmobilemsiDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsWindowsmobilemsiDeleteParameter();
            return await this.SendAsync<IntuneAppsWindowsmobilemsiDeleteParameter, IntuneAppsWindowsmobilemsiDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-windowsmobilemsi-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsWindowsmobilemsiDeleteResponse> IntuneAppsWindowsmobilemsiDeleteAsync(IntuneAppsWindowsmobilemsiDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneAppsWindowsmobilemsiDeleteParameter, IntuneAppsWindowsmobilemsiDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-windowsmobilemsi-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsWindowsmobilemsiDeleteResponse> IntuneAppsWindowsmobilemsiDeleteAsync(IntuneAppsWindowsmobilemsiDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsWindowsmobilemsiDeleteParameter, IntuneAppsWindowsmobilemsiDeleteResponse>(parameter, cancellationToken);
        }
    }
}
