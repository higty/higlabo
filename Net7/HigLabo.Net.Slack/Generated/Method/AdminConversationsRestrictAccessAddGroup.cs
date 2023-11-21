using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    /// <summary>
    /// https://api.slack.com/methods/admin.conversations.restrictAccess.addGroup
    /// </summary>
    public partial class AdminConversationsRestrictAccessAddGroupParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.conversations.restrictAccess.addGroup";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string? Channel_Id { get; set; }
        public string? Group_Id { get; set; }
        public string? Team_Id { get; set; }
    }
    public partial class AdminConversationsRestrictAccessAddGroupResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.conversations.restrictAccess.addGroup
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.restrictAccess.addGroup
        /// </summary>
        public async ValueTask<AdminConversationsRestrictAccessAddGroupResponse> AdminConversationsRestrictAccessAddGroupAsync(string? channel_Id, string? group_Id)
        {
            var p = new AdminConversationsRestrictAccessAddGroupParameter();
            p.Channel_Id = channel_Id;
            p.Group_Id = group_Id;
            return await this.SendAsync<AdminConversationsRestrictAccessAddGroupParameter, AdminConversationsRestrictAccessAddGroupResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.restrictAccess.addGroup
        /// </summary>
        public async ValueTask<AdminConversationsRestrictAccessAddGroupResponse> AdminConversationsRestrictAccessAddGroupAsync(string? channel_Id, string? group_Id, CancellationToken cancellationToken)
        {
            var p = new AdminConversationsRestrictAccessAddGroupParameter();
            p.Channel_Id = channel_Id;
            p.Group_Id = group_Id;
            return await this.SendAsync<AdminConversationsRestrictAccessAddGroupParameter, AdminConversationsRestrictAccessAddGroupResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.restrictAccess.addGroup
        /// </summary>
        public async ValueTask<AdminConversationsRestrictAccessAddGroupResponse> AdminConversationsRestrictAccessAddGroupAsync(AdminConversationsRestrictAccessAddGroupParameter parameter)
        {
            return await this.SendAsync<AdminConversationsRestrictAccessAddGroupParameter, AdminConversationsRestrictAccessAddGroupResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.restrictAccess.addGroup
        /// </summary>
        public async ValueTask<AdminConversationsRestrictAccessAddGroupResponse> AdminConversationsRestrictAccessAddGroupAsync(AdminConversationsRestrictAccessAddGroupParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminConversationsRestrictAccessAddGroupParameter, AdminConversationsRestrictAccessAddGroupResponse>(parameter, cancellationToken);
        }
    }
}
