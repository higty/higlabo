using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class AdminConversationsDeleteParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.conversations.delete";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Channel_Id { get; set; }
    }
    public partial class AdminConversationsDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.conversations.delete
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.delete
        /// </summary>
        public async ValueTask<AdminConversationsDeleteResponse> AdminConversationsDeleteAsync(string? channel_Id)
        {
            var p = new AdminConversationsDeleteParameter();
            p.Channel_Id = channel_Id;
            return await this.SendAsync<AdminConversationsDeleteParameter, AdminConversationsDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.delete
        /// </summary>
        public async ValueTask<AdminConversationsDeleteResponse> AdminConversationsDeleteAsync(string? channel_Id, CancellationToken cancellationToken)
        {
            var p = new AdminConversationsDeleteParameter();
            p.Channel_Id = channel_Id;
            return await this.SendAsync<AdminConversationsDeleteParameter, AdminConversationsDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.delete
        /// </summary>
        public async ValueTask<AdminConversationsDeleteResponse> AdminConversationsDeleteAsync(AdminConversationsDeleteParameter parameter)
        {
            return await this.SendAsync<AdminConversationsDeleteParameter, AdminConversationsDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.delete
        /// </summary>
        public async ValueTask<AdminConversationsDeleteResponse> AdminConversationsDeleteAsync(AdminConversationsDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminConversationsDeleteParameter, AdminConversationsDeleteResponse>(parameter, cancellationToken);
        }
    }
}
