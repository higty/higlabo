using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class AdminConversationsSetCustomRetentionParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.conversations.setCustomRetention";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Channel_Id { get; set; }
        public int? Duration_Days { get; set; }
    }
    public partial class AdminConversationsSetCustomRetentionResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.conversations.setCustomRetention
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.setCustomRetention
        /// </summary>
        public async Task<AdminConversationsSetCustomRetentionResponse> AdminConversationsSetCustomRetentionAsync(string? channel_Id, int? duration_Days)
        {
            var p = new AdminConversationsSetCustomRetentionParameter();
            p.Channel_Id = channel_Id;
            p.Duration_Days = duration_Days;
            return await this.SendAsync<AdminConversationsSetCustomRetentionParameter, AdminConversationsSetCustomRetentionResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.setCustomRetention
        /// </summary>
        public async Task<AdminConversationsSetCustomRetentionResponse> AdminConversationsSetCustomRetentionAsync(string? channel_Id, int? duration_Days, CancellationToken cancellationToken)
        {
            var p = new AdminConversationsSetCustomRetentionParameter();
            p.Channel_Id = channel_Id;
            p.Duration_Days = duration_Days;
            return await this.SendAsync<AdminConversationsSetCustomRetentionParameter, AdminConversationsSetCustomRetentionResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.setCustomRetention
        /// </summary>
        public async Task<AdminConversationsSetCustomRetentionResponse> AdminConversationsSetCustomRetentionAsync(AdminConversationsSetCustomRetentionParameter parameter)
        {
            return await this.SendAsync<AdminConversationsSetCustomRetentionParameter, AdminConversationsSetCustomRetentionResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.setCustomRetention
        /// </summary>
        public async Task<AdminConversationsSetCustomRetentionResponse> AdminConversationsSetCustomRetentionAsync(AdminConversationsSetCustomRetentionParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminConversationsSetCustomRetentionParameter, AdminConversationsSetCustomRetentionResponse>(parameter, cancellationToken);
        }
    }
}
