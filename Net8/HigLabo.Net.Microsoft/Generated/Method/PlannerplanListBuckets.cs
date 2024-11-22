using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/plannerplan-list-buckets?view=graph-rest-1.0
/// </summary>
public partial class PlannerplanListBucketsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? PlanId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Planner_Plans_PlanId_Buckets: return $"/planner/plans/{PlanId}/buckets";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Planner_Plans_PlanId_Buckets,
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
public partial class PlannerplanListBucketsResponse : RestApiResponse<PlannerBucket>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/plannerplan-list-buckets?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/plannerplan-list-buckets?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PlannerplanListBucketsResponse> PlannerplanListBucketsAsync()
    {
        var p = new PlannerplanListBucketsParameter();
        return await this.SendAsync<PlannerplanListBucketsParameter, PlannerplanListBucketsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/plannerplan-list-buckets?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PlannerplanListBucketsResponse> PlannerplanListBucketsAsync(CancellationToken cancellationToken)
    {
        var p = new PlannerplanListBucketsParameter();
        return await this.SendAsync<PlannerplanListBucketsParameter, PlannerplanListBucketsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/plannerplan-list-buckets?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PlannerplanListBucketsResponse> PlannerplanListBucketsAsync(PlannerplanListBucketsParameter parameter)
    {
        return await this.SendAsync<PlannerplanListBucketsParameter, PlannerplanListBucketsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/plannerplan-list-buckets?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PlannerplanListBucketsResponse> PlannerplanListBucketsAsync(PlannerplanListBucketsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<PlannerplanListBucketsParameter, PlannerplanListBucketsResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/plannerplan-list-buckets?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<PlannerBucket> PlannerplanListBucketsEnumerateAsync(PlannerplanListBucketsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<PlannerplanListBucketsParameter, PlannerplanListBucketsResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<PlannerBucket>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
