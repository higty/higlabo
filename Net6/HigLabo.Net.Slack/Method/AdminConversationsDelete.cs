
namespace HigLabo.Net.Slack
{
    public class AdminConversationsDeleteParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "admin.conversations.delete";
        public string HttpMethod { get; private set; } = "POST";
        public string Channel_Id { get; set; } = "";
    }
    public partial class AdminConversationsDeleteResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminConversationsDeleteResponse> AdminConversationsDeleteAsync(string channel_Id)
        {
            var p = new AdminConversationsDeleteParameter();
            p.Channel_Id = channel_Id;
            return await this.SendAsync<AdminConversationsDeleteParameter, AdminConversationsDeleteResponse>(p, CancellationToken.None);
        }
        public async Task<AdminConversationsDeleteResponse> AdminConversationsDeleteAsync(string channel_Id, CancellationToken cancellationToken)
        {
            var p = new AdminConversationsDeleteParameter();
            p.Channel_Id = channel_Id;
            return await this.SendAsync<AdminConversationsDeleteParameter, AdminConversationsDeleteResponse>(p, cancellationToken);
        }
        public async Task<AdminConversationsDeleteResponse> AdminConversationsDeleteAsync(AdminConversationsDeleteParameter parameter)
        {
            return await this.SendAsync<AdminConversationsDeleteParameter, AdminConversationsDeleteResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminConversationsDeleteResponse> AdminConversationsDeleteAsync(AdminConversationsDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminConversationsDeleteParameter, AdminConversationsDeleteResponse>(parameter, cancellationToken);
        }
    }
}
