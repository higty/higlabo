using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class AdminConversationsInviteParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.conversations.invite";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Channel_Id { get; set; }
        public string? User_Ids { get; set; }
    }
    public partial class AdminConversationsInviteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.conversations.invite
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.invite
        /// </summary>
        public async ValueTask<AdminConversationsInviteResponse> AdminConversationsInviteAsync(string? channel_Id, string? user_Ids)
        {
            var p = new AdminConversationsInviteParameter();
            p.Channel_Id = channel_Id;
            p.User_Ids = user_Ids;
            return await this.SendAsync<AdminConversationsInviteParameter, AdminConversationsInviteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.invite
        /// </summary>
        public async ValueTask<AdminConversationsInviteResponse> AdminConversationsInviteAsync(string? channel_Id, string? user_Ids, CancellationToken cancellationToken)
        {
            var p = new AdminConversationsInviteParameter();
            p.Channel_Id = channel_Id;
            p.User_Ids = user_Ids;
            return await this.SendAsync<AdminConversationsInviteParameter, AdminConversationsInviteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.invite
        /// </summary>
        public async ValueTask<AdminConversationsInviteResponse> AdminConversationsInviteAsync(AdminConversationsInviteParameter parameter)
        {
            return await this.SendAsync<AdminConversationsInviteParameter, AdminConversationsInviteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.invite
        /// </summary>
        public async ValueTask<AdminConversationsInviteResponse> AdminConversationsInviteAsync(AdminConversationsInviteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminConversationsInviteParameter, AdminConversationsInviteResponse>(parameter, cancellationToken);
        }
    }
}
