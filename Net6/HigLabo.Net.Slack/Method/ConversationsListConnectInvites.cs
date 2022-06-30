
namespace HigLabo.Net.Slack
{
    public partial class ConversationsListConnectInvitesParameter : IRestApiParameter, IRestApiPagingParameter
    {
        string IRestApiParameter.ApiPath { get; } = "conversations.listConnectInvites";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public int? Count { get; set; }
        public string Cursor { get; set; }
        string IRestApiPagingParameter.NextPageToken { get; set; }
        public string Team_Id { get; set; }
    }
    public partial class ConversationsListConnectInvitesResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/conversations.listConnectInvites
        /// </summary>
        public async Task<ConversationsListConnectInvitesResponse> ConversationsListConnectInvitesAsync()
        {
            var p = new ConversationsListConnectInvitesParameter();
            return await this.SendAsync<ConversationsListConnectInvitesParameter, ConversationsListConnectInvitesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/conversations.listConnectInvites
        /// </summary>
        public async Task<ConversationsListConnectInvitesResponse> ConversationsListConnectInvitesAsync(CancellationToken cancellationToken)
        {
            var p = new ConversationsListConnectInvitesParameter();
            return await this.SendAsync<ConversationsListConnectInvitesParameter, ConversationsListConnectInvitesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/conversations.listConnectInvites
        /// </summary>
        public async Task<ConversationsListConnectInvitesResponse> ConversationsListConnectInvitesAsync(ConversationsListConnectInvitesParameter parameter)
        {
            return await this.SendAsync<ConversationsListConnectInvitesParameter, ConversationsListConnectInvitesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/conversations.listConnectInvites
        /// </summary>
        public async Task<ConversationsListConnectInvitesResponse> ConversationsListConnectInvitesAsync(ConversationsListConnectInvitesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConversationsListConnectInvitesParameter, ConversationsListConnectInvitesResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/conversations.listConnectInvites
        /// </summary>
        public async Task<List<ConversationsListConnectInvitesResponse>> ConversationsListConnectInvitesAsync(PagingContext<ConversationsListConnectInvitesResponse> context)
        {
            var p = new ConversationsListConnectInvitesParameter();
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/conversations.listConnectInvites
        /// </summary>
        public async Task<List<ConversationsListConnectInvitesResponse>> ConversationsListConnectInvitesAsync(CancellationToken cancellationToken, PagingContext<ConversationsListConnectInvitesResponse> context)
        {
            var p = new ConversationsListConnectInvitesParameter();
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/conversations.listConnectInvites
        /// </summary>
        public async Task<List<ConversationsListConnectInvitesResponse>> ConversationsListConnectInvitesAsync(ConversationsListConnectInvitesParameter parameter, PagingContext<ConversationsListConnectInvitesResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/conversations.listConnectInvites
        /// </summary>
        public async Task<List<ConversationsListConnectInvitesResponse>> ConversationsListConnectInvitesAsync(ConversationsListConnectInvitesParameter parameter, PagingContext<ConversationsListConnectInvitesResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}
