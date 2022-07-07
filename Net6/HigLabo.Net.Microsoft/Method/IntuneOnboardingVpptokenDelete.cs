using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingVpptokenDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceAppManagement_VppTokens_VppTokenId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_VppTokens_VppTokenId: return $"/deviceAppManagement/vppTokens/{VppTokenId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string VppTokenId { get; set; }
    }
    public partial class IntuneOnboardingVpptokenDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-vpptoken-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingVpptokenDeleteResponse> IntuneOnboardingVpptokenDeleteAsync()
        {
            var p = new IntuneOnboardingVpptokenDeleteParameter();
            return await this.SendAsync<IntuneOnboardingVpptokenDeleteParameter, IntuneOnboardingVpptokenDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-vpptoken-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingVpptokenDeleteResponse> IntuneOnboardingVpptokenDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingVpptokenDeleteParameter();
            return await this.SendAsync<IntuneOnboardingVpptokenDeleteParameter, IntuneOnboardingVpptokenDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-vpptoken-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingVpptokenDeleteResponse> IntuneOnboardingVpptokenDeleteAsync(IntuneOnboardingVpptokenDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingVpptokenDeleteParameter, IntuneOnboardingVpptokenDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-vpptoken-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingVpptokenDeleteResponse> IntuneOnboardingVpptokenDeleteAsync(IntuneOnboardingVpptokenDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingVpptokenDeleteParameter, IntuneOnboardingVpptokenDeleteResponse>(parameter, cancellationToken);
        }
    }
}
