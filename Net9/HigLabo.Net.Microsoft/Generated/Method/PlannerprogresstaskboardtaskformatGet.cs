using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/plannerprogresstaskboardtaskformat-get?view=graph-rest-1.0
/// </summary>
public partial class PlannerprogresstaskboardtaskformatGetParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Planner_Tasks_Id_ProgressTaskBoardFormat: return $"/planner/tasks/{Id}/progressTaskBoardFormat";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Planner_Tasks_Id_ProgressTaskBoardFormat,
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
public partial class PlannerprogresstaskboardtaskformatGetResponse : RestApiResponse
{
    public string? Id { get; set; }
    public string? OrderHint { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/plannerprogresstaskboardtaskformat-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/plannerprogresstaskboardtaskformat-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PlannerprogresstaskboardtaskformatGetResponse> PlannerprogresstaskboardtaskformatGetAsync()
    {
        var p = new PlannerprogresstaskboardtaskformatGetParameter();
        return await this.SendAsync<PlannerprogresstaskboardtaskformatGetParameter, PlannerprogresstaskboardtaskformatGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/plannerprogresstaskboardtaskformat-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PlannerprogresstaskboardtaskformatGetResponse> PlannerprogresstaskboardtaskformatGetAsync(CancellationToken cancellationToken)
    {
        var p = new PlannerprogresstaskboardtaskformatGetParameter();
        return await this.SendAsync<PlannerprogresstaskboardtaskformatGetParameter, PlannerprogresstaskboardtaskformatGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/plannerprogresstaskboardtaskformat-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PlannerprogresstaskboardtaskformatGetResponse> PlannerprogresstaskboardtaskformatGetAsync(PlannerprogresstaskboardtaskformatGetParameter parameter)
    {
        return await this.SendAsync<PlannerprogresstaskboardtaskformatGetParameter, PlannerprogresstaskboardtaskformatGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/plannerprogresstaskboardtaskformat-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PlannerprogresstaskboardtaskformatGetResponse> PlannerprogresstaskboardtaskformatGetAsync(PlannerprogresstaskboardtaskformatGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<PlannerprogresstaskboardtaskformatGetParameter, PlannerprogresstaskboardtaskformatGetResponse>(parameter, cancellationToken);
    }
}
