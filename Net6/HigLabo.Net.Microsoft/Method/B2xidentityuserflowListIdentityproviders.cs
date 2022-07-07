using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class B2xidentityuserflowListIdentityprovidersParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Identity_B2xUserFlows_Id_IdentityProviders,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Identity_B2xUserFlows_Id_IdentityProviders: return $"/identity/b2xUserFlows/{Id}/identityProviders";
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
        public string Id { get; set; }
    }
    public partial class B2xidentityuserflowListIdentityprovidersResponse : RestApiResponse
    {
        public string? ClientId { get; set; }
        public string? ClientSecret { get; set; }
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/b2xidentityuserflow-list-identityproviders?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityuserflowListIdentityprovidersResponse> B2xidentityuserflowListIdentityprovidersAsync()
        {
            var p = new B2xidentityuserflowListIdentityprovidersParameter();
            return await this.SendAsync<B2xidentityuserflowListIdentityprovidersParameter, B2xidentityuserflowListIdentityprovidersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/b2xidentityuserflow-list-identityproviders?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityuserflowListIdentityprovidersResponse> B2xidentityuserflowListIdentityprovidersAsync(CancellationToken cancellationToken)
        {
            var p = new B2xidentityuserflowListIdentityprovidersParameter();
            return await this.SendAsync<B2xidentityuserflowListIdentityprovidersParameter, B2xidentityuserflowListIdentityprovidersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/b2xidentityuserflow-list-identityproviders?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityuserflowListIdentityprovidersResponse> B2xidentityuserflowListIdentityprovidersAsync(B2xidentityuserflowListIdentityprovidersParameter parameter)
        {
            return await this.SendAsync<B2xidentityuserflowListIdentityprovidersParameter, B2xidentityuserflowListIdentityprovidersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/b2xidentityuserflow-list-identityproviders?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityuserflowListIdentityprovidersResponse> B2xidentityuserflowListIdentityprovidersAsync(B2xidentityuserflowListIdentityprovidersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<B2xidentityuserflowListIdentityprovidersParameter, B2xidentityuserflowListIdentityprovidersResponse>(parameter, cancellationToken);
        }
    }
}
