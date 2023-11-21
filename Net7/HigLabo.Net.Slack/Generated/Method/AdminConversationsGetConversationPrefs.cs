using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    /// <summary>
    /// https://api.slack.com/methods/admin.conversations.getConversationPrefs
    /// </summary>
    public partial class AdminConversationsGetConversationPrefsParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.conversations.getConversationPrefs";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Channel_Id { get; set; }
    }
    public partial class AdminConversationsGetConversationPrefsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.conversations.getConversationPrefs
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.getConversationPrefs
        /// </summary>
        public async ValueTask<AdminConversationsGetConversationPrefsResponse> AdminConversationsGetConversationPrefsAsync(string? channel_Id)
        {
            var p = new AdminConversationsGetConversationPrefsParameter();
            p.Channel_Id = channel_Id;
            return await this.SendAsync<AdminConversationsGetConversationPrefsParameter, AdminConversationsGetConversationPrefsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.getConversationPrefs
        /// </summary>
        public async ValueTask<AdminConversationsGetConversationPrefsResponse> AdminConversationsGetConversationPrefsAsync(string? channel_Id, CancellationToken cancellationToken)
        {
            var p = new AdminConversationsGetConversationPrefsParameter();
            p.Channel_Id = channel_Id;
            return await this.SendAsync<AdminConversationsGetConversationPrefsParameter, AdminConversationsGetConversationPrefsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.getConversationPrefs
        /// </summary>
        public async ValueTask<AdminConversationsGetConversationPrefsResponse> AdminConversationsGetConversationPrefsAsync(AdminConversationsGetConversationPrefsParameter parameter)
        {
            return await this.SendAsync<AdminConversationsGetConversationPrefsParameter, AdminConversationsGetConversationPrefsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.getConversationPrefs
        /// </summary>
        public async ValueTask<AdminConversationsGetConversationPrefsResponse> AdminConversationsGetConversationPrefsAsync(AdminConversationsGetConversationPrefsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminConversationsGetConversationPrefsParameter, AdminConversationsGetConversationPrefsResponse>(parameter, cancellationToken);
        }
    }
}
