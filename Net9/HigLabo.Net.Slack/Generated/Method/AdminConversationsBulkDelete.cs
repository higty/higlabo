using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack;

public partial class AdminConversationsBulkDeleteParameter : IRestApiParameter
{
    string IRestApiParameter.ApiPath { get; } = "admin.conversations.bulkDelete";
    string IRestApiParameter.HttpMethod { get; } = "GET";
    public string? Channel_Ids { get; set; }
}
public partial class AdminConversationsBulkDeleteResponse : RestApiResponse
{
}
/// <summary>
/// https://api.slack.com/methods/admin.conversations.bulkDelete
/// </summary>
public partial class SlackClient
{
    /// <summary>
    /// https://api.slack.com/methods/admin.conversations.bulkDelete
    /// </summary>
    public async ValueTask<AdminConversationsBulkDeleteResponse> AdminConversationsBulkDeleteAsync(string? channel_Ids)
    {
        var p = new AdminConversationsBulkDeleteParameter();
        p.Channel_Ids = channel_Ids;
        return await this.SendAsync<AdminConversationsBulkDeleteParameter, AdminConversationsBulkDeleteResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.conversations.bulkDelete
    /// </summary>
    public async ValueTask<AdminConversationsBulkDeleteResponse> AdminConversationsBulkDeleteAsync(string? channel_Ids, CancellationToken cancellationToken)
    {
        var p = new AdminConversationsBulkDeleteParameter();
        p.Channel_Ids = channel_Ids;
        return await this.SendAsync<AdminConversationsBulkDeleteParameter, AdminConversationsBulkDeleteResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.conversations.bulkDelete
    /// </summary>
    public async ValueTask<AdminConversationsBulkDeleteResponse> AdminConversationsBulkDeleteAsync(AdminConversationsBulkDeleteParameter parameter)
    {
        return await this.SendAsync<AdminConversationsBulkDeleteParameter, AdminConversationsBulkDeleteResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.conversations.bulkDelete
    /// </summary>
    public async ValueTask<AdminConversationsBulkDeleteResponse> AdminConversationsBulkDeleteAsync(AdminConversationsBulkDeleteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<AdminConversationsBulkDeleteParameter, AdminConversationsBulkDeleteResponse>(parameter, cancellationToken);
    }
}
