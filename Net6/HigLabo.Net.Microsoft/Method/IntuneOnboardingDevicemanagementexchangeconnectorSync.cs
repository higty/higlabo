using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingDevicemanagementexchangeconnectorSyncParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_ExchangeConnectors_DeviceManagementExchangeConnectorId_Sync,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_ExchangeConnectors_DeviceManagementExchangeConnectorId_Sync: return $"/deviceManagement/exchangeConnectors/{DeviceManagementExchangeConnectorId}/sync";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public DeviceManagementExchangeConnectorSyncType? SyncType { get; set; }
        public string DeviceManagementExchangeConnectorId { get; set; }
    }
    public partial class IntuneOnboardingDevicemanagementexchangeconnectorSyncResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicemanagementexchangeconnector-sync?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicemanagementexchangeconnectorSyncResponse> IntuneOnboardingDevicemanagementexchangeconnectorSyncAsync()
        {
            var p = new IntuneOnboardingDevicemanagementexchangeconnectorSyncParameter();
            return await this.SendAsync<IntuneOnboardingDevicemanagementexchangeconnectorSyncParameter, IntuneOnboardingDevicemanagementexchangeconnectorSyncResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicemanagementexchangeconnector-sync?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicemanagementexchangeconnectorSyncResponse> IntuneOnboardingDevicemanagementexchangeconnectorSyncAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingDevicemanagementexchangeconnectorSyncParameter();
            return await this.SendAsync<IntuneOnboardingDevicemanagementexchangeconnectorSyncParameter, IntuneOnboardingDevicemanagementexchangeconnectorSyncResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicemanagementexchangeconnector-sync?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicemanagementexchangeconnectorSyncResponse> IntuneOnboardingDevicemanagementexchangeconnectorSyncAsync(IntuneOnboardingDevicemanagementexchangeconnectorSyncParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingDevicemanagementexchangeconnectorSyncParameter, IntuneOnboardingDevicemanagementexchangeconnectorSyncResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicemanagementexchangeconnector-sync?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicemanagementexchangeconnectorSyncResponse> IntuneOnboardingDevicemanagementexchangeconnectorSyncAsync(IntuneOnboardingDevicemanagementexchangeconnectorSyncParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingDevicemanagementexchangeconnectorSyncParameter, IntuneOnboardingDevicemanagementexchangeconnectorSyncResponse>(parameter, cancellationToken);
        }
    }
}
