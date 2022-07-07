using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingMobilethreatdefenseconnectorGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_MobileThreatDefenseConnectors_MobileThreatDefenseConnectorId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_MobileThreatDefenseConnectors_MobileThreatDefenseConnectorId: return $"/deviceManagement/mobileThreatDefenseConnectors/{MobileThreatDefenseConnectorId}";
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
        public string MobileThreatDefenseConnectorId { get; set; }
    }
    public partial class IntuneOnboardingMobilethreatdefenseconnectorGetResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-mobilethreatdefenseconnector-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingMobilethreatdefenseconnectorGetResponse> IntuneOnboardingMobilethreatdefenseconnectorGetAsync()
        {
            var p = new IntuneOnboardingMobilethreatdefenseconnectorGetParameter();
            return await this.SendAsync<IntuneOnboardingMobilethreatdefenseconnectorGetParameter, IntuneOnboardingMobilethreatdefenseconnectorGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-mobilethreatdefenseconnector-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingMobilethreatdefenseconnectorGetResponse> IntuneOnboardingMobilethreatdefenseconnectorGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingMobilethreatdefenseconnectorGetParameter();
            return await this.SendAsync<IntuneOnboardingMobilethreatdefenseconnectorGetParameter, IntuneOnboardingMobilethreatdefenseconnectorGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-mobilethreatdefenseconnector-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingMobilethreatdefenseconnectorGetResponse> IntuneOnboardingMobilethreatdefenseconnectorGetAsync(IntuneOnboardingMobilethreatdefenseconnectorGetParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingMobilethreatdefenseconnectorGetParameter, IntuneOnboardingMobilethreatdefenseconnectorGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-mobilethreatdefenseconnector-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingMobilethreatdefenseconnectorGetResponse> IntuneOnboardingMobilethreatdefenseconnectorGetAsync(IntuneOnboardingMobilethreatdefenseconnectorGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingMobilethreatdefenseconnectorGetParameter, IntuneOnboardingMobilethreatdefenseconnectorGetResponse>(parameter, cancellationToken);
        }
    }
}
