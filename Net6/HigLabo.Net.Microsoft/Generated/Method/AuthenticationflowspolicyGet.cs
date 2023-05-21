using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationflowspolicy-get?view=graph-rest-1.0
    /// </summary>
    public partial class AuthenticationflowsPolicyGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_AuthenticationFlowsPolicy: return $"/policies/authenticationFlowsPolicy";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Policies_AuthenticationFlowsPolicy,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
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
    public partial class AuthenticationflowsPolicyGetResponse : RestApiResponse
    {
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public SelfServiceSignUpAuthenticationFlowConfiguration? SelfServiceSignUp { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationflowspolicy-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authenticationflowspolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthenticationflowsPolicyGetResponse> AuthenticationflowsPolicyGetAsync()
        {
            var p = new AuthenticationflowsPolicyGetParameter();
            return await this.SendAsync<AuthenticationflowsPolicyGetParameter, AuthenticationflowsPolicyGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authenticationflowspolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthenticationflowsPolicyGetResponse> AuthenticationflowsPolicyGetAsync(CancellationToken cancellationToken)
        {
            var p = new AuthenticationflowsPolicyGetParameter();
            return await this.SendAsync<AuthenticationflowsPolicyGetParameter, AuthenticationflowsPolicyGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authenticationflowspolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthenticationflowsPolicyGetResponse> AuthenticationflowsPolicyGetAsync(AuthenticationflowsPolicyGetParameter parameter)
        {
            return await this.SendAsync<AuthenticationflowsPolicyGetParameter, AuthenticationflowsPolicyGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authenticationflowspolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthenticationflowsPolicyGetResponse> AuthenticationflowsPolicyGetAsync(AuthenticationflowsPolicyGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AuthenticationflowsPolicyGetParameter, AuthenticationflowsPolicyGetResponse>(parameter, cancellationToken);
        }
    }
}
