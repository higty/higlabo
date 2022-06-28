
namespace HigLabo.Net.Slack
{
    public class ConversationsCloseParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "conversations.close";
        public string HttpMethod { get; private set; } = "POST";
        public string Channel { get; set; } = "";
    }
    public partial class ConversationsCloseResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<ConversationsCloseResponse> ConversationsCloseAsync(string channel)
        {
            var p = new ConversationsCloseParameter();
            p.Channel = channel;
            return await this.SendAsync<ConversationsCloseParameter, ConversationsCloseResponse>(p, CancellationToken.None);
        }
        public async Task<ConversationsCloseResponse> ConversationsCloseAsync(string channel, CancellationToken cancellationToken)
        {
            var p = new ConversationsCloseParameter();
            p.Channel = channel;
            return await this.SendAsync<ConversationsCloseParameter, ConversationsCloseResponse>(p, cancellationToken);
        }
        public async Task<ConversationsCloseResponse> ConversationsCloseAsync(ConversationsCloseParameter parameter)
        {
            return await this.SendAsync<ConversationsCloseParameter, ConversationsCloseResponse>(parameter, CancellationToken.None);
        }
        public async Task<ConversationsCloseResponse> ConversationsCloseAsync(ConversationsCloseParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConversationsCloseParameter, ConversationsCloseResponse>(parameter, cancellationToken);
        }
    }
}
