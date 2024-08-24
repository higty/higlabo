using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-list-identityproviders?view=graph-rest-1.0
    /// </summary>
    public partial class B2xidentityUserflowListIdentityProvidersParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class B2xidentityUserflowListIdentityProvidersResponse : RestApiResponse<IdentityProvider>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-list-identityproviders?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-list-identityproviders?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<B2xidentityUserflowListIdentityProvidersResponse> B2xidentityUserflowListIdentityProvidersAsync()
        {
            var p = new B2xidentityUserflowListIdentityProvidersParameter();
            return await this.SendAsync<B2xidentityUserflowListIdentityProvidersParameter, B2xidentityUserflowListIdentityProvidersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-list-identityproviders?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<B2xidentityUserflowListIdentityProvidersResponse> B2xidentityUserflowListIdentityProvidersAsync(CancellationToken cancellationToken)
        {
            var p = new B2xidentityUserflowListIdentityProvidersParameter();
            return await this.SendAsync<B2xidentityUserflowListIdentityProvidersParameter, B2xidentityUserflowListIdentityProvidersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-list-identityproviders?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<B2xidentityUserflowListIdentityProvidersResponse> B2xidentityUserflowListIdentityProvidersAsync(B2xidentityUserflowListIdentityProvidersParameter parameter)
        {
            return await this.SendAsync<B2xidentityUserflowListIdentityProvidersParameter, B2xidentityUserflowListIdentityProvidersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-list-identityproviders?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<B2xidentityUserflowListIdentityProvidersResponse> B2xidentityUserflowListIdentityProvidersAsync(B2xidentityUserflowListIdentityProvidersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<B2xidentityUserflowListIdentityProvidersParameter, B2xidentityUserflowListIdentityProvidersResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-list-identityproviders?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<IdentityProvider> B2xidentityUserflowListIdentityProvidersEnumerateAsync(B2xidentityUserflowListIdentityProvidersParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<B2xidentityUserflowListIdentityProvidersParameter, B2xidentityUserflowListIdentityProvidersResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<IdentityProvider>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
