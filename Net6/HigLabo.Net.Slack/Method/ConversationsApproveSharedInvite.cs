
namespace HigLabo.Net.Slack
{
    public class ConversationsApproveSharedInviteParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "conversations.approveSharedInvite";
        public string HttpMethod { get; private set; } = "POST";
        public string Invite_Id { get; set; } = "";
        public string Target_Team { get; set; } = "";
    }
    public partial class ConversationsApproveSharedInviteResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<ConversationsApproveSharedInviteResponse> ConversationsApproveSharedInviteAsync(string invite_Id)
        {
            var p = new ConversationsApproveSharedInviteParameter();
            p.Invite_Id = invite_Id;
            return await this.SendAsync<ConversationsApproveSharedInviteParameter, ConversationsApproveSharedInviteResponse>(p, CancellationToken.None);
        }
        public async Task<ConversationsApproveSharedInviteResponse> ConversationsApproveSharedInviteAsync(string invite_Id, CancellationToken cancellationToken)
        {
            var p = new ConversationsApproveSharedInviteParameter();
            p.Invite_Id = invite_Id;
            return await this.SendAsync<ConversationsApproveSharedInviteParameter, ConversationsApproveSharedInviteResponse>(p, cancellationToken);
        }
        public async Task<ConversationsApproveSharedInviteResponse> ConversationsApproveSharedInviteAsync(ConversationsApproveSharedInviteParameter parameter)
        {
            return await this.SendAsync<ConversationsApproveSharedInviteParameter, ConversationsApproveSharedInviteResponse>(parameter, CancellationToken.None);
        }
        public async Task<ConversationsApproveSharedInviteResponse> ConversationsApproveSharedInviteAsync(ConversationsApproveSharedInviteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConversationsApproveSharedInviteParameter, ConversationsApproveSharedInviteResponse>(parameter, cancellationToken);
        }
    }
}
