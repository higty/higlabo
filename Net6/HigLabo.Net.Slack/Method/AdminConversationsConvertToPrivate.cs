
namespace HigLabo.Net.Slack
{
    public partial class AdminConversationsConvertToPrivateParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.conversations.convertToPrivate";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Channel_Id { get; set; }
        public string Name { get; set; }
    }
    public partial class AdminConversationsConvertToPrivateResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminConversationsConvertToPrivateResponse> AdminConversationsConvertToPrivateAsync(string channel_Id)
        {
            var p = new AdminConversationsConvertToPrivateParameter();
            p.Channel_Id = channel_Id;
            return await this.SendAsync<AdminConversationsConvertToPrivateParameter, AdminConversationsConvertToPrivateResponse>(p, CancellationToken.None);
        }
        public async Task<AdminConversationsConvertToPrivateResponse> AdminConversationsConvertToPrivateAsync(string channel_Id, CancellationToken cancellationToken)
        {
            var p = new AdminConversationsConvertToPrivateParameter();
            p.Channel_Id = channel_Id;
            return await this.SendAsync<AdminConversationsConvertToPrivateParameter, AdminConversationsConvertToPrivateResponse>(p, cancellationToken);
        }
        public async Task<AdminConversationsConvertToPrivateResponse> AdminConversationsConvertToPrivateAsync(AdminConversationsConvertToPrivateParameter parameter)
        {
            return await this.SendAsync<AdminConversationsConvertToPrivateParameter, AdminConversationsConvertToPrivateResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminConversationsConvertToPrivateResponse> AdminConversationsConvertToPrivateAsync(AdminConversationsConvertToPrivateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminConversationsConvertToPrivateParameter, AdminConversationsConvertToPrivateResponse>(parameter, cancellationToken);
        }
    }
}
