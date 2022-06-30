
namespace HigLabo.Net.Slack
{
    public partial class ConversationsKickParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "conversations.kick";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Channel { get; set; }
        public string User { get; set; }
    }
    public partial class ConversationsKickResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<ConversationsKickResponse> ConversationsKickAsync(string channel, string user)
        {
            var p = new ConversationsKickParameter();
            p.Channel = channel;
            p.User = user;
            return await this.SendAsync<ConversationsKickParameter, ConversationsKickResponse>(p, CancellationToken.None);
        }
        public async Task<ConversationsKickResponse> ConversationsKickAsync(string channel, string user, CancellationToken cancellationToken)
        {
            var p = new ConversationsKickParameter();
            p.Channel = channel;
            p.User = user;
            return await this.SendAsync<ConversationsKickParameter, ConversationsKickResponse>(p, cancellationToken);
        }
        public async Task<ConversationsKickResponse> ConversationsKickAsync(ConversationsKickParameter parameter)
        {
            return await this.SendAsync<ConversationsKickParameter, ConversationsKickResponse>(parameter, CancellationToken.None);
        }
        public async Task<ConversationsKickResponse> ConversationsKickAsync(ConversationsKickParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConversationsKickParameter, ConversationsKickResponse>(parameter, cancellationToken);
        }
    }
}
