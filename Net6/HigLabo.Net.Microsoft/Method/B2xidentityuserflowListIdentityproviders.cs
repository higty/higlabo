using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class B2xidentityUserflowListIdentityprovidersParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Identity_B2xUserFlows_Id_IdentityProviders: return $"/identity/b2xUserFlows/{Id}/identityProviders";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Identity_B2xUserFlows_Id_IdentityProviders,
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
    public partial class B2xidentityUserflowListIdentityprovidersResponse : RestApiResponse
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
        public async Task<B2xidentityUserflowListIdentityprovidersResponse> B2xidentityUserflowListIdentityprovidersAsync()
        {
            var p = new B2xidentityUserflowListIdentityprovidersParameter();
            return await this.SendAsync<B2xidentityUserflowListIdentityprovidersParameter, B2xidentityUserflowListIdentityprovidersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/b2xidentityuserflow-list-identityproviders?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityUserflowListIdentityprovidersResponse> B2xidentityUserflowListIdentityprovidersAsync(CancellationToken cancellationToken)
        {
            var p = new B2xidentityUserflowListIdentityprovidersParameter();
            return await this.SendAsync<B2xidentityUserflowListIdentityprovidersParameter, B2xidentityUserflowListIdentityprovidersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/b2xidentityuserflow-list-identityproviders?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityUserflowListIdentityprovidersResponse> B2xidentityUserflowListIdentityprovidersAsync(B2xidentityUserflowListIdentityprovidersParameter parameter)
        {
            return await this.SendAsync<B2xidentityUserflowListIdentityprovidersParameter, B2xidentityUserflowListIdentityprovidersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/b2xidentityuserflow-list-identityproviders?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityUserflowListIdentityprovidersResponse> B2xidentityUserflowListIdentityprovidersAsync(B2xidentityUserflowListIdentityprovidersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<B2xidentityUserflowListIdentityprovidersParameter, B2xidentityUserflowListIdentityprovidersResponse>(parameter, cancellationToken);
        }
    }
}
