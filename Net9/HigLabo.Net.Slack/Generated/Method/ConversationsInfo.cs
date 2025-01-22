using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack;

public partial class ConversationsInfoParameter : IRestApiParameter
{
    string IRestApiParameter.ApiPath { get; } = "conversations.info";
    string IRestApiParameter.HttpMethod { get; } = "GET";
    public string? Channel { get; set; }
    public bool? Include_Locale { get; set; }
    public bool? Include_Num_Members { get; set; }
}
public partial class ConversationsInfoResponse : RestApiResponse
{
}
/// <summary>
/// https://api.slack.com/methods/conversations.info
/// </summary>
public partial class SlackClient
{
    /// <summary>
    /// https://api.slack.com/methods/conversations.info
    /// </summary>
    public async ValueTask<ConversationsInfoResponse> ConversationsInfoAsync(string? channel)
    {
        var p = new ConversationsInfoParameter();
        p.Channel = channel;
        return await this.SendAsync<ConversationsInfoParameter, ConversationsInfoResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/conversations.info
    /// </summary>
    public async ValueTask<ConversationsInfoResponse> ConversationsInfoAsync(string? channel, CancellationToken cancellationToken)
    {
        var p = new ConversationsInfoParameter();
        p.Channel = channel;
        return await this.SendAsync<ConversationsInfoParameter, ConversationsInfoResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://api.slack.com/methods/conversations.info
    /// </summary>
    public async ValueTask<ConversationsInfoResponse> ConversationsInfoAsync(ConversationsInfoParameter parameter)
    {
        return await this.SendAsync<ConversationsInfoParameter, ConversationsInfoResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/conversations.info
    /// </summary>
    public async ValueTask<ConversationsInfoResponse> ConversationsInfoAsync(ConversationsInfoParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ConversationsInfoParameter, ConversationsInfoResponse>(parameter, cancellationToken);
    }
}
