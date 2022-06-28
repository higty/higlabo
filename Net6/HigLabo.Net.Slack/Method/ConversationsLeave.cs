
namespace HigLabo.Net.Slack
{
    public class ConversationsLeaveParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "conversations.leave";
        public string HttpMethod { get; private set; } = "POST";
        public string Channel { get; set; } = "";
    }
    public partial class ConversationsLeaveResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<ConversationsLeaveResponse> ConversationsLeaveAsync(string channel)
        {
            var p = new ConversationsLeaveParameter();
            p.Channel = channel;
            return await this.SendAsync<ConversationsLeaveParameter, ConversationsLeaveResponse>(p, CancellationToken.None);
        }
        public async Task<ConversationsLeaveResponse> ConversationsLeaveAsync(string channel, CancellationToken cancellationToken)
        {
            var p = new ConversationsLeaveParameter();
            p.Channel = channel;
            return await this.SendAsync<ConversationsLeaveParameter, ConversationsLeaveResponse>(p, cancellationToken);
        }
        public async Task<ConversationsLeaveResponse> ConversationsLeaveAsync(ConversationsLeaveParameter parameter)
        {
            return await this.SendAsync<ConversationsLeaveParameter, ConversationsLeaveResponse>(parameter, CancellationToken.None);
        }
        public async Task<ConversationsLeaveResponse> ConversationsLeaveAsync(ConversationsLeaveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConversationsLeaveParameter, ConversationsLeaveResponse>(parameter, cancellationToken);
        }
    }
}
