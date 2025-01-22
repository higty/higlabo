using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack;

public partial class AuthTeamsListParameter : IRestApiParameter, IRestApiPagingParameter
{
    string IRestApiParameter.ApiPath { get; } = "auth.teams.list";
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
    public bool? Include_Icon { get; set; }
    public int? Limit { get; set; }
}
public partial class AuthTeamsListResponse : RestApiResponse
{
}
/// <summary>
/// https://api.slack.com/methods/auth.teams.list
/// </summary>
public partial class SlackClient
{
    /// <summary>
    /// https://api.slack.com/methods/auth.teams.list
    /// </summary>
    public async ValueTask<AuthTeamsListResponse> AuthTeamsListAsync()
    {
        var p = new AuthTeamsListParameter();
        return await this.SendAsync<AuthTeamsListParameter, AuthTeamsListResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/auth.teams.list
    /// </summary>
    public async ValueTask<AuthTeamsListResponse> AuthTeamsListAsync(CancellationToken cancellationToken)
    {
        var p = new AuthTeamsListParameter();
        return await this.SendAsync<AuthTeamsListParameter, AuthTeamsListResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://api.slack.com/methods/auth.teams.list
    /// </summary>
    public async ValueTask<AuthTeamsListResponse> AuthTeamsListAsync(AuthTeamsListParameter parameter)
    {
        return await this.SendAsync<AuthTeamsListParameter, AuthTeamsListResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/auth.teams.list
    /// </summary>
    public async ValueTask<AuthTeamsListResponse> AuthTeamsListAsync(AuthTeamsListParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<AuthTeamsListParameter, AuthTeamsListResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://api.slack.com/methods/auth.teams.list
    /// </summary>
    public async ValueTask<List<AuthTeamsListResponse>> AuthTeamsListAsync(PagingContext<AuthTeamsListResponse> context)
    {
        var p = new AuthTeamsListParameter();
        return await this.SendBatchAsync(p, context, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/auth.teams.list
    /// </summary>
    public async ValueTask<List<AuthTeamsListResponse>> AuthTeamsListAsync(CancellationToken cancellationToken, PagingContext<AuthTeamsListResponse> context)
    {
        var p = new AuthTeamsListParameter();
        return await this.SendBatchAsync(p, context, cancellationToken);
    }
    /// <summary>
    /// https://api.slack.com/methods/auth.teams.list
    /// </summary>
    public async ValueTask<List<AuthTeamsListResponse>> AuthTeamsListAsync(AuthTeamsListParameter parameter, PagingContext<AuthTeamsListResponse> context)
    {
        return await this.SendBatchAsync(parameter, context, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/auth.teams.list
    /// </summary>
    public async ValueTask<List<AuthTeamsListResponse>> AuthTeamsListAsync(AuthTeamsListParameter parameter, PagingContext<AuthTeamsListResponse> context, CancellationToken cancellationToken)
    {
        return await this.SendBatchAsync(parameter, context, cancellationToken);
    }
}
