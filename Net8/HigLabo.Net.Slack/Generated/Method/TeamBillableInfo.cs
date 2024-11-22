using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack;

public partial class TeamBillableInfoParameter : IRestApiParameter, IRestApiPagingParameter
{
    string IRestApiParameter.ApiPath { get; } = "team.billableInfo";
    string IRestApiParameter.HttpMethod { get; } = "GET";
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
    public string? Team_Id { get; set; }
    public string? User { get; set; }
}
public partial class TeamBillableInfoResponse : RestApiResponse
{
}
/// <summary>
/// https://api.slack.com/methods/team.billableInfo
/// </summary>
public partial class SlackClient
{
    /// <summary>
    /// https://api.slack.com/methods/team.billableInfo
    /// </summary>
    public async ValueTask<TeamBillableInfoResponse> TeamBillableInfoAsync()
    {
        var p = new TeamBillableInfoParameter();
        return await this.SendAsync<TeamBillableInfoParameter, TeamBillableInfoResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/team.billableInfo
    /// </summary>
    public async ValueTask<TeamBillableInfoResponse> TeamBillableInfoAsync(CancellationToken cancellationToken)
    {
        var p = new TeamBillableInfoParameter();
        return await this.SendAsync<TeamBillableInfoParameter, TeamBillableInfoResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://api.slack.com/methods/team.billableInfo
    /// </summary>
    public async ValueTask<TeamBillableInfoResponse> TeamBillableInfoAsync(TeamBillableInfoParameter parameter)
    {
        return await this.SendAsync<TeamBillableInfoParameter, TeamBillableInfoResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/team.billableInfo
    /// </summary>
    public async ValueTask<TeamBillableInfoResponse> TeamBillableInfoAsync(TeamBillableInfoParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<TeamBillableInfoParameter, TeamBillableInfoResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://api.slack.com/methods/team.billableInfo
    /// </summary>
    public async ValueTask<List<TeamBillableInfoResponse>> TeamBillableInfoAsync(PagingContext<TeamBillableInfoResponse> context)
    {
        var p = new TeamBillableInfoParameter();
        return await this.SendBatchAsync(p, context, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/team.billableInfo
    /// </summary>
    public async ValueTask<List<TeamBillableInfoResponse>> TeamBillableInfoAsync(CancellationToken cancellationToken, PagingContext<TeamBillableInfoResponse> context)
    {
        var p = new TeamBillableInfoParameter();
        return await this.SendBatchAsync(p, context, cancellationToken);
    }
    /// <summary>
    /// https://api.slack.com/methods/team.billableInfo
    /// </summary>
    public async ValueTask<List<TeamBillableInfoResponse>> TeamBillableInfoAsync(TeamBillableInfoParameter parameter, PagingContext<TeamBillableInfoResponse> context)
    {
        return await this.SendBatchAsync(parameter, context, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/team.billableInfo
    /// </summary>
    public async ValueTask<List<TeamBillableInfoResponse>> TeamBillableInfoAsync(TeamBillableInfoParameter parameter, PagingContext<TeamBillableInfoResponse> context, CancellationToken cancellationToken)
    {
        return await this.SendBatchAsync(parameter, context, cancellationToken);
    }
}
