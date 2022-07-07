using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IdentityproviderPostIdentityprovidersParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            IdentityProviders,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityProviders: return $"/identityProviders";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? ClientId { get; set; }
        public string? ClientSecret { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
    }
    public partial class IdentityproviderPostIdentityprovidersResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/identityprovider-post-identityproviders?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityproviderPostIdentityprovidersResponse> IdentityproviderPostIdentityprovidersAsync()
        {
            var p = new IdentityproviderPostIdentityprovidersParameter();
            return await this.SendAsync<IdentityproviderPostIdentityprovidersParameter, IdentityproviderPostIdentityprovidersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityprovider-post-identityproviders?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityproviderPostIdentityprovidersResponse> IdentityproviderPostIdentityprovidersAsync(CancellationToken cancellationToken)
        {
            var p = new IdentityproviderPostIdentityprovidersParameter();
            return await this.SendAsync<IdentityproviderPostIdentityprovidersParameter, IdentityproviderPostIdentityprovidersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityprovider-post-identityproviders?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityproviderPostIdentityprovidersResponse> IdentityproviderPostIdentityprovidersAsync(IdentityproviderPostIdentityprovidersParameter parameter)
        {
            return await this.SendAsync<IdentityproviderPostIdentityprovidersParameter, IdentityproviderPostIdentityprovidersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityprovider-post-identityproviders?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityproviderPostIdentityprovidersResponse> IdentityproviderPostIdentityprovidersAsync(IdentityproviderPostIdentityprovidersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IdentityproviderPostIdentityprovidersParameter, IdentityproviderPostIdentityprovidersResponse>(parameter, cancellationToken);
        }
    }
}
