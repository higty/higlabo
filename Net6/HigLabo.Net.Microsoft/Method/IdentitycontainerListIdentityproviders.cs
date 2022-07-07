using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IdentitycontainerListIdentityprovidersParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Identity_IdentityProviders,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Identity_IdentityProviders: return $"/identity/identityProviders";
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
    }
    public partial class IdentitycontainerListIdentityprovidersResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/socialidentityprovider?view=graph-rest-1.0
        /// </summary>
        public partial class SocialIdentityProvider
        {
            public string? ClientId { get; set; }
            public string? ClientSecret { get; set; }
            public string? Id { get; set; }
            public string? DisplayName { get; set; }
            public string? IdentityProviderType { get; set; }
        }

        public SocialIdentityProvider[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identitycontainer-list-identityproviders?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentitycontainerListIdentityprovidersResponse> IdentitycontainerListIdentityprovidersAsync()
        {
            var p = new IdentitycontainerListIdentityprovidersParameter();
            return await this.SendAsync<IdentitycontainerListIdentityprovidersParameter, IdentitycontainerListIdentityprovidersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identitycontainer-list-identityproviders?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentitycontainerListIdentityprovidersResponse> IdentitycontainerListIdentityprovidersAsync(CancellationToken cancellationToken)
        {
            var p = new IdentitycontainerListIdentityprovidersParameter();
            return await this.SendAsync<IdentitycontainerListIdentityprovidersParameter, IdentitycontainerListIdentityprovidersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identitycontainer-list-identityproviders?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentitycontainerListIdentityprovidersResponse> IdentitycontainerListIdentityprovidersAsync(IdentitycontainerListIdentityprovidersParameter parameter)
        {
            return await this.SendAsync<IdentitycontainerListIdentityprovidersParameter, IdentitycontainerListIdentityprovidersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identitycontainer-list-identityproviders?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentitycontainerListIdentityprovidersResponse> IdentitycontainerListIdentityprovidersAsync(IdentitycontainerListIdentityprovidersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IdentitycontainerListIdentityprovidersParameter, IdentitycontainerListIdentityprovidersResponse>(parameter, cancellationToken);
        }
    }
}
