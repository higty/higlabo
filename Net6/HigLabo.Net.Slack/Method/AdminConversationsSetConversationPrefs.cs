
namespace HigLabo.Net.Slack
{
    public partial class AdminConversationsSetConversationPrefsParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.conversations.setConversationPrefs";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Channel_Id { get; set; }
        public string Prefs { get; set; }
    }
    public partial class AdminConversationsSetConversationPrefsResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminConversationsSetConversationPrefsResponse> AdminConversationsSetConversationPrefsAsync(string channel_Id, string prefs)
        {
            var p = new AdminConversationsSetConversationPrefsParameter();
            p.Channel_Id = channel_Id;
            p.Prefs = prefs;
            return await this.SendAsync<AdminConversationsSetConversationPrefsParameter, AdminConversationsSetConversationPrefsResponse>(p, CancellationToken.None);
        }
        public async Task<AdminConversationsSetConversationPrefsResponse> AdminConversationsSetConversationPrefsAsync(string channel_Id, string prefs, CancellationToken cancellationToken)
        {
            var p = new AdminConversationsSetConversationPrefsParameter();
            p.Channel_Id = channel_Id;
            p.Prefs = prefs;
            return await this.SendAsync<AdminConversationsSetConversationPrefsParameter, AdminConversationsSetConversationPrefsResponse>(p, cancellationToken);
        }
        public async Task<AdminConversationsSetConversationPrefsResponse> AdminConversationsSetConversationPrefsAsync(AdminConversationsSetConversationPrefsParameter parameter)
        {
            return await this.SendAsync<AdminConversationsSetConversationPrefsParameter, AdminConversationsSetConversationPrefsResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminConversationsSetConversationPrefsResponse> AdminConversationsSetConversationPrefsAsync(AdminConversationsSetConversationPrefsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminConversationsSetConversationPrefsParameter, AdminConversationsSetConversationPrefsResponse>(parameter, cancellationToken);
        }
    }
}
