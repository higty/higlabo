using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IdentitycontainerPostIdentityprovidersParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
    }
    public partial class IdentitycontainerPostIdentityprovidersResponse : RestApiResponse
    {
        public string? ClientId { get; set; }
        public string? ClientSecret { get; set; }
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? IdentityProviderType { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identitycontainer-post-identityproviders?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentitycontainerPostIdentityprovidersResponse> IdentitycontainerPostIdentityprovidersAsync()
        {
            var p = new IdentitycontainerPostIdentityprovidersParameter();
            return await this.SendAsync<IdentitycontainerPostIdentityprovidersParameter, IdentitycontainerPostIdentityprovidersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identitycontainer-post-identityproviders?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentitycontainerPostIdentityprovidersResponse> IdentitycontainerPostIdentityprovidersAsync(CancellationToken cancellationToken)
        {
            var p = new IdentitycontainerPostIdentityprovidersParameter();
            return await this.SendAsync<IdentitycontainerPostIdentityprovidersParameter, IdentitycontainerPostIdentityprovidersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identitycontainer-post-identityproviders?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentitycontainerPostIdentityprovidersResponse> IdentitycontainerPostIdentityprovidersAsync(IdentitycontainerPostIdentityprovidersParameter parameter)
        {
            return await this.SendAsync<IdentitycontainerPostIdentityprovidersParameter, IdentitycontainerPostIdentityprovidersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identitycontainer-post-identityproviders?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentitycontainerPostIdentityprovidersResponse> IdentitycontainerPostIdentityprovidersAsync(IdentitycontainerPostIdentityprovidersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IdentitycontainerPostIdentityprovidersParameter, IdentitycontainerPostIdentityprovidersResponse>(parameter, cancellationToken);
        }
    }
}
