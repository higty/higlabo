using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack;

public partial class ConversationsRepliesParameter : IRestApiParameter, IRestApiPagingParameter
{
    string IRestApiParameter.ApiPath { get; } = "conversations.replies";
    string IRestApiParameter.HttpMethod { get; } = "GET";
    public string? Channel { get; set; }
    public string? Ts { get; set; }
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
    public bool? Include_All_Metadata { get; set; }
    public bool? Inclusive { get; set; }
    public string? Latest { get; set; }
    public double? Limit { get; set; }
    public string? Oldest { get; set; }
}
public partial class ConversationsRepliesResponse : RestApiResponse
{
}
/// <summary>
/// https://api.slack.com/methods/conversations.replies
/// </summary>
public partial class SlackClient
{
    /// <summary>
    /// https://api.slack.com/methods/conversations.replies
    /// </summary>
    public async ValueTask<ConversationsRepliesResponse> ConversationsRepliesAsync(string? channel, string? ts)
    {
        var p = new ConversationsRepliesParameter();
        p.Channel = channel;
        p.Ts = ts;
        return await this.SendAsync<ConversationsRepliesParameter, ConversationsRepliesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/conversations.replies
    /// </summary>
    public async ValueTask<ConversationsRepliesResponse> ConversationsRepliesAsync(string? channel, string? ts, CancellationToken cancellationToken)
    {
        var p = new ConversationsRepliesParameter();
        p.Channel = channel;
        p.Ts = ts;
        return await this.SendAsync<ConversationsRepliesParameter, ConversationsRepliesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://api.slack.com/methods/conversations.replies
    /// </summary>
    public async ValueTask<ConversationsRepliesResponse> ConversationsRepliesAsync(ConversationsRepliesParameter parameter)
    {
        return await this.SendAsync<ConversationsRepliesParameter, ConversationsRepliesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/conversations.replies
    /// </summary>
    public async ValueTask<ConversationsRepliesResponse> ConversationsRepliesAsync(ConversationsRepliesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ConversationsRepliesParameter, ConversationsRepliesResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://api.slack.com/methods/conversations.replies
    /// </summary>
    public async ValueTask<List<ConversationsRepliesResponse>> ConversationsRepliesAsync(string? channel, PagingContext<ConversationsRepliesResponse> context, string? ts)
    {
        var p = new ConversationsRepliesParameter();
        p.Channel = channel;
        p.Ts = ts;
        return await this.SendBatchAsync(p, context, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/conversations.replies
    /// </summary>
    public async ValueTask<List<ConversationsRepliesResponse>> ConversationsRepliesAsync(string? channel, PagingContext<ConversationsRepliesResponse> context, string? ts, CancellationToken cancellationToken)
    {
        var p = new ConversationsRepliesParameter();
        p.Channel = channel;
        p.Ts = ts;
        return await this.SendBatchAsync(p, context, cancellationToken);
    }
    /// <summary>
    /// https://api.slack.com/methods/conversations.replies
    /// </summary>
    public async ValueTask<List<ConversationsRepliesResponse>> ConversationsRepliesAsync(ConversationsRepliesParameter parameter, PagingContext<ConversationsRepliesResponse> context)
    {
        return await this.SendBatchAsync(parameter, context, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/conversations.replies
    /// </summary>
    public async ValueTask<List<ConversationsRepliesResponse>> ConversationsRepliesAsync(ConversationsRepliesParameter parameter, PagingContext<ConversationsRepliesResponse> context, CancellationToken cancellationToken)
    {
        return await this.SendBatchAsync(parameter, context, cancellationToken);
    }
}
