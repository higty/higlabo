using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    /// <summary>
    /// https://api.slack.com/methods/chat.meMessage
    /// </summary>
    public partial class ChatMeMessageParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "chat.meMessage";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Channel { get; set; }
        public string? Text { get; set; }
    }
    public partial class ChatMeMessageResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/chat.meMessage
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/chat.meMessage
        /// </summary>
        public async ValueTask<ChatMeMessageResponse> ChatMeMessageAsync(string? channel, string? text)
        {
            var p = new ChatMeMessageParameter();
            p.Channel = channel;
            p.Text = text;
            return await this.SendAsync<ChatMeMessageParameter, ChatMeMessageResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/chat.meMessage
        /// </summary>
        public async ValueTask<ChatMeMessageResponse> ChatMeMessageAsync(string? channel, string? text, CancellationToken cancellationToken)
        {
            var p = new ChatMeMessageParameter();
            p.Channel = channel;
            p.Text = text;
            return await this.SendAsync<ChatMeMessageParameter, ChatMeMessageResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/chat.meMessage
        /// </summary>
        public async ValueTask<ChatMeMessageResponse> ChatMeMessageAsync(ChatMeMessageParameter parameter)
        {
            return await this.SendAsync<ChatMeMessageParameter, ChatMeMessageResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/chat.meMessage
        /// </summary>
        public async ValueTask<ChatMeMessageResponse> ChatMeMessageAsync(ChatMeMessageParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatMeMessageParameter, ChatMeMessageResponse>(parameter, cancellationToken);
        }
    }
}
