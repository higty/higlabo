
namespace HigLabo.Net.Slack
{
    public partial class ChatUpdateParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "chat.update";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Channel { get; set; }
        public string Ts { get; set; }
        public bool? As_User { get; set; }
        public string Attachments { get; set; }
        public string Blocks { get; set; }
        public string File_Ids { get; set; }
        public bool? Link_Names { get; set; }
        public string Metadata { get; set; }
        public string Parse { get; set; }
        public bool? Reply_Broadcast { get; set; }
        public string Text { get; set; }
    }
    public partial class ChatUpdateResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<ChatUpdateResponse> ChatUpdateAsync(string channel, string ts)
        {
            var p = new ChatUpdateParameter();
            p.Channel = channel;
            p.Ts = ts;
            return await this.SendAsync<ChatUpdateParameter, ChatUpdateResponse>(p, CancellationToken.None);
        }
        public async Task<ChatUpdateResponse> ChatUpdateAsync(string channel, string ts, CancellationToken cancellationToken)
        {
            var p = new ChatUpdateParameter();
            p.Channel = channel;
            p.Ts = ts;
            return await this.SendAsync<ChatUpdateParameter, ChatUpdateResponse>(p, cancellationToken);
        }
        public async Task<ChatUpdateResponse> ChatUpdateAsync(ChatUpdateParameter parameter)
        {
            return await this.SendAsync<ChatUpdateParameter, ChatUpdateResponse>(parameter, CancellationToken.None);
        }
        public async Task<ChatUpdateResponse> ChatUpdateAsync(ChatUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatUpdateParameter, ChatUpdateResponse>(parameter, cancellationToken);
        }
    }
}
