
namespace HigLabo.Net.Slack
{
    public class AdminConversationsRemoveCustomRetentionParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "admin.conversations.removeCustomRetention";
        public string HttpMethod { get; private set; } = "POST";
        public string Channel_Id { get; set; } = "";
    }
    public partial class AdminConversationsRemoveCustomRetentionResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminConversationsRemoveCustomRetentionResponse> AdminConversationsRemoveCustomRetentionAsync(string channel_Id)
        {
            var p = new AdminConversationsRemoveCustomRetentionParameter();
            p.Channel_Id = channel_Id;
            return await this.SendAsync<AdminConversationsRemoveCustomRetentionParameter, AdminConversationsRemoveCustomRetentionResponse>(p, CancellationToken.None);
        }
        public async Task<AdminConversationsRemoveCustomRetentionResponse> AdminConversationsRemoveCustomRetentionAsync(string channel_Id, CancellationToken cancellationToken)
        {
            var p = new AdminConversationsRemoveCustomRetentionParameter();
            p.Channel_Id = channel_Id;
            return await this.SendAsync<AdminConversationsRemoveCustomRetentionParameter, AdminConversationsRemoveCustomRetentionResponse>(p, cancellationToken);
        }
        public async Task<AdminConversationsRemoveCustomRetentionResponse> AdminConversationsRemoveCustomRetentionAsync(AdminConversationsRemoveCustomRetentionParameter parameter)
        {
            return await this.SendAsync<AdminConversationsRemoveCustomRetentionParameter, AdminConversationsRemoveCustomRetentionResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminConversationsRemoveCustomRetentionResponse> AdminConversationsRemoveCustomRetentionAsync(AdminConversationsRemoveCustomRetentionParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminConversationsRemoveCustomRetentionParameter, AdminConversationsRemoveCustomRetentionResponse>(parameter, cancellationToken);
        }
    }
}
