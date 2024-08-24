using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identitycontainer-list-identityproviders?view=graph-rest-1.0
    /// </summary>
    public partial class IdentitycontainerListIdentityProvidersParameter : IRestApiParameter, IQueryParameterProperty
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

        public enum Field
        {
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
    public partial class IdentitycontainerListIdentityProvidersResponse : RestApiResponse<SocialIdentityProvider>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identitycontainer-list-identityproviders?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identitycontainer-list-identityproviders?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<IdentitycontainerListIdentityProvidersResponse> IdentitycontainerListIdentityProvidersAsync()
        {
            var p = new IdentitycontainerListIdentityProvidersParameter();
            return await this.SendAsync<IdentitycontainerListIdentityProvidersParameter, IdentitycontainerListIdentityProvidersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identitycontainer-list-identityproviders?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<IdentitycontainerListIdentityProvidersResponse> IdentitycontainerListIdentityProvidersAsync(CancellationToken cancellationToken)
        {
            var p = new IdentitycontainerListIdentityProvidersParameter();
            return await this.SendAsync<IdentitycontainerListIdentityProvidersParameter, IdentitycontainerListIdentityProvidersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identitycontainer-list-identityproviders?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<IdentitycontainerListIdentityProvidersResponse> IdentitycontainerListIdentityProvidersAsync(IdentitycontainerListIdentityProvidersParameter parameter)
        {
            return await this.SendAsync<IdentitycontainerListIdentityProvidersParameter, IdentitycontainerListIdentityProvidersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identitycontainer-list-identityproviders?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<IdentitycontainerListIdentityProvidersResponse> IdentitycontainerListIdentityProvidersAsync(IdentitycontainerListIdentityProvidersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IdentitycontainerListIdentityProvidersParameter, IdentitycontainerListIdentityProvidersResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identitycontainer-list-identityproviders?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<SocialIdentityProvider> IdentitycontainerListIdentityProvidersEnumerateAsync(IdentitycontainerListIdentityProvidersParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<IdentitycontainerListIdentityProvidersParameter, IdentitycontainerListIdentityProvidersResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<SocialIdentityProvider>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
