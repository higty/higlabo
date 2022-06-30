
namespace HigLabo.Net.Slack
{
    public partial class ChatDeleteParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "chat.delete";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Channel { get; set; }
        public string Ts { get; set; }
        public bool? As_User { get; set; }
    }
    public partial class ChatDeleteResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<ChatDeleteResponse> ChatDeleteAsync(string channel, string ts)
        {
            var p = new ChatDeleteParameter();
            p.Channel = channel;
            p.Ts = ts;
            return await this.SendAsync<ChatDeleteParameter, ChatDeleteResponse>(p, CancellationToken.None);
        }
        public async Task<ChatDeleteResponse> ChatDeleteAsync(string channel, string ts, CancellationToken cancellationToken)
        {
            var p = new ChatDeleteParameter();
            p.Channel = channel;
            p.Ts = ts;
            return await this.SendAsync<ChatDeleteParameter, ChatDeleteResponse>(p, cancellationToken);
        }
        public async Task<ChatDeleteResponse> ChatDeleteAsync(ChatDeleteParameter parameter)
        {
            return await this.SendAsync<ChatDeleteParameter, ChatDeleteResponse>(parameter, CancellationToken.None);
        }
        public async Task<ChatDeleteResponse> ChatDeleteAsync(ChatDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatDeleteParameter, ChatDeleteResponse>(parameter, cancellationToken);
        }
    }
}
