
namespace HigLabo.Net.Slack
{
    public class ConversationsInviteSharedParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "conversations.inviteShared";
        public string HttpMethod { get; private set; } = "GET";
        public string Channel { get; set; } = "";
        public string Emails { get; set; } = "";
        public bool? External_Limited { get; set; }
        public string User_Ids { get; set; } = "";
    }
    public partial class ConversationsInviteSharedResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<ConversationsInviteSharedResponse> ConversationsInviteSharedAsync(string channel)
        {
            var p = new ConversationsInviteSharedParameter();
            p.Channel = channel;
            return await this.SendAsync<ConversationsInviteSharedParameter, ConversationsInviteSharedResponse>(p, CancellationToken.None);
        }
        public async Task<ConversationsInviteSharedResponse> ConversationsInviteSharedAsync(string channel, CancellationToken cancellationToken)
        {
            var p = new ConversationsInviteSharedParameter();
            p.Channel = channel;
            return await this.SendAsync<ConversationsInviteSharedParameter, ConversationsInviteSharedResponse>(p, cancellationToken);
        }
        public async Task<ConversationsInviteSharedResponse> ConversationsInviteSharedAsync(ConversationsInviteSharedParameter parameter)
        {
            return await this.SendAsync<ConversationsInviteSharedParameter, ConversationsInviteSharedResponse>(parameter, CancellationToken.None);
        }
        public async Task<ConversationsInviteSharedResponse> ConversationsInviteSharedAsync(ConversationsInviteSharedParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConversationsInviteSharedParameter, ConversationsInviteSharedResponse>(parameter, cancellationToken);
        }
    }
}
