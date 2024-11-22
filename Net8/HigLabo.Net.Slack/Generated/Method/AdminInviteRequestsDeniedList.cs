using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack;

public partial class AdminInviteRequestsDeniedListParameter : IRestApiParameter, IRestApiPagingParameter
{
    string IRestApiParameter.ApiPath { get; } = "admin.inviteRequests.denied.list";
    string IRestApiParameter.HttpMethod { get; } = "POST";
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
}
public partial class AdminInviteRequestsDeniedListResponse : RestApiResponse
{
}
/// <summary>
/// https://api.slack.com/methods/admin.inviteRequests.denied.list
/// </summary>
public partial class SlackClient
{
    /// <summary>
    /// https://api.slack.com/methods/admin.inviteRequests.denied.list
    /// </summary>
    public async ValueTask<AdminInviteRequestsDeniedListResponse> AdminInviteRequestsDeniedListAsync()
    {
        var p = new AdminInviteRequestsDeniedListParameter();
        return await this.SendAsync<AdminInviteRequestsDeniedListParameter, AdminInviteRequestsDeniedListResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.inviteRequests.denied.list
    /// </summary>
    public async ValueTask<AdminInviteRequestsDeniedListResponse> AdminInviteRequestsDeniedListAsync(CancellationToken cancellationToken)
    {
        var p = new AdminInviteRequestsDeniedListParameter();
        return await this.SendAsync<AdminInviteRequestsDeniedListParameter, AdminInviteRequestsDeniedListResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.inviteRequests.denied.list
    /// </summary>
    public async ValueTask<AdminInviteRequestsDeniedListResponse> AdminInviteRequestsDeniedListAsync(AdminInviteRequestsDeniedListParameter parameter)
    {
        return await this.SendAsync<AdminInviteRequestsDeniedListParameter, AdminInviteRequestsDeniedListResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.inviteRequests.denied.list
    /// </summary>
    public async ValueTask<AdminInviteRequestsDeniedListResponse> AdminInviteRequestsDeniedListAsync(AdminInviteRequestsDeniedListParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<AdminInviteRequestsDeniedListParameter, AdminInviteRequestsDeniedListResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.inviteRequests.denied.list
    /// </summary>
    public async ValueTask<List<AdminInviteRequestsDeniedListResponse>> AdminInviteRequestsDeniedListAsync(PagingContext<AdminInviteRequestsDeniedListResponse> context)
    {
        var p = new AdminInviteRequestsDeniedListParameter();
        return await this.SendBatchAsync(p, context, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.inviteRequests.denied.list
    /// </summary>
    public async ValueTask<List<AdminInviteRequestsDeniedListResponse>> AdminInviteRequestsDeniedListAsync(CancellationToken cancellationToken, PagingContext<AdminInviteRequestsDeniedListResponse> context)
    {
        var p = new AdminInviteRequestsDeniedListParameter();
        return await this.SendBatchAsync(p, context, cancellationToken);
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.inviteRequests.denied.list
    /// </summary>
    public async ValueTask<List<AdminInviteRequestsDeniedListResponse>> AdminInviteRequestsDeniedListAsync(AdminInviteRequestsDeniedListParameter parameter, PagingContext<AdminInviteRequestsDeniedListResponse> context)
    {
        return await this.SendBatchAsync(parameter, context, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.inviteRequests.denied.list
    /// </summary>
    public async ValueTask<List<AdminInviteRequestsDeniedListResponse>> AdminInviteRequestsDeniedListAsync(AdminInviteRequestsDeniedListParameter parameter, PagingContext<AdminInviteRequestsDeniedListResponse> context, CancellationToken cancellationToken)
    {
        return await this.SendBatchAsync(parameter, context, cancellationToken);
    }
}
