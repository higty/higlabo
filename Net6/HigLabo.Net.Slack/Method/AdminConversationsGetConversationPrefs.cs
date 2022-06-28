
namespace HigLabo.Net.Slack
{
    public class AdminConversationsGetConversationPrefsParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "admin.conversations.getConversationPrefs";
        public string HttpMethod { get; private set; } = "POST";
        public string Channel_Id { get; set; } = "";
    }
    public partial class AdminConversationsGetConversationPrefsResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminConversationsGetConversationPrefsResponse> AdminConversationsGetConversationPrefsAsync(string channel_Id)
        {
            var p = new AdminConversationsGetConversationPrefsParameter();
            p.Channel_Id = channel_Id;
            return await this.SendAsync<AdminConversationsGetConversationPrefsParameter, AdminConversationsGetConversationPrefsResponse>(p, CancellationToken.None);
        }
        public async Task<AdminConversationsGetConversationPrefsResponse> AdminConversationsGetConversationPrefsAsync(string channel_Id, CancellationToken cancellationToken)
        {
            var p = new AdminConversationsGetConversationPrefsParameter();
            p.Channel_Id = channel_Id;
            return await this.SendAsync<AdminConversationsGetConversationPrefsParameter, AdminConversationsGetConversationPrefsResponse>(p, cancellationToken);
        }
        public async Task<AdminConversationsGetConversationPrefsResponse> AdminConversationsGetConversationPrefsAsync(AdminConversationsGetConversationPrefsParameter parameter)
        {
            return await this.SendAsync<AdminConversationsGetConversationPrefsParameter, AdminConversationsGetConversationPrefsResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminConversationsGetConversationPrefsResponse> AdminConversationsGetConversationPrefsAsync(AdminConversationsGetConversationPrefsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminConversationsGetConversationPrefsParameter, AdminConversationsGetConversationPrefsResponse>(parameter, cancellationToken);
        }
    }
}
