using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingUserDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Users_UsersId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Users_UsersId: return $"/users/{UsersId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string UsersId { get; set; }
    }
    public partial class IntuneOnboardingUserDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-user-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingUserDeleteResponse> IntuneOnboardingUserDeleteAsync()
        {
            var p = new IntuneOnboardingUserDeleteParameter();
            return await this.SendAsync<IntuneOnboardingUserDeleteParameter, IntuneOnboardingUserDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-user-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingUserDeleteResponse> IntuneOnboardingUserDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingUserDeleteParameter();
            return await this.SendAsync<IntuneOnboardingUserDeleteParameter, IntuneOnboardingUserDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-user-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingUserDeleteResponse> IntuneOnboardingUserDeleteAsync(IntuneOnboardingUserDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingUserDeleteParameter, IntuneOnboardingUserDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-user-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingUserDeleteResponse> IntuneOnboardingUserDeleteAsync(IntuneOnboardingUserDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingUserDeleteParameter, IntuneOnboardingUserDeleteResponse>(parameter, cancellationToken);
        }
    }
}
