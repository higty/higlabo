using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AuthenticationmethodspolicyGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Policies_AuthenticationMethodsPolicy,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Policies_AuthenticationMethodsPolicy: return $"/policies/authenticationMethodsPolicy";
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
    public partial class AuthenticationmethodspolicyGetResponse : RestApiResponse
    {
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string? PolicyVersion { get; set; }
        public RegistrationEnforcement? RegistrationEnforcement { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/authenticationmethodspolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthenticationmethodspolicyGetResponse> AuthenticationmethodspolicyGetAsync()
        {
            var p = new AuthenticationmethodspolicyGetParameter();
            return await this.SendAsync<AuthenticationmethodspolicyGetParameter, AuthenticationmethodspolicyGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/authenticationmethodspolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthenticationmethodspolicyGetResponse> AuthenticationmethodspolicyGetAsync(CancellationToken cancellationToken)
        {
            var p = new AuthenticationmethodspolicyGetParameter();
            return await this.SendAsync<AuthenticationmethodspolicyGetParameter, AuthenticationmethodspolicyGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/authenticationmethodspolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthenticationmethodspolicyGetResponse> AuthenticationmethodspolicyGetAsync(AuthenticationmethodspolicyGetParameter parameter)
        {
            return await this.SendAsync<AuthenticationmethodspolicyGetParameter, AuthenticationmethodspolicyGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/authenticationmethodspolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthenticationmethodspolicyGetResponse> AuthenticationmethodspolicyGetAsync(AuthenticationmethodspolicyGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AuthenticationmethodspolicyGetParameter, AuthenticationmethodspolicyGetResponse>(parameter, cancellationToken);
        }
    }
}
