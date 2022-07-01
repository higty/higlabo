using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class AdminConversationsDisconnectSharedParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.conversations.disconnectShared";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Channel_Id { get; set; }
        public string Leaving_Team_Ids { get; set; }
    }
    public partial class AdminConversationsDisconnectSharedResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.disconnectShared
        /// </summary>
        public async Task<AdminConversationsDisconnectSharedResponse> AdminConversationsDisconnectSharedAsync(string channel_Id)
        {
            var p = new AdminConversationsDisconnectSharedParameter();
            p.Channel_Id = channel_Id;
            return await this.SendAsync<AdminConversationsDisconnectSharedParameter, AdminConversationsDisconnectSharedResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.disconnectShared
        /// </summary>
        public async Task<AdminConversationsDisconnectSharedResponse> AdminConversationsDisconnectSharedAsync(string channel_Id, CancellationToken cancellationToken)
        {
            var p = new AdminConversationsDisconnectSharedParameter();
            p.Channel_Id = channel_Id;
            return await this.SendAsync<AdminConversationsDisconnectSharedParameter, AdminConversationsDisconnectSharedResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.disconnectShared
        /// </summary>
        public async Task<AdminConversationsDisconnectSharedResponse> AdminConversationsDisconnectSharedAsync(AdminConversationsDisconnectSharedParameter parameter)
        {
            return await this.SendAsync<AdminConversationsDisconnectSharedParameter, AdminConversationsDisconnectSharedResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.disconnectShared
        /// </summary>
        public async Task<AdminConversationsDisconnectSharedResponse> AdminConversationsDisconnectSharedAsync(AdminConversationsDisconnectSharedParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminConversationsDisconnectSharedParameter, AdminConversationsDisconnectSharedResponse>(parameter, cancellationToken);
        }
    }
}
