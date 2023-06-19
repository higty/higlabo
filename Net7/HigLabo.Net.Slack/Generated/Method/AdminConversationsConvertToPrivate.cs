using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class AdminConversationsConvertToPrivateParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.conversations.convertToPrivate";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Channel_Id { get; set; }
        public string? Name { get; set; }
    }
    public partial class AdminConversationsConvertToPrivateResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.conversations.convertToPrivate
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.convertToPrivate
        /// </summary>
        public async ValueTask<AdminConversationsConvertToPrivateResponse> AdminConversationsConvertToPrivateAsync(string? channel_Id)
        {
            var p = new AdminConversationsConvertToPrivateParameter();
            p.Channel_Id = channel_Id;
            return await this.SendAsync<AdminConversationsConvertToPrivateParameter, AdminConversationsConvertToPrivateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.convertToPrivate
        /// </summary>
        public async ValueTask<AdminConversationsConvertToPrivateResponse> AdminConversationsConvertToPrivateAsync(string? channel_Id, CancellationToken cancellationToken)
        {
            var p = new AdminConversationsConvertToPrivateParameter();
            p.Channel_Id = channel_Id;
            return await this.SendAsync<AdminConversationsConvertToPrivateParameter, AdminConversationsConvertToPrivateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.convertToPrivate
        /// </summary>
        public async ValueTask<AdminConversationsConvertToPrivateResponse> AdminConversationsConvertToPrivateAsync(AdminConversationsConvertToPrivateParameter parameter)
        {
            return await this.SendAsync<AdminConversationsConvertToPrivateParameter, AdminConversationsConvertToPrivateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.convertToPrivate
        /// </summary>
        public async ValueTask<AdminConversationsConvertToPrivateResponse> AdminConversationsConvertToPrivateAsync(AdminConversationsConvertToPrivateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminConversationsConvertToPrivateParameter, AdminConversationsConvertToPrivateResponse>(parameter, cancellationToken);
        }
    }
}
