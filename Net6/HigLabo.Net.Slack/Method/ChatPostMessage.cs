
namespace HigLabo.Net.Slack
{
    public partial class ChatPostMessageParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "chat.postMessage";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Channel { get; set; }
        public string Attachments { get; set; }
        public string Blocks { get; set; }
        public string Text { get; set; }
        public bool? As_User { get; set; }
        public string Icon_Emoji { get; set; }
        public string Icon_Url { get; set; }
        public bool? Link_Names { get; set; }
        public string Metadata { get; set; }
        public bool? Mrkdwn { get; set; }
        public string Parse { get; set; }
        public bool? Reply_Broadcast { get; set; }
        public string Thread_Ts { get; set; }
        public bool? Unfurl_Links { get; set; }
        public bool? Unfurl_Media { get; set; }
        public string Username { get; set; }
    }
    public partial class ChatPostMessageResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<ChatPostMessageResponse> ChatPostMessageAsync(string channel)
        {
            var p = new ChatPostMessageParameter();
            p.Channel = channel;
            return await this.SendAsync<ChatPostMessageParameter, ChatPostMessageResponse>(p, CancellationToken.None);
        }
        public async Task<ChatPostMessageResponse> ChatPostMessageAsync(string channel, CancellationToken cancellationToken)
        {
            var p = new ChatPostMessageParameter();
            p.Channel = channel;
            return await this.SendAsync<ChatPostMessageParameter, ChatPostMessageResponse>(p, cancellationToken);
        }
        public async Task<ChatPostMessageResponse> ChatPostMessageAsync(ChatPostMessageParameter parameter)
        {
            return await this.SendAsync<ChatPostMessageParameter, ChatPostMessageResponse>(parameter, CancellationToken.None);
        }
        public async Task<ChatPostMessageResponse> ChatPostMessageAsync(ChatPostMessageParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatPostMessageParameter, ChatPostMessageResponse>(parameter, cancellationToken);
        }
    }
}
