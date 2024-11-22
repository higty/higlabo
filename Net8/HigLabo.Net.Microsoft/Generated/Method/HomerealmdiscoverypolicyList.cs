using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-list?view=graph-rest-1.0
/// </summary>
public partial class HomeRealmDiscoveryPolicyListParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Policies_HomeRealmDiscoveryPolicies: return $"/policies/homeRealmDiscoveryPolicies";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Policies_HomeRealmDiscoveryPolicies,
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
public partial class HomeRealmDiscoveryPolicyListResponse : RestApiResponse<HomeRealmDiscoveryPolicy>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-list?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<HomeRealmDiscoveryPolicyListResponse> HomeRealmDiscoveryPolicyListAsync()
    {
        var p = new HomeRealmDiscoveryPolicyListParameter();
        return await this.SendAsync<HomeRealmDiscoveryPolicyListParameter, HomeRealmDiscoveryPolicyListResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<HomeRealmDiscoveryPolicyListResponse> HomeRealmDiscoveryPolicyListAsync(CancellationToken cancellationToken)
    {
        var p = new HomeRealmDiscoveryPolicyListParameter();
        return await this.SendAsync<HomeRealmDiscoveryPolicyListParameter, HomeRealmDiscoveryPolicyListResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<HomeRealmDiscoveryPolicyListResponse> HomeRealmDiscoveryPolicyListAsync(HomeRealmDiscoveryPolicyListParameter parameter)
    {
        return await this.SendAsync<HomeRealmDiscoveryPolicyListParameter, HomeRealmDiscoveryPolicyListResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<HomeRealmDiscoveryPolicyListResponse> HomeRealmDiscoveryPolicyListAsync(HomeRealmDiscoveryPolicyListParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<HomeRealmDiscoveryPolicyListParameter, HomeRealmDiscoveryPolicyListResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-list?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<HomeRealmDiscoveryPolicy> HomeRealmDiscoveryPolicyListEnumerateAsync(HomeRealmDiscoveryPolicyListParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<HomeRealmDiscoveryPolicyListParameter, HomeRealmDiscoveryPolicyListResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<HomeRealmDiscoveryPolicy>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
