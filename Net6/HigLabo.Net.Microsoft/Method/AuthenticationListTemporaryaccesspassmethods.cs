using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AuthenticationListTemporaryaccesspassmethodsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Authentication_TemporaryAccessPassMethods,
            Users_IdOrUserPrincipalName_Authentication_TemporaryAccessPassMethods,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Authentication_TemporaryAccessPassMethods: return $"/me/authentication/temporaryAccessPassMethods";
                    case ApiPath.Users_IdOrUserPrincipalName_Authentication_TemporaryAccessPassMethods: return $"/users/{IdOrUserPrincipalName}/authentication/temporaryAccessPassMethods";
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
        public string IdOrUserPrincipalName { get; set; }
    }
    public partial class AuthenticationListTemporaryaccesspassmethodsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/temporaryaccesspassauthenticationmethod?view=graph-rest-1.0
        /// </summary>
        public partial class TemporaryAccessPassAuthenticationMethod
        {
            public DateTimeOffset? CreatedDateTime { get; set; }
            public string? Id { get; set; }
            public bool? IsUsableOnce { get; set; }
            public bool? IsUsable { get; set; }
            public Int32? LifetimeInMinutes { get; set; }
            public string? MethodUsabilityReason { get; set; }
            public DateTimeOffset? StartDateTime { get; set; }
            public string? TemporaryAccessPass { get; set; }
        }

        public TemporaryAccessPassAuthenticationMethod[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/authentication-list-temporaryaccesspassmethods?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthenticationListTemporaryaccesspassmethodsResponse> AuthenticationListTemporaryaccesspassmethodsAsync()
        {
            var p = new AuthenticationListTemporaryaccesspassmethodsParameter();
            return await this.SendAsync<AuthenticationListTemporaryaccesspassmethodsParameter, AuthenticationListTemporaryaccesspassmethodsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/authentication-list-temporaryaccesspassmethods?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthenticationListTemporaryaccesspassmethodsResponse> AuthenticationListTemporaryaccesspassmethodsAsync(CancellationToken cancellationToken)
        {
            var p = new AuthenticationListTemporaryaccesspassmethodsParameter();
            return await this.SendAsync<AuthenticationListTemporaryaccesspassmethodsParameter, AuthenticationListTemporaryaccesspassmethodsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/authentication-list-temporaryaccesspassmethods?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthenticationListTemporaryaccesspassmethodsResponse> AuthenticationListTemporaryaccesspassmethodsAsync(AuthenticationListTemporaryaccesspassmethodsParameter parameter)
        {
            return await this.SendAsync<AuthenticationListTemporaryaccesspassmethodsParameter, AuthenticationListTemporaryaccesspassmethodsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/authentication-list-temporaryaccesspassmethods?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthenticationListTemporaryaccesspassmethodsResponse> AuthenticationListTemporaryaccesspassmethodsAsync(AuthenticationListTemporaryaccesspassmethodsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AuthenticationListTemporaryaccesspassmethodsParameter, AuthenticationListTemporaryaccesspassmethodsResponse>(parameter, cancellationToken);
        }
    }
}
