
namespace HigLabo.Net.Slack
{
    public class AdminConversationsGetCustomRetentionParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "admin.conversations.getCustomRetention";
        public string HttpMethod { get; private set; } = "POST";
        public string Channel_Id { get; set; } = "";
    }
    public partial class AdminConversationsGetCustomRetentionResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminConversationsGetCustomRetentionResponse> AdminConversationsGetCustomRetentionAsync(string channel_Id)
        {
            var p = new AdminConversationsGetCustomRetentionParameter();
            p.Channel_Id = channel_Id;
            return await this.SendAsync<AdminConversationsGetCustomRetentionParameter, AdminConversationsGetCustomRetentionResponse>(p, CancellationToken.None);
        }
        public async Task<AdminConversationsGetCustomRetentionResponse> AdminConversationsGetCustomRetentionAsync(string channel_Id, CancellationToken cancellationToken)
        {
            var p = new AdminConversationsGetCustomRetentionParameter();
            p.Channel_Id = channel_Id;
            return await this.SendAsync<AdminConversationsGetCustomRetentionParameter, AdminConversationsGetCustomRetentionResponse>(p, cancellationToken);
        }
        public async Task<AdminConversationsGetCustomRetentionResponse> AdminConversationsGetCustomRetentionAsync(AdminConversationsGetCustomRetentionParameter parameter)
        {
            return await this.SendAsync<AdminConversationsGetCustomRetentionParameter, AdminConversationsGetCustomRetentionResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminConversationsGetCustomRetentionResponse> AdminConversationsGetCustomRetentionAsync(AdminConversationsGetCustomRetentionParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminConversationsGetCustomRetentionParameter, AdminConversationsGetCustomRetentionResponse>(parameter, cancellationToken);
        }
    }
}
