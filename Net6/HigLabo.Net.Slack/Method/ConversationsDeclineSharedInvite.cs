
namespace HigLabo.Net.Slack
{
    public class ConversationsDeclineSharedInviteParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "conversations.declineSharedInvite";
        public string HttpMethod { get; private set; } = "GET";
        public string Invite_Id { get; set; } = "";
        public string Target_Team { get; set; } = "";
    }
    public partial class ConversationsDeclineSharedInviteResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<ConversationsDeclineSharedInviteResponse> ConversationsDeclineSharedInviteAsync(string invite_Id)
        {
            var p = new ConversationsDeclineSharedInviteParameter();
            p.Invite_Id = invite_Id;
            return await this.SendAsync<ConversationsDeclineSharedInviteParameter, ConversationsDeclineSharedInviteResponse>(p, CancellationToken.None);
        }
        public async Task<ConversationsDeclineSharedInviteResponse> ConversationsDeclineSharedInviteAsync(string invite_Id, CancellationToken cancellationToken)
        {
            var p = new ConversationsDeclineSharedInviteParameter();
            p.Invite_Id = invite_Id;
            return await this.SendAsync<ConversationsDeclineSharedInviteParameter, ConversationsDeclineSharedInviteResponse>(p, cancellationToken);
        }
        public async Task<ConversationsDeclineSharedInviteResponse> ConversationsDeclineSharedInviteAsync(ConversationsDeclineSharedInviteParameter parameter)
        {
            return await this.SendAsync<ConversationsDeclineSharedInviteParameter, ConversationsDeclineSharedInviteResponse>(parameter, CancellationToken.None);
        }
        public async Task<ConversationsDeclineSharedInviteResponse> ConversationsDeclineSharedInviteAsync(ConversationsDeclineSharedInviteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConversationsDeclineSharedInviteParameter, ConversationsDeclineSharedInviteResponse>(parameter, cancellationToken);
        }
    }
}
