using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class B2xidentityuserflowPostIdentityprovidersParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Identity_B2xUserFlows_Id_IdentityProviders_ref,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Identity_B2xUserFlows_Id_IdentityProviders_ref: return $"/identity/b2xUserFlows/{Id}/identityProviders/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Id { get; set; }
    }
    public partial class B2xidentityuserflowPostIdentityprovidersResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/b2xidentityuserflow-post-identityproviders?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityuserflowPostIdentityprovidersResponse> B2xidentityuserflowPostIdentityprovidersAsync()
        {
            var p = new B2xidentityuserflowPostIdentityprovidersParameter();
            return await this.SendAsync<B2xidentityuserflowPostIdentityprovidersParameter, B2xidentityuserflowPostIdentityprovidersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/b2xidentityuserflow-post-identityproviders?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityuserflowPostIdentityprovidersResponse> B2xidentityuserflowPostIdentityprovidersAsync(CancellationToken cancellationToken)
        {
            var p = new B2xidentityuserflowPostIdentityprovidersParameter();
            return await this.SendAsync<B2xidentityuserflowPostIdentityprovidersParameter, B2xidentityuserflowPostIdentityprovidersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/b2xidentityuserflow-post-identityproviders?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityuserflowPostIdentityprovidersResponse> B2xidentityuserflowPostIdentityprovidersAsync(B2xidentityuserflowPostIdentityprovidersParameter parameter)
        {
            return await this.SendAsync<B2xidentityuserflowPostIdentityprovidersParameter, B2xidentityuserflowPostIdentityprovidersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/b2xidentityuserflow-post-identityproviders?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityuserflowPostIdentityprovidersResponse> B2xidentityuserflowPostIdentityprovidersAsync(B2xidentityuserflowPostIdentityprovidersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<B2xidentityuserflowPostIdentityprovidersParameter, B2xidentityuserflowPostIdentityprovidersResponse>(parameter, cancellationToken);
        }
    }
}
