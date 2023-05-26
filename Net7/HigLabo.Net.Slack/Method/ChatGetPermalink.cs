using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class ChatGetPermalinkParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "chat.getPermalink";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string? Channel { get; set; }
        public string? Message_Ts { get; set; }
    }
    public partial class ChatGetPermalinkResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/chat.getPermalink
        /// </summary>
        public async Task<ChatGetPermalinkResponse> ChatGetPermalinkAsync(string? channel, string? message_Ts)
        {
            var p = new ChatGetPermalinkParameter();
            p.Channel = channel;
            p.Message_Ts = message_Ts;
            return await this.SendAsync<ChatGetPermalinkParameter, ChatGetPermalinkResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/chat.getPermalink
        /// </summary>
        public async Task<ChatGetPermalinkResponse> ChatGetPermalinkAsync(string? channel, string? message_Ts, CancellationToken cancellationToken)
        {
            var p = new ChatGetPermalinkParameter();
            p.Channel = channel;
            p.Message_Ts = message_Ts;
            return await this.SendAsync<ChatGetPermalinkParameter, ChatGetPermalinkResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/chat.getPermalink
        /// </summary>
        public async Task<ChatGetPermalinkResponse> ChatGetPermalinkAsync(ChatGetPermalinkParameter parameter)
        {
            return await this.SendAsync<ChatGetPermalinkParameter, ChatGetPermalinkResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/chat.getPermalink
        /// </summary>
        public async Task<ChatGetPermalinkResponse> ChatGetPermalinkAsync(ChatGetPermalinkParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatGetPermalinkParameter, ChatGetPermalinkResponse>(parameter, cancellationToken);
        }
    }
}
