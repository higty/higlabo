using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identitycontainer-post-identityproviders?view=graph-rest-1.0
    /// </summary>
    public partial class IdentitycontainerPostIdentityprovidersParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Identity_IdentityProviders: return $"/identity/identityProviders";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Identity_IdentityProviders,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? ClientId { get; set; }
        public string? ClientSecret { get; set; }
        public string? DisplayName { get; set; }
        public string? IdentityProviderType { get; set; }
        public string? Scope { get; set; }
        public string? Id { get; set; }
    }
    public partial class IdentitycontainerPostIdentityprovidersResponse : RestApiResponse
    {
        public string? ClientId { get; set; }
        public string? ClientSecret { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public string? IdentityProviderType { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identitycontainer-post-identityproviders?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identitycontainer-post-identityproviders?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<IdentitycontainerPostIdentityprovidersResponse> IdentitycontainerPostIdentityprovidersAsync()
        {
            var p = new IdentitycontainerPostIdentityprovidersParameter();
            return await this.SendAsync<IdentitycontainerPostIdentityprovidersParameter, IdentitycontainerPostIdentityprovidersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identitycontainer-post-identityproviders?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<IdentitycontainerPostIdentityprovidersResponse> IdentitycontainerPostIdentityprovidersAsync(CancellationToken cancellationToken)
        {
            var p = new IdentitycontainerPostIdentityprovidersParameter();
            return await this.SendAsync<IdentitycontainerPostIdentityprovidersParameter, IdentitycontainerPostIdentityprovidersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identitycontainer-post-identityproviders?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<IdentitycontainerPostIdentityprovidersResponse> IdentitycontainerPostIdentityprovidersAsync(IdentitycontainerPostIdentityprovidersParameter parameter)
        {
            return await this.SendAsync<IdentitycontainerPostIdentityprovidersParameter, IdentitycontainerPostIdentityprovidersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identitycontainer-post-identityproviders?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<IdentitycontainerPostIdentityprovidersResponse> IdentitycontainerPostIdentityprovidersAsync(IdentitycontainerPostIdentityprovidersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IdentitycontainerPostIdentityprovidersParameter, IdentitycontainerPostIdentityprovidersResponse>(parameter, cancellationToken);
        }
    }
}
