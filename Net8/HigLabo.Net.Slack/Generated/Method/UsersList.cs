using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack;

public partial class UsersListParameter : IRestApiParameter, IRestApiPagingParameter
{
    string IRestApiParameter.ApiPath { get; } = "users.list";
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
    public bool? Include_Locale { get; set; }
    public double? Limit { get; set; }
    public string? Team_Id { get; set; }
}
public partial class UsersListResponse : RestApiResponse
{
}
/// <summary>
/// https://api.slack.com/methods/users.list
/// </summary>
public partial class SlackClient
{
    /// <summary>
    /// https://api.slack.com/methods/users.list
    /// </summary>
    public async ValueTask<UsersListResponse> UsersListAsync()
    {
        var p = new UsersListParameter();
        return await this.SendAsync<UsersListParameter, UsersListResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/users.list
    /// </summary>
    public async ValueTask<UsersListResponse> UsersListAsync(CancellationToken cancellationToken)
    {
        var p = new UsersListParameter();
        return await this.SendAsync<UsersListParameter, UsersListResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://api.slack.com/methods/users.list
    /// </summary>
    public async ValueTask<UsersListResponse> UsersListAsync(UsersListParameter parameter)
    {
        return await this.SendAsync<UsersListParameter, UsersListResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/users.list
    /// </summary>
    public async ValueTask<UsersListResponse> UsersListAsync(UsersListParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<UsersListParameter, UsersListResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://api.slack.com/methods/users.list
    /// </summary>
    public async ValueTask<List<UsersListResponse>> UsersListAsync(PagingContext<UsersListResponse> context)
    {
        var p = new UsersListParameter();
        return await this.SendBatchAsync(p, context, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/users.list
    /// </summary>
    public async ValueTask<List<UsersListResponse>> UsersListAsync(CancellationToken cancellationToken, PagingContext<UsersListResponse> context)
    {
        var p = new UsersListParameter();
        return await this.SendBatchAsync(p, context, cancellationToken);
    }
    /// <summary>
    /// https://api.slack.com/methods/users.list
    /// </summary>
    public async ValueTask<List<UsersListResponse>> UsersListAsync(UsersListParameter parameter, PagingContext<UsersListResponse> context)
    {
        return await this.SendBatchAsync(parameter, context, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/users.list
    /// </summary>
    public async ValueTask<List<UsersListResponse>> UsersListAsync(UsersListParameter parameter, PagingContext<UsersListResponse> context, CancellationToken cancellationToken)
    {
        return await this.SendBatchAsync(parameter, context, cancellationToken);
    }
}
