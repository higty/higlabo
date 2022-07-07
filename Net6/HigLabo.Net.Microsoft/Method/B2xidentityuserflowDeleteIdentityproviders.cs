using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class B2xidentityuserflowDeleteIdentityprovidersParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Identity_B2xUserFlows_Id_IdentityProviders_Id_ref,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Identity_B2xUserFlows_Id_IdentityProviders_Id_ref: return $"/identity/b2xUserFlows/{B2xUserFlowsId}/identityProviders/{IdentityProvidersId}/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string B2xUserFlowsId { get; set; }
        public string IdentityProvidersId { get; set; }
    }
    public partial class B2xidentityuserflowDeleteIdentityprovidersResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/b2xidentityuserflow-delete-identityproviders?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityuserflowDeleteIdentityprovidersResponse> B2xidentityuserflowDeleteIdentityprovidersAsync()
        {
            var p = new B2xidentityuserflowDeleteIdentityprovidersParameter();
            return await this.SendAsync<B2xidentityuserflowDeleteIdentityprovidersParameter, B2xidentityuserflowDeleteIdentityprovidersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/b2xidentityuserflow-delete-identityproviders?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityuserflowDeleteIdentityprovidersResponse> B2xidentityuserflowDeleteIdentityprovidersAsync(CancellationToken cancellationToken)
        {
            var p = new B2xidentityuserflowDeleteIdentityprovidersParameter();
            return await this.SendAsync<B2xidentityuserflowDeleteIdentityprovidersParameter, B2xidentityuserflowDeleteIdentityprovidersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/b2xidentityuserflow-delete-identityproviders?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityuserflowDeleteIdentityprovidersResponse> B2xidentityuserflowDeleteIdentityprovidersAsync(B2xidentityuserflowDeleteIdentityprovidersParameter parameter)
        {
            return await this.SendAsync<B2xidentityuserflowDeleteIdentityprovidersParameter, B2xidentityuserflowDeleteIdentityprovidersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/b2xidentityuserflow-delete-identityproviders?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityuserflowDeleteIdentityprovidersResponse> B2xidentityuserflowDeleteIdentityprovidersAsync(B2xidentityuserflowDeleteIdentityprovidersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<B2xidentityuserflowDeleteIdentityprovidersParameter, B2xidentityuserflowDeleteIdentityprovidersResponse>(parameter, cancellationToken);
        }
    }
}
