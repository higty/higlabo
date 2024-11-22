using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/termstore-group-list-sets?view=graph-rest-1.0
/// </summary>
public partial class TermStoreGroupListSetsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? SiteId { get; set; }
        public string? GroupId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Ites_SiteId_TermStore_Groups_GroupId_Sets: return $"/ites/{SiteId}/termStore/groups/{GroupId}/sets";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Ites_SiteId_TermStore_Groups_GroupId_Sets,
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
public partial class TermStoreGroupListSetsResponse : RestApiResponse<TermStoreSet>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/termstore-group-list-sets?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/termstore-group-list-sets?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TermStoreGroupListSetsResponse> TermStoreGroupListSetsAsync()
    {
        var p = new TermStoreGroupListSetsParameter();
        return await this.SendAsync<TermStoreGroupListSetsParameter, TermStoreGroupListSetsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/termstore-group-list-sets?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TermStoreGroupListSetsResponse> TermStoreGroupListSetsAsync(CancellationToken cancellationToken)
    {
        var p = new TermStoreGroupListSetsParameter();
        return await this.SendAsync<TermStoreGroupListSetsParameter, TermStoreGroupListSetsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/termstore-group-list-sets?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TermStoreGroupListSetsResponse> TermStoreGroupListSetsAsync(TermStoreGroupListSetsParameter parameter)
    {
        return await this.SendAsync<TermStoreGroupListSetsParameter, TermStoreGroupListSetsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/termstore-group-list-sets?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TermStoreGroupListSetsResponse> TermStoreGroupListSetsAsync(TermStoreGroupListSetsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<TermStoreGroupListSetsParameter, TermStoreGroupListSetsResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/termstore-group-list-sets?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<TermStoreSet> TermStoreGroupListSetsEnumerateAsync(TermStoreGroupListSetsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<TermStoreGroupListSetsParameter, TermStoreGroupListSetsResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<TermStoreSet>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
