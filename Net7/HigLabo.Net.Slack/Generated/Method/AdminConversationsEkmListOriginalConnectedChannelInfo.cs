using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class AdminConversationsEkmListOriginalConnectedChannelInfoParameter : IRestApiParameter, IRestApiPagingParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.conversations.ekm.listOriginalConnectedChannelInfo";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string? Channel_Ids { get; set; }
        public string? Cursor { get; set; }
        string? IRestApiPagingParameter.NextPageToken
        {
            get
            {
                return this.Cursor;
            }
            set
            {
                this.Cursor = value;
            }
        }
        public int? Limit { get; set; }
        public string? Team_Ids { get; set; }
    }
    public partial class AdminConversationsEkmListOriginalConnectedChannelInfoResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.conversations.ekm.listOriginalConnectedChannelInfo
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.ekm.listOriginalConnectedChannelInfo
        /// </summary>
        public async ValueTask<AdminConversationsEkmListOriginalConnectedChannelInfoResponse> AdminConversationsEkmListOriginalConnectedChannelInfoAsync()
        {
            var p = new AdminConversationsEkmListOriginalConnectedChannelInfoParameter();
            return await this.SendAsync<AdminConversationsEkmListOriginalConnectedChannelInfoParameter, AdminConversationsEkmListOriginalConnectedChannelInfoResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.ekm.listOriginalConnectedChannelInfo
        /// </summary>
        public async ValueTask<AdminConversationsEkmListOriginalConnectedChannelInfoResponse> AdminConversationsEkmListOriginalConnectedChannelInfoAsync(CancellationToken cancellationToken)
        {
            var p = new AdminConversationsEkmListOriginalConnectedChannelInfoParameter();
            return await this.SendAsync<AdminConversationsEkmListOriginalConnectedChannelInfoParameter, AdminConversationsEkmListOriginalConnectedChannelInfoResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.ekm.listOriginalConnectedChannelInfo
        /// </summary>
        public async ValueTask<AdminConversationsEkmListOriginalConnectedChannelInfoResponse> AdminConversationsEkmListOriginalConnectedChannelInfoAsync(AdminConversationsEkmListOriginalConnectedChannelInfoParameter parameter)
        {
            return await this.SendAsync<AdminConversationsEkmListOriginalConnectedChannelInfoParameter, AdminConversationsEkmListOriginalConnectedChannelInfoResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.ekm.listOriginalConnectedChannelInfo
        /// </summary>
        public async ValueTask<AdminConversationsEkmListOriginalConnectedChannelInfoResponse> AdminConversationsEkmListOriginalConnectedChannelInfoAsync(AdminConversationsEkmListOriginalConnectedChannelInfoParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminConversationsEkmListOriginalConnectedChannelInfoParameter, AdminConversationsEkmListOriginalConnectedChannelInfoResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.ekm.listOriginalConnectedChannelInfo
        /// </summary>
        public async ValueTask<List<AdminConversationsEkmListOriginalConnectedChannelInfoResponse>> AdminConversationsEkmListOriginalConnectedChannelInfoAsync(PagingContext<AdminConversationsEkmListOriginalConnectedChannelInfoResponse> context)
        {
            var p = new AdminConversationsEkmListOriginalConnectedChannelInfoParameter();
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.ekm.listOriginalConnectedChannelInfo
        /// </summary>
        public async ValueTask<List<AdminConversationsEkmListOriginalConnectedChannelInfoResponse>> AdminConversationsEkmListOriginalConnectedChannelInfoAsync(CancellationToken cancellationToken, PagingContext<AdminConversationsEkmListOriginalConnectedChannelInfoResponse> context)
        {
            var p = new AdminConversationsEkmListOriginalConnectedChannelInfoParameter();
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.ekm.listOriginalConnectedChannelInfo
        /// </summary>
        public async ValueTask<List<AdminConversationsEkmListOriginalConnectedChannelInfoResponse>> AdminConversationsEkmListOriginalConnectedChannelInfoAsync(AdminConversationsEkmListOriginalConnectedChannelInfoParameter parameter, PagingContext<AdminConversationsEkmListOriginalConnectedChannelInfoResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.ekm.listOriginalConnectedChannelInfo
        /// </summary>
        public async ValueTask<List<AdminConversationsEkmListOriginalConnectedChannelInfoResponse>> AdminConversationsEkmListOriginalConnectedChannelInfoAsync(AdminConversationsEkmListOriginalConnectedChannelInfoParameter parameter, PagingContext<AdminConversationsEkmListOriginalConnectedChannelInfoResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}
