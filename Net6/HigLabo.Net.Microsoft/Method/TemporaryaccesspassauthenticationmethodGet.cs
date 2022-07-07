using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TemporaryaccesspassauthenticationmethodGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Authentication_TemporaryAccessPassMethods_TemporaryAccessPassAuthenticationMethodId,
            Users_IdOrUserPrincipalName_Authentication_TemporaryAccessPassMethods_TemporaryAccessPassAuthenticationMethodId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Authentication_TemporaryAccessPassMethods_TemporaryAccessPassAuthenticationMethodId: return $"/me/authentication/temporaryAccessPassMethods/{TemporaryAccessPassAuthenticationMethodId}";
                    case ApiPath.Users_IdOrUserPrincipalName_Authentication_TemporaryAccessPassMethods_TemporaryAccessPassAuthenticationMethodId: return $"/users/{IdOrUserPrincipalName}/authentication/temporaryAccessPassMethods/{TemporaryAccessPassAuthenticationMethodId}";
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
        public string TemporaryAccessPassAuthenticationMethodId { get; set; }
        public string IdOrUserPrincipalName { get; set; }
    }
    public partial class TemporaryaccesspassauthenticationmethodGetResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/temporaryaccesspassauthenticationmethod-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TemporaryaccesspassauthenticationmethodGetResponse> TemporaryaccesspassauthenticationmethodGetAsync()
        {
            var p = new TemporaryaccesspassauthenticationmethodGetParameter();
            return await this.SendAsync<TemporaryaccesspassauthenticationmethodGetParameter, TemporaryaccesspassauthenticationmethodGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/temporaryaccesspassauthenticationmethod-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TemporaryaccesspassauthenticationmethodGetResponse> TemporaryaccesspassauthenticationmethodGetAsync(CancellationToken cancellationToken)
        {
            var p = new TemporaryaccesspassauthenticationmethodGetParameter();
            return await this.SendAsync<TemporaryaccesspassauthenticationmethodGetParameter, TemporaryaccesspassauthenticationmethodGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/temporaryaccesspassauthenticationmethod-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TemporaryaccesspassauthenticationmethodGetResponse> TemporaryaccesspassauthenticationmethodGetAsync(TemporaryaccesspassauthenticationmethodGetParameter parameter)
        {
            return await this.SendAsync<TemporaryaccesspassauthenticationmethodGetParameter, TemporaryaccesspassauthenticationmethodGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/temporaryaccesspassauthenticationmethod-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TemporaryaccesspassauthenticationmethodGetResponse> TemporaryaccesspassauthenticationmethodGetAsync(TemporaryaccesspassauthenticationmethodGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TemporaryaccesspassauthenticationmethodGetParameter, TemporaryaccesspassauthenticationmethodGetResponse>(parameter, cancellationToken);
        }
    }
}
