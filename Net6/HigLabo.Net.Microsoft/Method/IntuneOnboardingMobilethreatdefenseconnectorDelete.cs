using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingMobilethreatdefenseconnectorDeleteParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string MobileThreatDefenseConnectorId { get; set; }
    }
    public partial class IntuneOnboardingMobilethreatdefenseconnectorDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-mobilethreatdefenseconnector-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingMobilethreatdefenseconnectorDeleteResponse> IntuneOnboardingMobilethreatdefenseconnectorDeleteAsync()
        {
            var p = new IntuneOnboardingMobilethreatdefenseconnectorDeleteParameter();
            return await this.SendAsync<IntuneOnboardingMobilethreatdefenseconnectorDeleteParameter, IntuneOnboardingMobilethreatdefenseconnectorDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-mobilethreatdefenseconnector-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingMobilethreatdefenseconnectorDeleteResponse> IntuneOnboardingMobilethreatdefenseconnectorDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingMobilethreatdefenseconnectorDeleteParameter();
            return await this.SendAsync<IntuneOnboardingMobilethreatdefenseconnectorDeleteParameter, IntuneOnboardingMobilethreatdefenseconnectorDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-mobilethreatdefenseconnector-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingMobilethreatdefenseconnectorDeleteResponse> IntuneOnboardingMobilethreatdefenseconnectorDeleteAsync(IntuneOnboardingMobilethreatdefenseconnectorDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingMobilethreatdefenseconnectorDeleteParameter, IntuneOnboardingMobilethreatdefenseconnectorDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-mobilethreatdefenseconnector-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingMobilethreatdefenseconnectorDeleteResponse> IntuneOnboardingMobilethreatdefenseconnectorDeleteAsync(IntuneOnboardingMobilethreatdefenseconnectorDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingMobilethreatdefenseconnectorDeleteParameter, IntuneOnboardingMobilethreatdefenseconnectorDeleteResponse>(parameter, cancellationToken);
        }
    }
}
