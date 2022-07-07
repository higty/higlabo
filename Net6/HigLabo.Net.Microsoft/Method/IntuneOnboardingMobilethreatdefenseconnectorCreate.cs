using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingMobilethreatdefenseconnectorCreateParameter : IRestApiParameter
    {
        public enum IntuneOnboardingMobilethreatdefenseconnectorCreateParameterMobileThreatPartnerTenantState
        {
            Unavailable,
            Available,
            Enabled,
            Unresponsive,
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public DateTimeOffset? LastHeartbeatDateTime { get; set; }
        public IntuneOnboardingMobilethreatdefenseconnectorCreateParameterMobileThreatPartnerTenantState PartnerState { get; set; }
        public bool? AndroidEnabled { get; set; }
        public bool? IosEnabled { get; set; }
        public bool? AndroidDeviceBlockedOnMissingPartnerData { get; set; }
        public bool? IosDeviceBlockedOnMissingPartnerData { get; set; }
        public bool? PartnerUnsupportedOsVersionBlocked { get; set; }
        public Int32? PartnerUnresponsivenessThresholdInDays { get; set; }
    }
    public partial class IntuneOnboardingMobilethreatdefenseconnectorCreateResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-mobilethreatdefenseconnector-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingMobilethreatdefenseconnectorCreateResponse> IntuneOnboardingMobilethreatdefenseconnectorCreateAsync()
        {
            var p = new IntuneOnboardingMobilethreatdefenseconnectorCreateParameter();
            return await this.SendAsync<IntuneOnboardingMobilethreatdefenseconnectorCreateParameter, IntuneOnboardingMobilethreatdefenseconnectorCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-mobilethreatdefenseconnector-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingMobilethreatdefenseconnectorCreateResponse> IntuneOnboardingMobilethreatdefenseconnectorCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingMobilethreatdefenseconnectorCreateParameter();
            return await this.SendAsync<IntuneOnboardingMobilethreatdefenseconnectorCreateParameter, IntuneOnboardingMobilethreatdefenseconnectorCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-mobilethreatdefenseconnector-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingMobilethreatdefenseconnectorCreateResponse> IntuneOnboardingMobilethreatdefenseconnectorCreateAsync(IntuneOnboardingMobilethreatdefenseconnectorCreateParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingMobilethreatdefenseconnectorCreateParameter, IntuneOnboardingMobilethreatdefenseconnectorCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-mobilethreatdefenseconnector-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingMobilethreatdefenseconnectorCreateResponse> IntuneOnboardingMobilethreatdefenseconnectorCreateAsync(IntuneOnboardingMobilethreatdefenseconnectorCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingMobilethreatdefenseconnectorCreateParameter, IntuneOnboardingMobilethreatdefenseconnectorCreateResponse>(parameter, cancellationToken);
        }
    }
}
