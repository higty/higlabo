using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/plannerplan-list-tasks?view=graph-rest-1.0
/// </summary>
public partial class PlannerplanListTasksParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? PlanId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Planner_Plans_PlanId_Tasks: return $"/planner/plans/{PlanId}/tasks";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Planner_Plans_PlanId_Tasks,
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
public partial class PlannerplanListTasksResponse : RestApiResponse<PlannerTask>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/plannerplan-list-tasks?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/plannerplan-list-tasks?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PlannerplanListTasksResponse> PlannerplanListTasksAsync()
    {
        var p = new PlannerplanListTasksParameter();
        return await this.SendAsync<PlannerplanListTasksParameter, PlannerplanListTasksResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/plannerplan-list-tasks?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PlannerplanListTasksResponse> PlannerplanListTasksAsync(CancellationToken cancellationToken)
    {
        var p = new PlannerplanListTasksParameter();
        return await this.SendAsync<PlannerplanListTasksParameter, PlannerplanListTasksResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/plannerplan-list-tasks?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PlannerplanListTasksResponse> PlannerplanListTasksAsync(PlannerplanListTasksParameter parameter)
    {
        return await this.SendAsync<PlannerplanListTasksParameter, PlannerplanListTasksResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/plannerplan-list-tasks?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PlannerplanListTasksResponse> PlannerplanListTasksAsync(PlannerplanListTasksParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<PlannerplanListTasksParameter, PlannerplanListTasksResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/plannerplan-list-tasks?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<PlannerTask> PlannerplanListTasksEnumerateAsync(PlannerplanListTasksParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<PlannerplanListTasksParameter, PlannerplanListTasksResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<PlannerTask>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
