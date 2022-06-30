
namespace HigLabo.Net.Slack
{
    public partial class AdminConversationsDeleteParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.conversations.delete";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Channel_Id { get; set; }
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
