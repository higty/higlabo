using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack;

public partial class ConversationsInviteParameter : IRestApiParameter
{
    string IRestApiParameter.ApiPath { get; } = "conversations.invite";
    string IRestApiParameter.HttpMethod { get; } = "POST";
    public string? Channel { get; set; }
    public string? Users { get; set; }
}
public partial class ConversationsInviteResponse : RestApiResponse
{
}
/// <summary>
/// https://api.slack.com/methods/conversations.invite
/// </summary>
public partial class SlackClient
{
    /// <summary>
    /// https://api.slack.com/methods/conversations.invite
    /// </summary>
    public async ValueTask<ConversationsInviteResponse> ConversationsInviteAsync(string? channel, string? users)
    {
        var p = new ConversationsInviteParameter();
        p.Channel = channel;
        p.Users = users;
        return await this.SendAsync<ConversationsInviteParameter, ConversationsInviteResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/conversations.invite
    /// </summary>
    public async ValueTask<ConversationsInviteResponse> ConversationsInviteAsync(string? channel, string? users, CancellationToken cancellationToken)
    {
        var p = new ConversationsInviteParameter();
        p.Channel = channel;
        p.Users = users;
        return await this.SendAsync<ConversationsInviteParameter, ConversationsInviteResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://api.slack.com/methods/conversations.invite
    /// </summary>
    public async ValueTask<ConversationsInviteResponse> ConversationsInviteAsync(ConversationsInviteParameter parameter)
    {
        return await this.SendAsync<ConversationsInviteParameter, ConversationsInviteResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/conversations.invite
    /// </summary>
    public async ValueTask<ConversationsInviteResponse> ConversationsInviteAsync(ConversationsInviteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ConversationsInviteParameter, ConversationsInviteResponse>(parameter, cancellationToken);
    }
}
