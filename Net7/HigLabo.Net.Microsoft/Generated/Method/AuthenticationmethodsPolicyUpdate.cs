using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationmethodspolicy-update?view=graph-rest-1.0
    /// </summary>
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
        public RegistrationEnforcement? RegistrationEnforcement { get; set; }
    }
    public partial class AuthenticationmethodsPolicyUpdateResponse : RestApiResponse
    {
        public enum AuthenticationMethodsPolicyAuthenticationMethodsPolicyMigrationState
        {
            Premigration,
            MigrationInProgress,
            MigrationComplete,
            UnknownFutureValue,
        }

        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string? PolicyVersion { get; set; }
        public RegistrationEnforcement? RegistrationEnforcement { get; set; }
        public AuthenticationMethodsPolicyAuthenticationMethodsPolicyMigrationState PolicyMigrationState { get; set; }
        public AuthenticationMethodConfiguration[]? AuthenticationMethodConfigurations { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationmethodspolicy-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authenticationmethodspolicy-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AuthenticationmethodsPolicyUpdateResponse> AuthenticationmethodsPolicyUpdateAsync()
        {
            var p = new AuthenticationmethodsPolicyUpdateParameter();
            return await this.SendAsync<AuthenticationmethodsPolicyUpdateParameter, AuthenticationmethodsPolicyUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authenticationmethodspolicy-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AuthenticationmethodsPolicyUpdateResponse> AuthenticationmethodsPolicyUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new AuthenticationmethodsPolicyUpdateParameter();
            return await this.SendAsync<AuthenticationmethodsPolicyUpdateParameter, AuthenticationmethodsPolicyUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authenticationmethodspolicy-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AuthenticationmethodsPolicyUpdateResponse> AuthenticationmethodsPolicyUpdateAsync(AuthenticationmethodsPolicyUpdateParameter parameter)
        {
            return await this.SendAsync<AuthenticationmethodsPolicyUpdateParameter, AuthenticationmethodsPolicyUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authenticationmethodspolicy-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AuthenticationmethodsPolicyUpdateResponse> AuthenticationmethodsPolicyUpdateAsync(AuthenticationmethodsPolicyUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AuthenticationmethodsPolicyUpdateParameter, AuthenticationmethodsPolicyUpdateResponse>(parameter, cancellationToken);
        }
    }
}
