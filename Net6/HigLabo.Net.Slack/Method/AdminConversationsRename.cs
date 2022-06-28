
namespace HigLabo.Net.Slack
{
    public class AdminConversationsRenameParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "admin.conversations.rename";
        public string HttpMethod { get; private set; } = "POST";
        public string Channel_Id { get; set; } = "";
        public string Name { get; set; } = "";
    }
    public partial class AdminConversationsRenameResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminConversationsRenameResponse> AdminConversationsRenameAsync(string channel_Id, string name)
        {
            var p = new AdminConversationsRenameParameter();
            p.Channel_Id = channel_Id;
            p.Name = name;
            return await this.SendAsync<AdminConversationsRenameParameter, AdminConversationsRenameResponse>(p, CancellationToken.None);
        }
        public async Task<AdminConversationsRenameResponse> AdminConversationsRenameAsync(string channel_Id, string name, CancellationToken cancellationToken)
        {
            var p = new AdminConversationsRenameParameter();
            p.Channel_Id = channel_Id;
            p.Name = name;
            return await this.SendAsync<AdminConversationsRenameParameter, AdminConversationsRenameResponse>(p, cancellationToken);
        }
        public async Task<AdminConversationsRenameResponse> AdminConversationsRenameAsync(AdminConversationsRenameParameter parameter)
        {
            return await this.SendAsync<AdminConversationsRenameParameter, AdminConversationsRenameResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminConversationsRenameResponse> AdminConversationsRenameAsync(AdminConversationsRenameParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminConversationsRenameParameter, AdminConversationsRenameResponse>(parameter, cancellationToken);
        }
    }
}
