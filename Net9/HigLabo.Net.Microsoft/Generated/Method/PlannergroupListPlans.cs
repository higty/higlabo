using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/plannergroup-list-plans?view=graph-rest-1.0
/// </summary>
public partial class PlannerGroupListPlansParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? GroupId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Groups_GroupId_Planner_Plans: return $"/groups/{GroupId}/planner/plans";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Groups_GroupId_Planner_Plans,
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
public partial class PlannerGroupListPlansResponse : RestApiResponse<PlannerPlan>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/plannergroup-list-plans?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/plannergroup-list-plans?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PlannerGroupListPlansResponse> PlannerGroupListPlansAsync()
    {
        var p = new PlannerGroupListPlansParameter();
        return await this.SendAsync<PlannerGroupListPlansParameter, PlannerGroupListPlansResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/plannergroup-list-plans?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PlannerGroupListPlansResponse> PlannerGroupListPlansAsync(CancellationToken cancellationToken)
    {
        var p = new PlannerGroupListPlansParameter();
        return await this.SendAsync<PlannerGroupListPlansParameter, PlannerGroupListPlansResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/plannergroup-list-plans?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PlannerGroupListPlansResponse> PlannerGroupListPlansAsync(PlannerGroupListPlansParameter parameter)
    {
        return await this.SendAsync<PlannerGroupListPlansParameter, PlannerGroupListPlansResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/plannergroup-list-plans?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PlannerGroupListPlansResponse> PlannerGroupListPlansAsync(PlannerGroupListPlansParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<PlannerGroupListPlansParameter, PlannerGroupListPlansResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/plannergroup-list-plans?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<PlannerPlan> PlannerGroupListPlansEnumerateAsync(PlannerGroupListPlansParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<PlannerGroupListPlansParameter, PlannerGroupListPlansResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<PlannerPlan>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
