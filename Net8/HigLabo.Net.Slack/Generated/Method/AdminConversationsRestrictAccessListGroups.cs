using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class AdminConversationsRestrictAccessListGroupsParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.conversations.restrictAccess.listGroups";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string? Channel_Id { get; set; }
        public string? Team_Id { get; set; }
    }
    public partial class AdminConversationsRestrictAccessListGroupsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.conversations.restrictAccess.listGroups
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.restrictAccess.listGroups
        /// </summary>
        public async ValueTask<AdminConversationsRestrictAccessListGroupsResponse> AdminConversationsRestrictAccessListGroupsAsync(string? channel_Id)
        {
            var p = new AdminConversationsRestrictAccessListGroupsParameter();
            p.Channel_Id = channel_Id;
            return await this.SendAsync<AdminConversationsRestrictAccessListGroupsParameter, AdminConversationsRestrictAccessListGroupsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.restrictAccess.listGroups
        /// </summary>
        public async ValueTask<AdminConversationsRestrictAccessListGroupsResponse> AdminConversationsRestrictAccessListGroupsAsync(string? channel_Id, CancellationToken cancellationToken)
        {
            var p = new AdminConversationsRestrictAccessListGroupsParameter();
            p.Channel_Id = channel_Id;
            return await this.SendAsync<AdminConversationsRestrictAccessListGroupsParameter, AdminConversationsRestrictAccessListGroupsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.restrictAccess.listGroups
        /// </summary>
        public async ValueTask<AdminConversationsRestrictAccessListGroupsResponse> AdminConversationsRestrictAccessListGroupsAsync(AdminConversationsRestrictAccessListGroupsParameter parameter)
        {
            return await this.SendAsync<AdminConversationsRestrictAccessListGroupsParameter, AdminConversationsRestrictAccessListGroupsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.restrictAccess.listGroups
        /// </summary>
        public async ValueTask<AdminConversationsRestrictAccessListGroupsResponse> AdminConversationsRestrictAccessListGroupsAsync(AdminConversationsRestrictAccessListGroupsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminConversationsRestrictAccessListGroupsParameter, AdminConversationsRestrictAccessListGroupsResponse>(parameter, cancellationToken);
        }
    }
}
