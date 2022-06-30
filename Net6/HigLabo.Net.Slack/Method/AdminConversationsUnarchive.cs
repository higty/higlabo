
namespace HigLabo.Net.Slack
{
    public partial class AdminConversationsUnarchiveParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.conversations.unarchive";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Channel_Id { get; set; }
    }
    public partial class AdminConversationsUnarchiveResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.unarchive
        /// </summary>
        public async Task<AdminConversationsUnarchiveResponse> AdminConversationsUnarchiveAsync(string channel_Id)
        {
            var p = new AdminConversationsUnarchiveParameter();
            p.Channel_Id = channel_Id;
            return await this.SendAsync<AdminConversationsUnarchiveParameter, AdminConversationsUnarchiveResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.unarchive
        /// </summary>
        public async Task<AdminConversationsUnarchiveResponse> AdminConversationsUnarchiveAsync(string channel_Id, CancellationToken cancellationToken)
        {
            var p = new AdminConversationsUnarchiveParameter();
            p.Channel_Id = channel_Id;
            return await this.SendAsync<AdminConversationsUnarchiveParameter, AdminConversationsUnarchiveResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.unarchive
        /// </summary>
        public async Task<AdminConversationsUnarchiveResponse> AdminConversationsUnarchiveAsync(AdminConversationsUnarchiveParameter parameter)
        {
            return await this.SendAsync<AdminConversationsUnarchiveParameter, AdminConversationsUnarchiveResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.unarchive
        /// </summary>
        public async Task<AdminConversationsUnarchiveResponse> AdminConversationsUnarchiveAsync(AdminConversationsUnarchiveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminConversationsUnarchiveParameter, AdminConversationsUnarchiveResponse>(parameter, cancellationToken);
        }
    }
}
