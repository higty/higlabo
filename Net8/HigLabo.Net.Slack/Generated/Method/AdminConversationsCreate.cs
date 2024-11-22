using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack;

public partial class AdminConversationsCreateParameter : IRestApiParameter
{
    string IRestApiParameter.ApiPath { get; } = "admin.conversations.create";
    string IRestApiParameter.HttpMethod { get; } = "POST";
    public bool? Is_Private { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool? Org_Wide { get; set; }
    public string? Team_Id { get; set; }
}
public partial class AdminConversationsCreateResponse : RestApiResponse
{
}
/// <summary>
/// https://api.slack.com/methods/admin.conversations.create
/// </summary>
public partial class SlackClient
{
    /// <summary>
    /// https://api.slack.com/methods/admin.conversations.create
    /// </summary>
    public async ValueTask<AdminConversationsCreateResponse> AdminConversationsCreateAsync(bool? is_Private, string? name)
    {
        var p = new AdminConversationsCreateParameter();
        p.Is_Private = is_Private;
        p.Name = name;
        return await this.SendAsync<AdminConversationsCreateParameter, AdminConversationsCreateResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.conversations.create
    /// </summary>
    public async ValueTask<AdminConversationsCreateResponse> AdminConversationsCreateAsync(bool? is_Private, string? name, CancellationToken cancellationToken)
    {
        var p = new AdminConversationsCreateParameter();
        p.Is_Private = is_Private;
        p.Name = name;
        return await this.SendAsync<AdminConversationsCreateParameter, AdminConversationsCreateResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.conversations.create
    /// </summary>
    public async ValueTask<AdminConversationsCreateResponse> AdminConversationsCreateAsync(AdminConversationsCreateParameter parameter)
    {
        return await this.SendAsync<AdminConversationsCreateParameter, AdminConversationsCreateResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.conversations.create
    /// </summary>
    public async ValueTask<AdminConversationsCreateResponse> AdminConversationsCreateAsync(AdminConversationsCreateParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<AdminConversationsCreateParameter, AdminConversationsCreateResponse>(parameter, cancellationToken);
    }
}
