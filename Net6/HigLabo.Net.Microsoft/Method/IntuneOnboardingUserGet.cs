using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingUserGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string UsersId { get; set; }
    }
    public partial class IntuneOnboardingUserGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public Int32? DeviceEnrollmentLimit { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-user-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingUserGetResponse> IntuneOnboardingUserGetAsync()
        {
            var p = new IntuneOnboardingUserGetParameter();
            return await this.SendAsync<IntuneOnboardingUserGetParameter, IntuneOnboardingUserGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-user-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingUserGetResponse> IntuneOnboardingUserGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingUserGetParameter();
            return await this.SendAsync<IntuneOnboardingUserGetParameter, IntuneOnboardingUserGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-user-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingUserGetResponse> IntuneOnboardingUserGetAsync(IntuneOnboardingUserGetParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingUserGetParameter, IntuneOnboardingUserGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-user-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingUserGetResponse> IntuneOnboardingUserGetAsync(IntuneOnboardingUserGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingUserGetParameter, IntuneOnboardingUserGetResponse>(parameter, cancellationToken);
        }
    }
}
