using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class ChatPostEphemeralParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "chat.postEphemeral";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Channel { get; set; }
        public string? Text { get; set; }
        public string? User { get; set; }
        public bool? As_User { get; set; }
        public string? Attachments { get; set; }
        public string? Blocks { get; set; }
        public string? Icon_Emoji { get; set; }
        public string? Icon_Url { get; set; }
        public bool? Link_Names { get; set; }
        public string? Parse { get; set; }
        public string? Thread_Ts { get; set; }
        public string? Username { get; set; }
    }
    public partial class ChatPostEphemeralResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/chat.postEphemeral
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/chat.postEphemeral
        /// </summary>
        public async Task<ChatPostEphemeralResponse> ChatPostEphemeralAsync(string? channel, string? text, string? user)
        {
            var p = new ChatPostEphemeralParameter();
            p.Channel = channel;
            p.Text = text;
            p.User = user;
            return await this.SendAsync<ChatPostEphemeralParameter, ChatPostEphemeralResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/chat.postEphemeral
        /// </summary>
        public async Task<ChatPostEphemeralResponse> ChatPostEphemeralAsync(string? channel, string? text, string? user, CancellationToken cancellationToken)
        {
            var p = new ChatPostEphemeralParameter();
            p.Channel = channel;
            p.Text = text;
            p.User = user;
            return await this.SendAsync<ChatPostEphemeralParameter, ChatPostEphemeralResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/chat.postEphemeral
        /// </summary>
        public async Task<ChatPostEphemeralResponse> ChatPostEphemeralAsync(ChatPostEphemeralParameter parameter)
        {
            return await this.SendAsync<ChatPostEphemeralParameter, ChatPostEphemeralResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/chat.postEphemeral
        /// </summary>
        public async Task<ChatPostEphemeralResponse> ChatPostEphemeralAsync(ChatPostEphemeralParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatPostEphemeralParameter, ChatPostEphemeralResponse>(parameter, cancellationToken);
        }
    }
}
