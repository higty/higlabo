using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack;

public partial class ConversationsDeclineSharedInviteParameter : IRestApiParameter
{
    string IRestApiParameter.ApiPath { get; } = "conversations.declineSharedInvite";
    string IRestApiParameter.HttpMethod { get; } = "GET";
    public string? Invite_Id { get; set; }
    public string? Target_Team { get; set; }
}
public partial class ConversationsDeclineSharedInviteResponse : RestApiResponse
{
}
/// <summary>
/// https://api.slack.com/methods/conversations.declineSharedInvite
/// </summary>
public partial class SlackClient
{
    /// <summary>
    /// https://api.slack.com/methods/conversations.declineSharedInvite
    /// </summary>
    public async ValueTask<ConversationsDeclineSharedInviteResponse> ConversationsDeclineSharedInviteAsync(string? invite_Id)
    {
        var p = new ConversationsDeclineSharedInviteParameter();
        p.Invite_Id = invite_Id;
        return await this.SendAsync<ConversationsDeclineSharedInviteParameter, ConversationsDeclineSharedInviteResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/conversations.declineSharedInvite
    /// </summary>
    public async ValueTask<ConversationsDeclineSharedInviteResponse> ConversationsDeclineSharedInviteAsync(string? invite_Id, CancellationToken cancellationToken)
    {
        var p = new ConversationsDeclineSharedInviteParameter();
        p.Invite_Id = invite_Id;
        return await this.SendAsync<ConversationsDeclineSharedInviteParameter, ConversationsDeclineSharedInviteResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://api.slack.com/methods/conversations.declineSharedInvite
    /// </summary>
    public async ValueTask<ConversationsDeclineSharedInviteResponse> ConversationsDeclineSharedInviteAsync(ConversationsDeclineSharedInviteParameter parameter)
    {
        return await this.SendAsync<ConversationsDeclineSharedInviteParameter, ConversationsDeclineSharedInviteResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/conversations.declineSharedInvite
    /// </summary>
    public async ValueTask<ConversationsDeclineSharedInviteResponse> ConversationsDeclineSharedInviteAsync(ConversationsDeclineSharedInviteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ConversationsDeclineSharedInviteParameter, ConversationsDeclineSharedInviteResponse>(parameter, cancellationToken);
    }
}
