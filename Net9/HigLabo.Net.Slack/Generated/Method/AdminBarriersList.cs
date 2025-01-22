using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack;

public partial class AdminBarriersListParameter : IRestApiParameter, IRestApiPagingParameter
{
    string IRestApiParameter.ApiPath { get; } = "admin.barriers.list";
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
}
public partial class AdminBarriersListResponse : RestApiResponse
{
}
/// <summary>
/// https://api.slack.com/methods/admin.barriers.list
/// </summary>
public partial class SlackClient
{
    /// <summary>
    /// https://api.slack.com/methods/admin.barriers.list
    /// </summary>
    public async ValueTask<AdminBarriersListResponse> AdminBarriersListAsync()
    {
        var p = new AdminBarriersListParameter();
        return await this.SendAsync<AdminBarriersListParameter, AdminBarriersListResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.barriers.list
    /// </summary>
    public async ValueTask<AdminBarriersListResponse> AdminBarriersListAsync(CancellationToken cancellationToken)
    {
        var p = new AdminBarriersListParameter();
        return await this.SendAsync<AdminBarriersListParameter, AdminBarriersListResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.barriers.list
    /// </summary>
    public async ValueTask<AdminBarriersListResponse> AdminBarriersListAsync(AdminBarriersListParameter parameter)
    {
        return await this.SendAsync<AdminBarriersListParameter, AdminBarriersListResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.barriers.list
    /// </summary>
    public async ValueTask<AdminBarriersListResponse> AdminBarriersListAsync(AdminBarriersListParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<AdminBarriersListParameter, AdminBarriersListResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.barriers.list
    /// </summary>
    public async ValueTask<List<AdminBarriersListResponse>> AdminBarriersListAsync(PagingContext<AdminBarriersListResponse> context)
    {
        var p = new AdminBarriersListParameter();
        return await this.SendBatchAsync(p, context, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.barriers.list
    /// </summary>
    public async ValueTask<List<AdminBarriersListResponse>> AdminBarriersListAsync(CancellationToken cancellationToken, PagingContext<AdminBarriersListResponse> context)
    {
        var p = new AdminBarriersListParameter();
        return await this.SendBatchAsync(p, context, cancellationToken);
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.barriers.list
    /// </summary>
    public async ValueTask<List<AdminBarriersListResponse>> AdminBarriersListAsync(AdminBarriersListParameter parameter, PagingContext<AdminBarriersListResponse> context)
    {
        return await this.SendBatchAsync(parameter, context, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.barriers.list
    /// </summary>
    public async ValueTask<List<AdminBarriersListResponse>> AdminBarriersListAsync(AdminBarriersListParameter parameter, PagingContext<AdminBarriersListResponse> context, CancellationToken cancellationToken)
    {
        return await this.SendBatchAsync(parameter, context, cancellationToken);
    }
}
