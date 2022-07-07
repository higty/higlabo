using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingDevicemanagementexchangeconnectorCreateParameter : IRestApiParameter
    {
        public enum IntuneOnboardingDevicemanagementexchangeconnectorCreateParameterDeviceManagementExchangeConnectorStatus
        {
            None,
            ConnectionPending,
            Connected,
            Disconnected,
        }
        public enum IntuneOnboardingDevicemanagementexchangeconnectorCreateParameterDeviceManagementExchangeConnectorType
        {
            OnPremises,
            Hosted,
            ServiceToService,
            Dedicated,
        }
        public enum ApiPath
        {
            DeviceManagement_ExchangeConnectors,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_ExchangeConnectors: return $"/deviceManagement/exchangeConnectors";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public DateTimeOffset? LastSyncDateTime { get; set; }
        public IntuneOnboardingDevicemanagementexchangeconnectorCreateParameterDeviceManagementExchangeConnectorStatus Status { get; set; }
        public string? PrimarySmtpAddress { get; set; }
        public string? ServerName { get; set; }
        public string? ConnectorServerName { get; set; }
        public IntuneOnboardingDevicemanagementexchangeconnectorCreateParameterDeviceManagementExchangeConnectorType ExchangeConnectorType { get; set; }
        public string? Version { get; set; }
        public string? ExchangeAlias { get; set; }
        public string? ExchangeOrganization { get; set; }
    }
    public partial class IntuneOnboardingDevicemanagementexchangeconnectorCreateResponse : RestApiResponse
    {
        public enum DeviceManagementExchangeConnectorDeviceManagementExchangeConnectorStatus
        {
            None,
            ConnectionPending,
            Connected,
            Disconnected,
        }
        public enum DeviceManagementExchangeConnectorDeviceManagementExchangeConnectorType
        {
            OnPremises,
            Hosted,
            ServiceToService,
            Dedicated,
        }

        public string? Id { get; set; }
        public DateTimeOffset? LastSyncDateTime { get; set; }
        public DeviceManagementExchangeConnectorStatus? Status { get; set; }
        public string? PrimarySmtpAddress { get; set; }
        public string? ServerName { get; set; }
        public string? ConnectorServerName { get; set; }
        public DeviceManagementExchangeConnectorType? ExchangeConnectorType { get; set; }
        public string? Version { get; set; }
        public string? ExchangeAlias { get; set; }
        public string? ExchangeOrganization { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicemanagementexchangeconnector-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicemanagementexchangeconnectorCreateResponse> IntuneOnboardingDevicemanagementexchangeconnectorCreateAsync()
        {
            var p = new IntuneOnboardingDevicemanagementexchangeconnectorCreateParameter();
            return await this.SendAsync<IntuneOnboardingDevicemanagementexchangeconnectorCreateParameter, IntuneOnboardingDevicemanagementexchangeconnectorCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicemanagementexchangeconnector-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicemanagementexchangeconnectorCreateResponse> IntuneOnboardingDevicemanagementexchangeconnectorCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingDevicemanagementexchangeconnectorCreateParameter();
            return await this.SendAsync<IntuneOnboardingDevicemanagementexchangeconnectorCreateParameter, IntuneOnboardingDevicemanagementexchangeconnectorCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicemanagementexchangeconnector-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicemanagementexchangeconnectorCreateResponse> IntuneOnboardingDevicemanagementexchangeconnectorCreateAsync(IntuneOnboardingDevicemanagementexchangeconnectorCreateParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingDevicemanagementexchangeconnectorCreateParameter, IntuneOnboardingDevicemanagementexchangeconnectorCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicemanagementexchangeconnector-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicemanagementexchangeconnectorCreateResponse> IntuneOnboardingDevicemanagementexchangeconnectorCreateAsync(IntuneOnboardingDevicemanagementexchangeconnectorCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingDevicemanagementexchangeconnectorCreateParameter, IntuneOnboardingDevicemanagementexchangeconnectorCreateResponse>(parameter, cancellationToken);
        }
    }
}
