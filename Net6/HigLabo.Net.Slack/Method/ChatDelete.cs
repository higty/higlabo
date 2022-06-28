
namespace HigLabo.Net.Slack
{
    public class ChatDeleteParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "chat.delete";
        public string HttpMethod { get; private set; } = "POST";
        public string Channel { get; set; } = "";
        public string Ts { get; set; } = "";
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
