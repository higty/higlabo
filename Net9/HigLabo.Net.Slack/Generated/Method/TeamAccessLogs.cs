using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack;

public partial class TeamAccessLogsParameter : IRestApiParameter, IRestApiPagingParameter
{
    string IRestApiParameter.ApiPath { get; } = "team.accessLogs";
    string IRestApiParameter.HttpMethod { get; } = "GET";
    public string? Before { get; set; }
    public string? Count { get; set; }
    public string? Cursor { get; set; }
    string? IRestApiPagingParameter.NextPageToken
    {
        get
        {
            return this.Cursor;
        }
        set
        {
            this.Cursor = value;
        }
    }
    public int? Limit { get; set; }
    public string? Page { get; set; }
    public string? Team_Id { get; set; }
}
public partial class TeamAccessLogsResponse : RestApiResponse
{
}
/// <summary>
/// https://api.slack.com/methods/team.accessLogs
/// </summary>
public partial class SlackClient
{
    /// <summary>
    /// https://api.slack.com/methods/team.accessLogs
    /// </summary>
    public async ValueTask<TeamAccessLogsResponse> TeamAccessLogsAsync()
    {
        var p = new TeamAccessLogsParameter();
        return await this.SendAsync<TeamAccessLogsParameter, TeamAccessLogsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/team.accessLogs
    /// </summary>
    public async ValueTask<TeamAccessLogsResponse> TeamAccessLogsAsync(CancellationToken cancellationToken)
    {
        var p = new TeamAccessLogsParameter();
        return await this.SendAsync<TeamAccessLogsParameter, TeamAccessLogsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://api.slack.com/methods/team.accessLogs
    /// </summary>
    public async ValueTask<TeamAccessLogsResponse> TeamAccessLogsAsync(TeamAccessLogsParameter parameter)
    {
        return await this.SendAsync<TeamAccessLogsParameter, TeamAccessLogsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/team.accessLogs
    /// </summary>
    public async ValueTask<TeamAccessLogsResponse> TeamAccessLogsAsync(TeamAccessLogsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<TeamAccessLogsParameter, TeamAccessLogsResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://api.slack.com/methods/team.accessLogs
    /// </summary>
    public async ValueTask<List<TeamAccessLogsResponse>> TeamAccessLogsAsync(PagingContext<TeamAccessLogsResponse> context)
    {
        var p = new TeamAccessLogsParameter();
        return await this.SendBatchAsync(p, context, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/team.accessLogs
    /// </summary>
    public async ValueTask<List<TeamAccessLogsResponse>> TeamAccessLogsAsync(CancellationToken cancellationToken, PagingContext<TeamAccessLogsResponse> context)
    {
        var p = new TeamAccessLogsParameter();
        return await this.SendBatchAsync(p, context, cancellationToken);
    }
    /// <summary>
    /// https://api.slack.com/methods/team.accessLogs
    /// </summary>
    public async ValueTask<List<TeamAccessLogsResponse>> TeamAccessLogsAsync(TeamAccessLogsParameter parameter, PagingContext<TeamAccessLogsResponse> context)
    {
        return await this.SendBatchAsync(parameter, context, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/team.accessLogs
    /// </summary>
    public async ValueTask<List<TeamAccessLogsResponse>> TeamAccessLogsAsync(TeamAccessLogsParameter parameter, PagingContext<TeamAccessLogsResponse> context, CancellationToken cancellationToken)
    {
        return await this.SendBatchAsync(parameter, context, cancellationToken);
    }
}
