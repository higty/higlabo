
namespace HigLabo.Net.Slack
{
    public class ConversationsJoinParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "conversations.join";
        public string HttpMethod { get; private set; } = "POST";
        public string Channel { get; set; } = "";
    }
    public partial class ConversationsJoinResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<ConversationsJoinResponse> ConversationsJoinAsync(string channel)
        {
            var p = new ConversationsJoinParameter();
            p.Channel = channel;
            return await this.SendAsync<ConversationsJoinParameter, ConversationsJoinResponse>(p, CancellationToken.None);
        }
        public async Task<ConversationsJoinResponse> ConversationsJoinAsync(string channel, CancellationToken cancellationToken)
        {
            var p = new ConversationsJoinParameter();
            p.Channel = channel;
            return await this.SendAsync<ConversationsJoinParameter, ConversationsJoinResponse>(p, cancellationToken);
        }
        public async Task<ConversationsJoinResponse> ConversationsJoinAsync(ConversationsJoinParameter parameter)
        {
            return await this.SendAsync<ConversationsJoinParameter, ConversationsJoinResponse>(parameter, CancellationToken.None);
        }
        public async Task<ConversationsJoinResponse> ConversationsJoinAsync(ConversationsJoinParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConversationsJoinParameter, ConversationsJoinResponse>(parameter, cancellationToken);
        }
    }
}
