using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingUserCreateParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Users,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Users: return $"/users";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public Int32? DeviceEnrollmentLimit { get; set; }
    }
    public partial class IntuneOnboardingUserCreateResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public Int32? DeviceEnrollmentLimit { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-user-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingUserCreateResponse> IntuneOnboardingUserCreateAsync()
        {
            var p = new IntuneOnboardingUserCreateParameter();
            return await this.SendAsync<IntuneOnboardingUserCreateParameter, IntuneOnboardingUserCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-user-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingUserCreateResponse> IntuneOnboardingUserCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingUserCreateParameter();
            return await this.SendAsync<IntuneOnboardingUserCreateParameter, IntuneOnboardingUserCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-user-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingUserCreateResponse> IntuneOnboardingUserCreateAsync(IntuneOnboardingUserCreateParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingUserCreateParameter, IntuneOnboardingUserCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-user-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingUserCreateResponse> IntuneOnboardingUserCreateAsync(IntuneOnboardingUserCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingUserCreateParameter, IntuneOnboardingUserCreateResponse>(parameter, cancellationToken);
        }
    }
}
