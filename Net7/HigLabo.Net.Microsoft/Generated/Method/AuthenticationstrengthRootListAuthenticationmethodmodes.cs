using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationstrengthroot-list-authenticationmethodmodes?view=graph-rest-1.0
    /// </summary>
    public partial class AuthenticationstrengthRootListAuthenticationmethodmodesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Identity_ConditionalAccess_AuthenticationStrength_AuthenticationMethodModes: return $"/identity/conditionalAccess/authenticationStrength/authenticationMethodModes";
                    case ApiPath.Identity_ConditionalAccess_AuthenticationStrength_Combinations: return $"/identity/conditionalAccess/authenticationStrength/combinations";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            AuthenticationMethod,
            DisplayName,
            Id,
        }
        public enum ApiPath
        {
            Identity_ConditionalAccess_AuthenticationStrength_AuthenticationMethodModes,
            Identity_ConditionalAccess_AuthenticationStrength_Combinations,
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
    public partial class AuthenticationstrengthRootListAuthenticationmethodmodesResponse : RestApiResponse
    {
        public AuthenticationMethodModeDetail[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationstrengthroot-list-authenticationmethodmodes?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authenticationstrengthroot-list-authenticationmethodmodes?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthenticationstrengthRootListAuthenticationmethodmodesResponse> AuthenticationstrengthRootListAuthenticationmethodmodesAsync()
        {
            var p = new AuthenticationstrengthRootListAuthenticationmethodmodesParameter();
            return await this.SendAsync<AuthenticationstrengthRootListAuthenticationmethodmodesParameter, AuthenticationstrengthRootListAuthenticationmethodmodesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authenticationstrengthroot-list-authenticationmethodmodes?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthenticationstrengthRootListAuthenticationmethodmodesResponse> AuthenticationstrengthRootListAuthenticationmethodmodesAsync(CancellationToken cancellationToken)
        {
            var p = new AuthenticationstrengthRootListAuthenticationmethodmodesParameter();
            return await this.SendAsync<AuthenticationstrengthRootListAuthenticationmethodmodesParameter, AuthenticationstrengthRootListAuthenticationmethodmodesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authenticationstrengthroot-list-authenticationmethodmodes?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthenticationstrengthRootListAuthenticationmethodmodesResponse> AuthenticationstrengthRootListAuthenticationmethodmodesAsync(AuthenticationstrengthRootListAuthenticationmethodmodesParameter parameter)
        {
            return await this.SendAsync<AuthenticationstrengthRootListAuthenticationmethodmodesParameter, AuthenticationstrengthRootListAuthenticationmethodmodesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authenticationstrengthroot-list-authenticationmethodmodes?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthenticationstrengthRootListAuthenticationmethodmodesResponse> AuthenticationstrengthRootListAuthenticationmethodmodesAsync(AuthenticationstrengthRootListAuthenticationmethodmodesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AuthenticationstrengthRootListAuthenticationmethodmodesParameter, AuthenticationstrengthRootListAuthenticationmethodmodesResponse>(parameter, cancellationToken);
        }
    }
}
