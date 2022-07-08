using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AuthenticationmethodsPolicyUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_AuthenticationMethodsPolicy: return $"/policies/authenticationMethodsPolicy";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Policies_AuthenticationMethodsPolicy,
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
    }
    public partial class AuthenticationmethodsPolicyUpdateResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/authenticationmethodspolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthenticationmethodsPolicyUpdateResponse> AuthenticationmethodsPolicyUpdateAsync()
        {
            var p = new AuthenticationmethodsPolicyUpdateParameter();
            return await this.SendAsync<AuthenticationmethodsPolicyUpdateParameter, AuthenticationmethodsPolicyUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/authenticationmethodspolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthenticationmethodsPolicyUpdateResponse> AuthenticationmethodsPolicyUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new AuthenticationmethodsPolicyUpdateParameter();
            return await this.SendAsync<AuthenticationmethodsPolicyUpdateParameter, AuthenticationmethodsPolicyUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/authenticationmethodspolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthenticationmethodsPolicyUpdateResponse> AuthenticationmethodsPolicyUpdateAsync(AuthenticationmethodsPolicyUpdateParameter parameter)
        {
            return await this.SendAsync<AuthenticationmethodsPolicyUpdateParameter, AuthenticationmethodsPolicyUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/authenticationmethodspolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthenticationmethodsPolicyUpdateResponse> AuthenticationmethodsPolicyUpdateAsync(AuthenticationmethodsPolicyUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AuthenticationmethodsPolicyUpdateParameter, AuthenticationmethodsPolicyUpdateResponse>(parameter, cancellationToken);
        }
    }
}
