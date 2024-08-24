using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-list-appliesto?view=graph-rest-1.0
    /// </summary>
    public partial class HomeRealmDiscoveryPolicyListAppliestoParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_HomeRealmDiscoveryPolicies_Id_AppliesTo: return $"/policies/homeRealmDiscoveryPolicies/{Id}/appliesTo";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Policies_HomeRealmDiscoveryPolicies_Id_AppliesTo,
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
    public partial class HomeRealmDiscoveryPolicyListAppliestoResponse : RestApiResponse<DirectoryObject>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-list-appliesto?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-list-appliesto?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<HomeRealmDiscoveryPolicyListAppliestoResponse> HomeRealmDiscoveryPolicyListAppliestoAsync()
        {
            var p = new HomeRealmDiscoveryPolicyListAppliestoParameter();
            return await this.SendAsync<HomeRealmDiscoveryPolicyListAppliestoParameter, HomeRealmDiscoveryPolicyListAppliestoResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-list-appliesto?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<HomeRealmDiscoveryPolicyListAppliestoResponse> HomeRealmDiscoveryPolicyListAppliestoAsync(CancellationToken cancellationToken)
        {
            var p = new HomeRealmDiscoveryPolicyListAppliestoParameter();
            return await this.SendAsync<HomeRealmDiscoveryPolicyListAppliestoParameter, HomeRealmDiscoveryPolicyListAppliestoResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-list-appliesto?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<HomeRealmDiscoveryPolicyListAppliestoResponse> HomeRealmDiscoveryPolicyListAppliestoAsync(HomeRealmDiscoveryPolicyListAppliestoParameter parameter)
        {
            return await this.SendAsync<HomeRealmDiscoveryPolicyListAppliestoParameter, HomeRealmDiscoveryPolicyListAppliestoResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-list-appliesto?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<HomeRealmDiscoveryPolicyListAppliestoResponse> HomeRealmDiscoveryPolicyListAppliestoAsync(HomeRealmDiscoveryPolicyListAppliestoParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<HomeRealmDiscoveryPolicyListAppliestoParameter, HomeRealmDiscoveryPolicyListAppliestoResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-list-appliesto?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<DirectoryObject> HomeRealmDiscoveryPolicyListAppliestoEnumerateAsync(HomeRealmDiscoveryPolicyListAppliestoParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<HomeRealmDiscoveryPolicyListAppliestoParameter, HomeRealmDiscoveryPolicyListAppliestoResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<DirectoryObject>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
