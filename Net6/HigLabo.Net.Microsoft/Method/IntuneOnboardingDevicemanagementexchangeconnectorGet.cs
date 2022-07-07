using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingDevicemanagementexchangeconnectorGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string DeviceManagementExchangeConnectorId { get; set; }
    }
    public partial class IntuneOnboardingDevicemanagementexchangeconnectorGetResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicemanagementexchangeconnector-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicemanagementexchangeconnectorGetResponse> IntuneOnboardingDevicemanagementexchangeconnectorGetAsync()
        {
            var p = new IntuneOnboardingDevicemanagementexchangeconnectorGetParameter();
            return await this.SendAsync<IntuneOnboardingDevicemanagementexchangeconnectorGetParameter, IntuneOnboardingDevicemanagementexchangeconnectorGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicemanagementexchangeconnector-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicemanagementexchangeconnectorGetResponse> IntuneOnboardingDevicemanagementexchangeconnectorGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingDevicemanagementexchangeconnectorGetParameter();
            return await this.SendAsync<IntuneOnboardingDevicemanagementexchangeconnectorGetParameter, IntuneOnboardingDevicemanagementexchangeconnectorGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicemanagementexchangeconnector-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicemanagementexchangeconnectorGetResponse> IntuneOnboardingDevicemanagementexchangeconnectorGetAsync(IntuneOnboardingDevicemanagementexchangeconnectorGetParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingDevicemanagementexchangeconnectorGetParameter, IntuneOnboardingDevicemanagementexchangeconnectorGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicemanagementexchangeconnector-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicemanagementexchangeconnectorGetResponse> IntuneOnboardingDevicemanagementexchangeconnectorGetAsync(IntuneOnboardingDevicemanagementexchangeconnectorGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingDevicemanagementexchangeconnectorGetParameter, IntuneOnboardingDevicemanagementexchangeconnectorGetResponse>(parameter, cancellationToken);
        }
    }
}
