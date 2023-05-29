using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class AdminConversationsSetTeamsParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.conversations.setTeams";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Channel_Id { get; set; }
        public bool? Org_Channel { get; set; }
        public string? Target_Team_Ids { get; set; }
        public string? Team_Id { get; set; }
    }
    public partial class AdminConversationsSetTeamsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.conversations.setTeams
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.setTeams
        /// </summary>
        public async Task<AdminConversationsSetTeamsResponse> AdminConversationsSetTeamsAsync(string? channel_Id)
        {
            var p = new AdminConversationsSetTeamsParameter();
            p.Channel_Id = channel_Id;
            return await this.SendAsync<AdminConversationsSetTeamsParameter, AdminConversationsSetTeamsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.setTeams
        /// </summary>
        public async Task<AdminConversationsSetTeamsResponse> AdminConversationsSetTeamsAsync(string? channel_Id, CancellationToken cancellationToken)
        {
            var p = new AdminConversationsSetTeamsParameter();
            p.Channel_Id = channel_Id;
            return await this.SendAsync<AdminConversationsSetTeamsParameter, AdminConversationsSetTeamsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.setTeams
        /// </summary>
        public async Task<AdminConversationsSetTeamsResponse> AdminConversationsSetTeamsAsync(AdminConversationsSetTeamsParameter parameter)
        {
            return await this.SendAsync<AdminConversationsSetTeamsParameter, AdminConversationsSetTeamsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.setTeams
        /// </summary>
        public async Task<AdminConversationsSetTeamsResponse> AdminConversationsSetTeamsAsync(AdminConversationsSetTeamsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminConversationsSetTeamsParameter, AdminConversationsSetTeamsResponse>(parameter, cancellationToken);
        }
    }
}
