using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingMobilethreatdefenseconnectorListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_MobileThreatDefenseConnectors,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_MobileThreatDefenseConnectors: return $"/deviceManagement/mobileThreatDefenseConnectors";
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
    public partial class IntuneOnboardingMobilethreatdefenseconnectorListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-onboarding-mobilethreatdefenseconnector?view=graph-rest-1.0
        /// </summary>
        public partial class MobileThreatDefenseConnector
        {
            public enum MobileThreatDefenseConnectorMobileThreatPartnerTenantState
            {
                Unavailable,
                Available,
                Enabled,
                Unresponsive,
            }

            public string? Id { get; set; }
            public DateTimeOffset? LastHeartbeatDateTime { get; set; }
            public MobileThreatPartnerTenantState? PartnerState { get; set; }
            public bool? AndroidEnabled { get; set; }
            public bool? IosEnabled { get; set; }
            public bool? AndroidDeviceBlockedOnMissingPartnerData { get; set; }
            public bool? IosDeviceBlockedOnMissingPartnerData { get; set; }
            public bool? PartnerUnsupportedOsVersionBlocked { get; set; }
            public Int32? PartnerUnresponsivenessThresholdInDays { get; set; }
        }

        public MobileThreatDefenseConnector[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-mobilethreatdefenseconnector-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingMobilethreatdefenseconnectorListResponse> IntuneOnboardingMobilethreatdefenseconnectorListAsync()
        {
            var p = new IntuneOnboardingMobilethreatdefenseconnectorListParameter();
            return await this.SendAsync<IntuneOnboardingMobilethreatdefenseconnectorListParameter, IntuneOnboardingMobilethreatdefenseconnectorListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-mobilethreatdefenseconnector-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingMobilethreatdefenseconnectorListResponse> IntuneOnboardingMobilethreatdefenseconnectorListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingMobilethreatdefenseconnectorListParameter();
            return await this.SendAsync<IntuneOnboardingMobilethreatdefenseconnectorListParameter, IntuneOnboardingMobilethreatdefenseconnectorListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-mobilethreatdefenseconnector-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingMobilethreatdefenseconnectorListResponse> IntuneOnboardingMobilethreatdefenseconnectorListAsync(IntuneOnboardingMobilethreatdefenseconnectorListParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingMobilethreatdefenseconnectorListParameter, IntuneOnboardingMobilethreatdefenseconnectorListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-mobilethreatdefenseconnector-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingMobilethreatdefenseconnectorListResponse> IntuneOnboardingMobilethreatdefenseconnectorListAsync(IntuneOnboardingMobilethreatdefenseconnectorListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingMobilethreatdefenseconnectorListParameter, IntuneOnboardingMobilethreatdefenseconnectorListResponse>(parameter, cancellationToken);
        }
    }
}
