using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    /// <summary>
    /// https://api.slack.com/methods/admin.conversations.getCustomRetention
    /// </summary>
    public partial class AdminConversationsGetCustomRetentionParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.conversations.getCustomRetention";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Channel_Id { get; set; }
    }
    public partial class AdminConversationsGetCustomRetentionResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.conversations.getCustomRetention
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.getCustomRetention
        /// </summary>
        public async ValueTask<AdminConversationsGetCustomRetentionResponse> AdminConversationsGetCustomRetentionAsync(string? channel_Id)
        {
            var p = new AdminConversationsGetCustomRetentionParameter();
            p.Channel_Id = channel_Id;
            return await this.SendAsync<AdminConversationsGetCustomRetentionParameter, AdminConversationsGetCustomRetentionResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.getCustomRetention
        /// </summary>
        public async ValueTask<AdminConversationsGetCustomRetentionResponse> AdminConversationsGetCustomRetentionAsync(string? channel_Id, CancellationToken cancellationToken)
        {
            var p = new AdminConversationsGetCustomRetentionParameter();
            p.Channel_Id = channel_Id;
            return await this.SendAsync<AdminConversationsGetCustomRetentionParameter, AdminConversationsGetCustomRetentionResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.getCustomRetention
        /// </summary>
        public async ValueTask<AdminConversationsGetCustomRetentionResponse> AdminConversationsGetCustomRetentionAsync(AdminConversationsGetCustomRetentionParameter parameter)
        {
            return await this.SendAsync<AdminConversationsGetCustomRetentionParameter, AdminConversationsGetCustomRetentionResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.getCustomRetention
        /// </summary>
        public async ValueTask<AdminConversationsGetCustomRetentionResponse> AdminConversationsGetCustomRetentionAsync(AdminConversationsGetCustomRetentionParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminConversationsGetCustomRetentionParameter, AdminConversationsGetCustomRetentionResponse>(parameter, cancellationToken);
        }
    }
}
