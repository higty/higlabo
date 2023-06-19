using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationmethodspolicy-get?view=graph-rest-1.0
    /// </summary>
    public partial class AuthenticationmethodsPolicyGetParameter : IRestApiParameter, IQueryParameterProperty
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

        public enum Field
        {
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
    public partial class AuthenticationmethodsPolicyGetResponse : RestApiResponse
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
    /// https://learn.microsoft.com/en-us/graph/api/authenticationmethodspolicy-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authenticationmethodspolicy-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AuthenticationmethodsPolicyGetResponse> AuthenticationmethodsPolicyGetAsync()
        {
            var p = new AuthenticationmethodsPolicyGetParameter();
            return await this.SendAsync<AuthenticationmethodsPolicyGetParameter, AuthenticationmethodsPolicyGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authenticationmethodspolicy-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AuthenticationmethodsPolicyGetResponse> AuthenticationmethodsPolicyGetAsync(CancellationToken cancellationToken)
        {
            var p = new AuthenticationmethodsPolicyGetParameter();
            return await this.SendAsync<AuthenticationmethodsPolicyGetParameter, AuthenticationmethodsPolicyGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authenticationmethodspolicy-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AuthenticationmethodsPolicyGetResponse> AuthenticationmethodsPolicyGetAsync(AuthenticationmethodsPolicyGetParameter parameter)
        {
            return await this.SendAsync<AuthenticationmethodsPolicyGetParameter, AuthenticationmethodsPolicyGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authenticationmethodspolicy-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AuthenticationmethodsPolicyGetResponse> AuthenticationmethodsPolicyGetAsync(AuthenticationmethodsPolicyGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AuthenticationmethodsPolicyGetParameter, AuthenticationmethodsPolicyGetResponse>(parameter, cancellationToken);
        }
    }
}
