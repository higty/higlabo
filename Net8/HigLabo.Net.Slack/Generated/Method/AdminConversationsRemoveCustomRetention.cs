using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class AdminConversationsRemoveCustomRetentionParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.conversations.removeCustomRetention";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Channel_Id { get; set; }
    }
    public partial class AdminConversationsRemoveCustomRetentionResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.conversations.removeCustomRetention
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.removeCustomRetention
        /// </summary>
        public async ValueTask<AdminConversationsRemoveCustomRetentionResponse> AdminConversationsRemoveCustomRetentionAsync(string? channel_Id)
        {
            var p = new AdminConversationsRemoveCustomRetentionParameter();
            p.Channel_Id = channel_Id;
            return await this.SendAsync<AdminConversationsRemoveCustomRetentionParameter, AdminConversationsRemoveCustomRetentionResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.removeCustomRetention
        /// </summary>
        public async ValueTask<AdminConversationsRemoveCustomRetentionResponse> AdminConversationsRemoveCustomRetentionAsync(string? channel_Id, CancellationToken cancellationToken)
        {
            var p = new AdminConversationsRemoveCustomRetentionParameter();
            p.Channel_Id = channel_Id;
            return await this.SendAsync<AdminConversationsRemoveCustomRetentionParameter, AdminConversationsRemoveCustomRetentionResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.removeCustomRetention
        /// </summary>
        public async ValueTask<AdminConversationsRemoveCustomRetentionResponse> AdminConversationsRemoveCustomRetentionAsync(AdminConversationsRemoveCustomRetentionParameter parameter)
        {
            return await this.SendAsync<AdminConversationsRemoveCustomRetentionParameter, AdminConversationsRemoveCustomRetentionResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.removeCustomRetention
        /// </summary>
        public async ValueTask<AdminConversationsRemoveCustomRetentionResponse> AdminConversationsRemoveCustomRetentionAsync(AdminConversationsRemoveCustomRetentionParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminConversationsRemoveCustomRetentionParameter, AdminConversationsRemoveCustomRetentionResponse>(parameter, cancellationToken);
        }
    }
}
