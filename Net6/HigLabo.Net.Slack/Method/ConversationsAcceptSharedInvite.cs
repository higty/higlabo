
namespace HigLabo.Net.Slack
{
    public class ConversationsAcceptSharedInviteParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "conversations.acceptSharedInvite";
        public string HttpMethod { get; private set; } = "POST";
        public string Channel_Name { get; set; } = "";
        public string Channel_Id { get; set; } = "";
        public bool? Free_Trial_Accepted { get; set; }
        public string Invite_Id { get; set; } = "";
        public bool? Is_Private { get; set; }
        public string Team_Id { get; set; } = "";
    }
    public partial class ConversationsAcceptSharedInviteResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<ConversationsAcceptSharedInviteResponse> ConversationsAcceptSharedInviteAsync(string channel_Name)
        {
            var p = new ConversationsAcceptSharedInviteParameter();
            p.Channel_Name = channel_Name;
            return await this.SendAsync<ConversationsAcceptSharedInviteParameter, ConversationsAcceptSharedInviteResponse>(p, CancellationToken.None);
        }
        public async Task<ConversationsAcceptSharedInviteResponse> ConversationsAcceptSharedInviteAsync(string channel_Name, CancellationToken cancellationToken)
        {
            var p = new ConversationsAcceptSharedInviteParameter();
            p.Channel_Name = channel_Name;
            return await this.SendAsync<ConversationsAcceptSharedInviteParameter, ConversationsAcceptSharedInviteResponse>(p, cancellationToken);
        }
        public async Task<ConversationsAcceptSharedInviteResponse> ConversationsAcceptSharedInviteAsync(ConversationsAcceptSharedInviteParameter parameter)
        {
            return await this.SendAsync<ConversationsAcceptSharedInviteParameter, ConversationsAcceptSharedInviteResponse>(parameter, CancellationToken.None);
        }
        public async Task<ConversationsAcceptSharedInviteResponse> ConversationsAcceptSharedInviteAsync(ConversationsAcceptSharedInviteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConversationsAcceptSharedInviteParameter, ConversationsAcceptSharedInviteResponse>(parameter, cancellationToken);
        }
    }
}
