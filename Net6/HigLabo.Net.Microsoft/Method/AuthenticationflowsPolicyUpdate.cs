using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AuthenticationflowsPolicyUpdateParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public SelfServiceSignUpAuthenticationFlowConfiguration? SelfServiceSignUp { get; set; }
    }
    public partial class AuthenticationflowsPolicyUpdateResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/authenticationflowspolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthenticationflowsPolicyUpdateResponse> AuthenticationflowsPolicyUpdateAsync()
        {
            var p = new AuthenticationflowsPolicyUpdateParameter();
            return await this.SendAsync<AuthenticationflowsPolicyUpdateParameter, AuthenticationflowsPolicyUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/authenticationflowspolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthenticationflowsPolicyUpdateResponse> AuthenticationflowsPolicyUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new AuthenticationflowsPolicyUpdateParameter();
            return await this.SendAsync<AuthenticationflowsPolicyUpdateParameter, AuthenticationflowsPolicyUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/authenticationflowspolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthenticationflowsPolicyUpdateResponse> AuthenticationflowsPolicyUpdateAsync(AuthenticationflowsPolicyUpdateParameter parameter)
        {
            return await this.SendAsync<AuthenticationflowsPolicyUpdateParameter, AuthenticationflowsPolicyUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/authenticationflowspolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthenticationflowsPolicyUpdateResponse> AuthenticationflowsPolicyUpdateAsync(AuthenticationflowsPolicyUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AuthenticationflowsPolicyUpdateParameter, AuthenticationflowsPolicyUpdateResponse>(parameter, cancellationToken);
        }
    }
}
