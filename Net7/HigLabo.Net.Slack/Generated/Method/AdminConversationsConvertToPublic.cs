using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class AdminConversationsConvertToPublicParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.conversations.convertToPublic";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Channel_Id { get; set; }
    }
    public partial class AdminConversationsConvertToPublicResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.conversations.convertToPublic
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.convertToPublic
        /// </summary>
        public async Task<AdminConversationsConvertToPublicResponse> AdminConversationsConvertToPublicAsync(string? channel_Id)
        {
            var p = new AdminConversationsConvertToPublicParameter();
            p.Channel_Id = channel_Id;
            return await this.SendAsync<AdminConversationsConvertToPublicParameter, AdminConversationsConvertToPublicResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.convertToPublic
        /// </summary>
        public async Task<AdminConversationsConvertToPublicResponse> AdminConversationsConvertToPublicAsync(string? channel_Id, CancellationToken cancellationToken)
        {
            var p = new AdminConversationsConvertToPublicParameter();
            p.Channel_Id = channel_Id;
            return await this.SendAsync<AdminConversationsConvertToPublicParameter, AdminConversationsConvertToPublicResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.convertToPublic
        /// </summary>
        public async Task<AdminConversationsConvertToPublicResponse> AdminConversationsConvertToPublicAsync(AdminConversationsConvertToPublicParameter parameter)
        {
            return await this.SendAsync<AdminConversationsConvertToPublicParameter, AdminConversationsConvertToPublicResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.convertToPublic
        /// </summary>
        public async Task<AdminConversationsConvertToPublicResponse> AdminConversationsConvertToPublicAsync(AdminConversationsConvertToPublicParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminConversationsConvertToPublicParameter, AdminConversationsConvertToPublicResponse>(parameter, cancellationToken);
        }
    }
}
