using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingDevicemanagementexchangeconnectorDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_ExchangeConnectors_DeviceManagementExchangeConnectorId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_ExchangeConnectors_DeviceManagementExchangeConnectorId: return $"/deviceManagement/exchangeConnectors/{DeviceManagementExchangeConnectorId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string DeviceManagementExchangeConnectorId { get; set; }
    }
    public partial class IntuneOnboardingDevicemanagementexchangeconnectorDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicemanagementexchangeconnector-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicemanagementexchangeconnectorDeleteResponse> IntuneOnboardingDevicemanagementexchangeconnectorDeleteAsync()
        {
            var p = new IntuneOnboardingDevicemanagementexchangeconnectorDeleteParameter();
            return await this.SendAsync<IntuneOnboardingDevicemanagementexchangeconnectorDeleteParameter, IntuneOnboardingDevicemanagementexchangeconnectorDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicemanagementexchangeconnector-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicemanagementexchangeconnectorDeleteResponse> IntuneOnboardingDevicemanagementexchangeconnectorDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingDevicemanagementexchangeconnectorDeleteParameter();
            return await this.SendAsync<IntuneOnboardingDevicemanagementexchangeconnectorDeleteParameter, IntuneOnboardingDevicemanagementexchangeconnectorDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicemanagementexchangeconnector-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicemanagementexchangeconnectorDeleteResponse> IntuneOnboardingDevicemanagementexchangeconnectorDeleteAsync(IntuneOnboardingDevicemanagementexchangeconnectorDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingDevicemanagementexchangeconnectorDeleteParameter, IntuneOnboardingDevicemanagementexchangeconnectorDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicemanagementexchangeconnector-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicemanagementexchangeconnectorDeleteResponse> IntuneOnboardingDevicemanagementexchangeconnectorDeleteAsync(IntuneOnboardingDevicemanagementexchangeconnectorDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingDevicemanagementexchangeconnectorDeleteParameter, IntuneOnboardingDevicemanagementexchangeconnectorDeleteResponse>(parameter, cancellationToken);
        }
    }
}
