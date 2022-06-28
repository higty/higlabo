
namespace HigLabo.Net.Slack
{
    public class AdminConversationsDisconnectSharedParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "admin.conversations.disconnectShared";
        public string HttpMethod { get; private set; } = "POST";
        public string Channel_Id { get; set; } = "";
        public string Leaving_Team_Ids { get; set; } = "";
    }
    public partial class AdminConversationsDisconnectSharedResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminConversationsDisconnectSharedResponse> AdminConversationsDisconnectSharedAsync(string channel_Id)
        {
            var p = new AdminConversationsDisconnectSharedParameter();
            p.Channel_Id = channel_Id;
            return await this.SendAsync<AdminConversationsDisconnectSharedParameter, AdminConversationsDisconnectSharedResponse>(p, CancellationToken.None);
        }
        public async Task<AdminConversationsDisconnectSharedResponse> AdminConversationsDisconnectSharedAsync(string channel_Id, CancellationToken cancellationToken)
        {
            var p = new AdminConversationsDisconnectSharedParameter();
            p.Channel_Id = channel_Id;
            return await this.SendAsync<AdminConversationsDisconnectSharedParameter, AdminConversationsDisconnectSharedResponse>(p, cancellationToken);
        }
        public async Task<AdminConversationsDisconnectSharedResponse> AdminConversationsDisconnectSharedAsync(AdminConversationsDisconnectSharedParameter parameter)
        {
            return await this.SendAsync<AdminConversationsDisconnectSharedParameter, AdminConversationsDisconnectSharedResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminConversationsDisconnectSharedResponse> AdminConversationsDisconnectSharedAsync(AdminConversationsDisconnectSharedParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminConversationsDisconnectSharedParameter, AdminConversationsDisconnectSharedResponse>(parameter, cancellationToken);
        }
    }
}
