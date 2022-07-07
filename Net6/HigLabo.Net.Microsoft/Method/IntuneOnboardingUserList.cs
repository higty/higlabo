using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingUserListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
    public partial class IntuneOnboardingUserListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-onboarding-user?view=graph-rest-1.0
        /// </summary>
        public partial class User
        {
            public string? Id { get; set; }
            public Int32? DeviceEnrollmentLimit { get; set; }
        }

        public User[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-user-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingUserListResponse> IntuneOnboardingUserListAsync()
        {
            var p = new IntuneOnboardingUserListParameter();
            return await this.SendAsync<IntuneOnboardingUserListParameter, IntuneOnboardingUserListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-user-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingUserListResponse> IntuneOnboardingUserListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingUserListParameter();
            return await this.SendAsync<IntuneOnboardingUserListParameter, IntuneOnboardingUserListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-user-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingUserListResponse> IntuneOnboardingUserListAsync(IntuneOnboardingUserListParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingUserListParameter, IntuneOnboardingUserListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-user-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingUserListResponse> IntuneOnboardingUserListAsync(IntuneOnboardingUserListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingUserListParameter, IntuneOnboardingUserListResponse>(parameter, cancellationToken);
        }
    }
}
