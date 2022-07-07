using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingDevicemanagementexchangeconnectorListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
    }
    public partial class IntuneOnboardingDevicemanagementexchangeconnectorListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-onboarding-devicemanagementexchangeconnector?view=graph-rest-1.0
        /// </summary>
        public partial class DeviceManagementExchangeConnector
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

        public DeviceManagementExchangeConnector[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicemanagementexchangeconnector-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicemanagementexchangeconnectorListResponse> IntuneOnboardingDevicemanagementexchangeconnectorListAsync()
        {
            var p = new IntuneOnboardingDevicemanagementexchangeconnectorListParameter();
            return await this.SendAsync<IntuneOnboardingDevicemanagementexchangeconnectorListParameter, IntuneOnboardingDevicemanagementexchangeconnectorListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicemanagementexchangeconnector-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicemanagementexchangeconnectorListResponse> IntuneOnboardingDevicemanagementexchangeconnectorListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingDevicemanagementexchangeconnectorListParameter();
            return await this.SendAsync<IntuneOnboardingDevicemanagementexchangeconnectorListParameter, IntuneOnboardingDevicemanagementexchangeconnectorListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicemanagementexchangeconnector-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicemanagementexchangeconnectorListResponse> IntuneOnboardingDevicemanagementexchangeconnectorListAsync(IntuneOnboardingDevicemanagementexchangeconnectorListParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingDevicemanagementexchangeconnectorListParameter, IntuneOnboardingDevicemanagementexchangeconnectorListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicemanagementexchangeconnector-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicemanagementexchangeconnectorListResponse> IntuneOnboardingDevicemanagementexchangeconnectorListAsync(IntuneOnboardingDevicemanagementexchangeconnectorListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingDevicemanagementexchangeconnectorListParameter, IntuneOnboardingDevicemanagementexchangeconnectorListResponse>(parameter, cancellationToken);
        }
    }
}
