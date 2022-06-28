
namespace HigLabo.Net.Slack
{
    public class ConversationsInviteParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "conversations.invite";
        public string HttpMethod { get; private set; } = "POST";
        public string Channel { get; set; } = "";
        public string Users { get; set; } = "";
    }
    public partial class ConversationsInviteResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<ConversationsInviteResponse> ConversationsInviteAsync(string channel, string users)
        {
            var p = new ConversationsInviteParameter();
            p.Channel = channel;
            p.Users = users;
            return await this.SendAsync<ConversationsInviteParameter, ConversationsInviteResponse>(p, CancellationToken.None);
        }
        public async Task<ConversationsInviteResponse> ConversationsInviteAsync(string channel, string users, CancellationToken cancellationToken)
        {
            var p = new ConversationsInviteParameter();
            p.Channel = channel;
            p.Users = users;
            return await this.SendAsync<ConversationsInviteParameter, ConversationsInviteResponse>(p, cancellationToken);
        }
        public async Task<ConversationsInviteResponse> ConversationsInviteAsync(ConversationsInviteParameter parameter)
        {
            return await this.SendAsync<ConversationsInviteParameter, ConversationsInviteResponse>(parameter, CancellationToken.None);
        }
        public async Task<ConversationsInviteResponse> ConversationsInviteAsync(ConversationsInviteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConversationsInviteParameter, ConversationsInviteResponse>(parameter, cancellationToken);
        }
    }
}
