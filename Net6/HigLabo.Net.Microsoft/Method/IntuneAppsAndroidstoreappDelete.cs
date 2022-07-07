using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsAndroidstoreappDeleteParameter : IRestApiParameter
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
    public partial class IntuneAppsAndroidstoreappDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-androidstoreapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsAndroidstoreappDeleteResponse> IntuneAppsAndroidstoreappDeleteAsync()
        {
            var p = new IntuneAppsAndroidstoreappDeleteParameter();
            return await this.SendAsync<IntuneAppsAndroidstoreappDeleteParameter, IntuneAppsAndroidstoreappDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-androidstoreapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsAndroidstoreappDeleteResponse> IntuneAppsAndroidstoreappDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsAndroidstoreappDeleteParameter();
            return await this.SendAsync<IntuneAppsAndroidstoreappDeleteParameter, IntuneAppsAndroidstoreappDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-androidstoreapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsAndroidstoreappDeleteResponse> IntuneAppsAndroidstoreappDeleteAsync(IntuneAppsAndroidstoreappDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneAppsAndroidstoreappDeleteParameter, IntuneAppsAndroidstoreappDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-androidstoreapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsAndroidstoreappDeleteResponse> IntuneAppsAndroidstoreappDeleteAsync(IntuneAppsAndroidstoreappDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsAndroidstoreappDeleteParameter, IntuneAppsAndroidstoreappDeleteResponse>(parameter, cancellationToken);
        }
    }
}
