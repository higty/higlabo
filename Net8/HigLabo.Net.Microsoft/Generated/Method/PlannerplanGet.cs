using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/plannerplan-get?view=graph-rest-1.0
/// </summary>
public partial class PlannerplanGetParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? PlanId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Planner_Plans_PlanId: return $"/planner/plans/{PlanId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Planner_Plans_PlanId,
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
public partial class PlannerplanGetResponse : RestApiResponse
{
    public PlannerPlanContainer? Container { get; set; }
    public IdentitySet? CreatedBy { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? Id { get; set; }
    public string? Title { get; set; }
    public PlannerBucket[]? Buckets { get; set; }
    public PlannerPlanDetails? Details { get; set; }
    public PlannerTask[]? Tasks { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/plannerplan-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/plannerplan-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PlannerplanGetResponse> PlannerplanGetAsync()
    {
        var p = new PlannerplanGetParameter();
        return await this.SendAsync<PlannerplanGetParameter, PlannerplanGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/plannerplan-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PlannerplanGetResponse> PlannerplanGetAsync(CancellationToken cancellationToken)
    {
        var p = new PlannerplanGetParameter();
        return await this.SendAsync<PlannerplanGetParameter, PlannerplanGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/plannerplan-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PlannerplanGetResponse> PlannerplanGetAsync(PlannerplanGetParameter parameter)
    {
        return await this.SendAsync<PlannerplanGetParameter, PlannerplanGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/plannerplan-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PlannerplanGetResponse> PlannerplanGetAsync(PlannerplanGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<PlannerplanGetParameter, PlannerplanGetResponse>(parameter, cancellationToken);
    }
}
