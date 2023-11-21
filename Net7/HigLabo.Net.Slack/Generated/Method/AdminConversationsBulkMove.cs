using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    /// <summary>
    /// https://api.slack.com/methods/admin.conversations.bulkMove
    /// </summary>
    public partial class AdminConversationsBulkMoveParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.conversations.bulkMove";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string? Channel_Ids { get; set; }
        public string? Target_Team_Id { get; set; }
    }
    public partial class AdminConversationsBulkMoveResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.conversations.bulkMove
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.bulkMove
        /// </summary>
        public async ValueTask<AdminConversationsBulkMoveResponse> AdminConversationsBulkMoveAsync(string? channel_Ids, string? target_Team_Id)
        {
            var p = new AdminConversationsBulkMoveParameter();
            p.Channel_Ids = channel_Ids;
            p.Target_Team_Id = target_Team_Id;
            return await this.SendAsync<AdminConversationsBulkMoveParameter, AdminConversationsBulkMoveResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.bulkMove
        /// </summary>
        public async ValueTask<AdminConversationsBulkMoveResponse> AdminConversationsBulkMoveAsync(string? channel_Ids, string? target_Team_Id, CancellationToken cancellationToken)
        {
            var p = new AdminConversationsBulkMoveParameter();
            p.Channel_Ids = channel_Ids;
            p.Target_Team_Id = target_Team_Id;
            return await this.SendAsync<AdminConversationsBulkMoveParameter, AdminConversationsBulkMoveResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.bulkMove
        /// </summary>
        public async ValueTask<AdminConversationsBulkMoveResponse> AdminConversationsBulkMoveAsync(AdminConversationsBulkMoveParameter parameter)
        {
            return await this.SendAsync<AdminConversationsBulkMoveParameter, AdminConversationsBulkMoveResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.bulkMove
        /// </summary>
        public async ValueTask<AdminConversationsBulkMoveResponse> AdminConversationsBulkMoveAsync(AdminConversationsBulkMoveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminConversationsBulkMoveParameter, AdminConversationsBulkMoveResponse>(parameter, cancellationToken);
        }
    }
}
