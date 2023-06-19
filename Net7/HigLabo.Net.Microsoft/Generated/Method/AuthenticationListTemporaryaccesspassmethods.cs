using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authentication-list-temporaryaccesspassmethods?view=graph-rest-1.0
    /// </summary>
    public partial class AuthenticationListTemporaryAccesspassmethodsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Authentication_TemporaryAccessPassMethods: return $"/me/authentication/temporaryAccessPassMethods";
                    case ApiPath.Users_IdOrUserPrincipalName_Authentication_TemporaryAccessPassMethods: return $"/users/{IdOrUserPrincipalName}/authentication/temporaryAccessPassMethods";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            CreatedDateTime,
            Id,
            IsUsable,
            IsUsableOnce,
            LifetimeInMinutes,
            MethodUsabilityReason,
            StartDateTime,
            TemporaryAccessPass,
        }
        public enum ApiPath
        {
            Me_Authentication_TemporaryAccessPassMethods,
            Users_IdOrUserPrincipalName_Authentication_TemporaryAccessPassMethods,
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
    public partial class AuthenticationListTemporaryAccesspassmethodsResponse : RestApiResponse
    {
        public TemporaryAccessPassAuthenticationMethod[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authentication-list-temporaryaccesspassmethods?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authentication-list-temporaryaccesspassmethods?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AuthenticationListTemporaryAccesspassmethodsResponse> AuthenticationListTemporaryAccesspassmethodsAsync()
        {
            var p = new AuthenticationListTemporaryAccesspassmethodsParameter();
            return await this.SendAsync<AuthenticationListTemporaryAccesspassmethodsParameter, AuthenticationListTemporaryAccesspassmethodsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authentication-list-temporaryaccesspassmethods?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AuthenticationListTemporaryAccesspassmethodsResponse> AuthenticationListTemporaryAccesspassmethodsAsync(CancellationToken cancellationToken)
        {
            var p = new AuthenticationListTemporaryAccesspassmethodsParameter();
            return await this.SendAsync<AuthenticationListTemporaryAccesspassmethodsParameter, AuthenticationListTemporaryAccesspassmethodsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authentication-list-temporaryaccesspassmethods?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AuthenticationListTemporaryAccesspassmethodsResponse> AuthenticationListTemporaryAccesspassmethodsAsync(AuthenticationListTemporaryAccesspassmethodsParameter parameter)
        {
            return await this.SendAsync<AuthenticationListTemporaryAccesspassmethodsParameter, AuthenticationListTemporaryAccesspassmethodsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authentication-list-temporaryaccesspassmethods?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AuthenticationListTemporaryAccesspassmethodsResponse> AuthenticationListTemporaryAccesspassmethodsAsync(AuthenticationListTemporaryAccesspassmethodsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AuthenticationListTemporaryAccesspassmethodsParameter, AuthenticationListTemporaryAccesspassmethodsResponse>(parameter, cancellationToken);
        }
    }
}
