using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/plannerbuckettaskboardtaskformat-get?view=graph-rest-1.0
/// </summary>
public partial class PlannerbuckettaskboardtaskformatGetParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Planner_Tasks_Id_BucketTaskBoardFormat: return $"/planner/tasks/{Id}/bucketTaskBoardFormat";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Planner_Tasks_Id_BucketTaskBoardFormat,
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
public partial class PlannerbuckettaskboardtaskformatGetResponse : RestApiResponse
{
    public string? Id { get; set; }
    public string? OrderHint { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/plannerbuckettaskboardtaskformat-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/plannerbuckettaskboardtaskformat-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PlannerbuckettaskboardtaskformatGetResponse> PlannerbuckettaskboardtaskformatGetAsync()
    {
        var p = new PlannerbuckettaskboardtaskformatGetParameter();
        return await this.SendAsync<PlannerbuckettaskboardtaskformatGetParameter, PlannerbuckettaskboardtaskformatGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/plannerbuckettaskboardtaskformat-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PlannerbuckettaskboardtaskformatGetResponse> PlannerbuckettaskboardtaskformatGetAsync(CancellationToken cancellationToken)
    {
        var p = new PlannerbuckettaskboardtaskformatGetParameter();
        return await this.SendAsync<PlannerbuckettaskboardtaskformatGetParameter, PlannerbuckettaskboardtaskformatGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/plannerbuckettaskboardtaskformat-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PlannerbuckettaskboardtaskformatGetResponse> PlannerbuckettaskboardtaskformatGetAsync(PlannerbuckettaskboardtaskformatGetParameter parameter)
    {
        return await this.SendAsync<PlannerbuckettaskboardtaskformatGetParameter, PlannerbuckettaskboardtaskformatGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/plannerbuckettaskboardtaskformat-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PlannerbuckettaskboardtaskformatGetResponse> PlannerbuckettaskboardtaskformatGetAsync(PlannerbuckettaskboardtaskformatGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<PlannerbuckettaskboardtaskformatGetParameter, PlannerbuckettaskboardtaskformatGetResponse>(parameter, cancellationToken);
    }
}
