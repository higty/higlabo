
namespace HigLabo.Net.Slack
{
    public class AdminConversationsRestrictAccessAddGroupParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "admin.conversations.restrictAccess.addGroup";
        public string HttpMethod { get; private set; } = "GET";
        public string Channel_Id { get; set; } = "";
        public string Group_Id { get; set; } = "";
        public string Team_Id { get; set; } = "";
    }
    public partial class AdminConversationsRestrictAccessAddGroupResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminConversationsRestrictAccessAddGroupResponse> AdminConversationsRestrictAccessAddGroupAsync(string channel_Id, string group_Id)
        {
            var p = new AdminConversationsRestrictAccessAddGroupParameter();
            p.Channel_Id = channel_Id;
            p.Group_Id = group_Id;
            return await this.SendAsync<AdminConversationsRestrictAccessAddGroupParameter, AdminConversationsRestrictAccessAddGroupResponse>(p, CancellationToken.None);
        }
        public async Task<AdminConversationsRestrictAccessAddGroupResponse> AdminConversationsRestrictAccessAddGroupAsync(string channel_Id, string group_Id, CancellationToken cancellationToken)
        {
            var p = new AdminConversationsRestrictAccessAddGroupParameter();
            p.Channel_Id = channel_Id;
            p.Group_Id = group_Id;
            return await this.SendAsync<AdminConversationsRestrictAccessAddGroupParameter, AdminConversationsRestrictAccessAddGroupResponse>(p, cancellationToken);
        }
        public async Task<AdminConversationsRestrictAccessAddGroupResponse> AdminConversationsRestrictAccessAddGroupAsync(AdminConversationsRestrictAccessAddGroupParameter parameter)
        {
            return await this.SendAsync<AdminConversationsRestrictAccessAddGroupParameter, AdminConversationsRestrictAccessAddGroupResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminConversationsRestrictAccessAddGroupResponse> AdminConversationsRestrictAccessAddGroupAsync(AdminConversationsRestrictAccessAddGroupParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminConversationsRestrictAccessAddGroupParameter, AdminConversationsRestrictAccessAddGroupResponse>(parameter, cancellationToken);
        }
    }
}
