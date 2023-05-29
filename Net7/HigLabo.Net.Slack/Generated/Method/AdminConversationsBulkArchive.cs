using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class AdminConversationsBulkArchiveParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.conversations.bulkArchive";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string? Channel_Ids { get; set; }
    }
    public partial class AdminConversationsBulkArchiveResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.conversations.bulkArchive
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.bulkArchive
        /// </summary>
        public async Task<AdminConversationsBulkArchiveResponse> AdminConversationsBulkArchiveAsync(string? channel_Ids)
        {
            var p = new AdminConversationsBulkArchiveParameter();
            p.Channel_Ids = channel_Ids;
            return await this.SendAsync<AdminConversationsBulkArchiveParameter, AdminConversationsBulkArchiveResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.bulkArchive
        /// </summary>
        public async Task<AdminConversationsBulkArchiveResponse> AdminConversationsBulkArchiveAsync(string? channel_Ids, CancellationToken cancellationToken)
        {
            var p = new AdminConversationsBulkArchiveParameter();
            p.Channel_Ids = channel_Ids;
            return await this.SendAsync<AdminConversationsBulkArchiveParameter, AdminConversationsBulkArchiveResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.bulkArchive
        /// </summary>
        public async Task<AdminConversationsBulkArchiveResponse> AdminConversationsBulkArchiveAsync(AdminConversationsBulkArchiveParameter parameter)
        {
            return await this.SendAsync<AdminConversationsBulkArchiveParameter, AdminConversationsBulkArchiveResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.bulkArchive
        /// </summary>
        public async Task<AdminConversationsBulkArchiveResponse> AdminConversationsBulkArchiveAsync(AdminConversationsBulkArchiveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminConversationsBulkArchiveParameter, AdminConversationsBulkArchiveResponse>(parameter, cancellationToken);
        }
    }
}
