
namespace HigLabo.Net.Slack
{
    public class AdminConversationsSetCustomRetentionParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "admin.conversations.setCustomRetention";
        public string HttpMethod { get; private set; } = "POST";
        public string Channel_Id { get; set; } = "";
        public int Duration_Days { get; set; }
    }
    public partial class AdminConversationsSetCustomRetentionResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminConversationsSetCustomRetentionResponse> AdminConversationsSetCustomRetentionAsync(string channel_Id, int duration_Days)
        {
            var p = new AdminConversationsSetCustomRetentionParameter();
            p.Channel_Id = channel_Id;
            p.Duration_Days = duration_Days;
            return await this.SendAsync<AdminConversationsSetCustomRetentionParameter, AdminConversationsSetCustomRetentionResponse>(p, CancellationToken.None);
        }
        public async Task<AdminConversationsSetCustomRetentionResponse> AdminConversationsSetCustomRetentionAsync(string channel_Id, int duration_Days, CancellationToken cancellationToken)
        {
            var p = new AdminConversationsSetCustomRetentionParameter();
            p.Channel_Id = channel_Id;
            p.Duration_Days = duration_Days;
            return await this.SendAsync<AdminConversationsSetCustomRetentionParameter, AdminConversationsSetCustomRetentionResponse>(p, cancellationToken);
        }
        public async Task<AdminConversationsSetCustomRetentionResponse> AdminConversationsSetCustomRetentionAsync(AdminConversationsSetCustomRetentionParameter parameter)
        {
            return await this.SendAsync<AdminConversationsSetCustomRetentionParameter, AdminConversationsSetCustomRetentionResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminConversationsSetCustomRetentionResponse> AdminConversationsSetCustomRetentionAsync(AdminConversationsSetCustomRetentionParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminConversationsSetCustomRetentionParameter, AdminConversationsSetCustomRetentionResponse>(parameter, cancellationToken);
        }
    }
}
