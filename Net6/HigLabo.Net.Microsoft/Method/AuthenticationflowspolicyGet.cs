using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AuthenticationflowspolicyGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Policies_AuthenticationFlowsPolicy,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Policies_AuthenticationFlowsPolicy: return $"/policies/authenticationFlowsPolicy";
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
    public partial class AuthenticationflowspolicyGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public SelfServiceSignUpAuthenticationFlowConfiguration? SelfServiceSignUp { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/authenticationflowspolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthenticationflowspolicyGetResponse> AuthenticationflowspolicyGetAsync()
        {
            var p = new AuthenticationflowspolicyGetParameter();
            return await this.SendAsync<AuthenticationflowspolicyGetParameter, AuthenticationflowspolicyGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/authenticationflowspolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthenticationflowspolicyGetResponse> AuthenticationflowspolicyGetAsync(CancellationToken cancellationToken)
        {
            var p = new AuthenticationflowspolicyGetParameter();
            return await this.SendAsync<AuthenticationflowspolicyGetParameter, AuthenticationflowspolicyGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/authenticationflowspolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthenticationflowspolicyGetResponse> AuthenticationflowspolicyGetAsync(AuthenticationflowspolicyGetParameter parameter)
        {
            return await this.SendAsync<AuthenticationflowspolicyGetParameter, AuthenticationflowspolicyGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/authenticationflowspolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthenticationflowspolicyGetResponse> AuthenticationflowspolicyGetAsync(AuthenticationflowspolicyGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AuthenticationflowspolicyGetParameter, AuthenticationflowspolicyGetResponse>(parameter, cancellationToken);
        }
    }
}
