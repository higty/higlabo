
namespace HigLabo.Net.Slack
{
    public partial class ChatMeMessageParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "chat.meMessage";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Channel { get; set; }
        public string Text { get; set; }
    }
    public partial class ChatMeMessageResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<ChatMeMessageResponse> ChatMeMessageAsync(string channel, string text)
        {
            var p = new ChatMeMessageParameter();
            p.Channel = channel;
            p.Text = text;
            return await this.SendAsync<ChatMeMessageParameter, ChatMeMessageResponse>(p, CancellationToken.None);
        }
        public async Task<ChatMeMessageResponse> ChatMeMessageAsync(string channel, string text, CancellationToken cancellationToken)
        {
            var p = new ChatMeMessageParameter();
            p.Channel = channel;
            p.Text = text;
            return await this.SendAsync<ChatMeMessageParameter, ChatMeMessageResponse>(p, cancellationToken);
        }
        public async Task<ChatMeMessageResponse> ChatMeMessageAsync(ChatMeMessageParameter parameter)
        {
            return await this.SendAsync<ChatMeMessageParameter, ChatMeMessageResponse>(parameter, CancellationToken.None);
        }
        public async Task<ChatMeMessageResponse> ChatMeMessageAsync(ChatMeMessageParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatMeMessageParameter, ChatMeMessageResponse>(parameter, cancellationToken);
        }
    }
}
