using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsIosmobileappconfigurationDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceAppManagement_MobileAppConfigurations_ManagedDeviceMobileAppConfigurationId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_MobileAppConfigurations_ManagedDeviceMobileAppConfigurationId: return $"/deviceAppManagement/mobileAppConfigurations/{ManagedDeviceMobileAppConfigurationId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string ManagedDeviceMobileAppConfigurationId { get; set; }
    }
    public partial class IntuneAppsIosmobileappconfigurationDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-iosmobileappconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsIosmobileappconfigurationDeleteResponse> IntuneAppsIosmobileappconfigurationDeleteAsync()
        {
            var p = new IntuneAppsIosmobileappconfigurationDeleteParameter();
            return await this.SendAsync<IntuneAppsIosmobileappconfigurationDeleteParameter, IntuneAppsIosmobileappconfigurationDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-iosmobileappconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsIosmobileappconfigurationDeleteResponse> IntuneAppsIosmobileappconfigurationDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsIosmobileappconfigurationDeleteParameter();
            return await this.SendAsync<IntuneAppsIosmobileappconfigurationDeleteParameter, IntuneAppsIosmobileappconfigurationDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-iosmobileappconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsIosmobileappconfigurationDeleteResponse> IntuneAppsIosmobileappconfigurationDeleteAsync(IntuneAppsIosmobileappconfigurationDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneAppsIosmobileappconfigurationDeleteParameter, IntuneAppsIosmobileappconfigurationDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-iosmobileappconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsIosmobileappconfigurationDeleteResponse> IntuneAppsIosmobileappconfigurationDeleteAsync(IntuneAppsIosmobileappconfigurationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsIosmobileappconfigurationDeleteParameter, IntuneAppsIosmobileappconfigurationDeleteResponse>(parameter, cancellationToken);
        }
    }
}
