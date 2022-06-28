
namespace HigLabo.Net.Slack
{
    public class AdminConversationsRestrictAccessRemoveGroupParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "admin.conversations.restrictAccess.removeGroup";
        public string HttpMethod { get; private set; } = "GET";
        public string Channel_Id { get; set; } = "";
        public string Group_Id { get; set; } = "";
        public string Team_Id { get; set; } = "";
    }
    public partial class AdminConversationsRestrictAccessRemoveGroupResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminConversationsRestrictAccessRemoveGroupResponse> AdminConversationsRestrictAccessRemoveGroupAsync(string channel_Id, string group_Id, string team_Id)
        {
            var p = new AdminConversationsRestrictAccessRemoveGroupParameter();
            p.Channel_Id = channel_Id;
            p.Group_Id = group_Id;
            p.Team_Id = team_Id;
            return await this.SendAsync<AdminConversationsRestrictAccessRemoveGroupParameter, AdminConversationsRestrictAccessRemoveGroupResponse>(p, CancellationToken.None);
        }
        public async Task<AdminConversationsRestrictAccessRemoveGroupResponse> AdminConversationsRestrictAccessRemoveGroupAsync(string channel_Id, string group_Id, string team_Id, CancellationToken cancellationToken)
        {
            var p = new AdminConversationsRestrictAccessRemoveGroupParameter();
            p.Channel_Id = channel_Id;
            p.Group_Id = group_Id;
            p.Team_Id = team_Id;
            return await this.SendAsync<AdminConversationsRestrictAccessRemoveGroupParameter, AdminConversationsRestrictAccessRemoveGroupResponse>(p, cancellationToken);
        }
        public async Task<AdminConversationsRestrictAccessRemoveGroupResponse> AdminConversationsRestrictAccessRemoveGroupAsync(AdminConversationsRestrictAccessRemoveGroupParameter parameter)
        {
            return await this.SendAsync<AdminConversationsRestrictAccessRemoveGroupParameter, AdminConversationsRestrictAccessRemoveGroupResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminConversationsRestrictAccessRemoveGroupResponse> AdminConversationsRestrictAccessRemoveGroupAsync(AdminConversationsRestrictAccessRemoveGroupParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminConversationsRestrictAccessRemoveGroupParameter, AdminConversationsRestrictAccessRemoveGroupResponse>(parameter, cancellationToken);
        }
    }
}
