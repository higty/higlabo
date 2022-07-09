using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class AdminConversationsSearchParameter : IRestApiParameter, IRestApiPagingParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.conversations.search";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Connected_Team_Ids { get; set; }
        public string? Cursor { get; set; }
        string IRestApiPagingParameter.NextPageToken
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
        public string? Query { get; set; }
        public string? Search_Channel_Types { get; set; }
        public Sort Sort { get; set; }
        public SortDirection Sort_Dir { get; set; }
        public string? Team_Ids { get; set; }
    }
    public partial class AdminConversationsSearchResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.search
        /// </summary>
        public async Task<AdminConversationsSearchResponse> AdminConversationsSearchAsync()
        {
            var p = new AdminConversationsSearchParameter();
            return await this.SendAsync<AdminConversationsSearchParameter, AdminConversationsSearchResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.search
        /// </summary>
        public async Task<AdminConversationsSearchResponse> AdminConversationsSearchAsync(CancellationToken cancellationToken)
        {
            var p = new AdminConversationsSearchParameter();
            return await this.SendAsync<AdminConversationsSearchParameter, AdminConversationsSearchResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.search
        /// </summary>
        public async Task<AdminConversationsSearchResponse> AdminConversationsSearchAsync(AdminConversationsSearchParameter parameter)
        {
            return await this.SendAsync<AdminConversationsSearchParameter, AdminConversationsSearchResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.search
        /// </summary>
        public async Task<AdminConversationsSearchResponse> AdminConversationsSearchAsync(AdminConversationsSearchParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminConversationsSearchParameter, AdminConversationsSearchResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.search
        /// </summary>
        public async Task<List<AdminConversationsSearchResponse>> AdminConversationsSearchAsync(PagingContext<AdminConversationsSearchResponse> context)
        {
            var p = new AdminConversationsSearchParameter();
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.search
        /// </summary>
        public async Task<List<AdminConversationsSearchResponse>> AdminConversationsSearchAsync(CancellationToken cancellationToken, PagingContext<AdminConversationsSearchResponse> context)
        {
            var p = new AdminConversationsSearchParameter();
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.search
        /// </summary>
        public async Task<List<AdminConversationsSearchResponse>> AdminConversationsSearchAsync(AdminConversationsSearchParameter parameter, PagingContext<AdminConversationsSearchResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.search
        /// </summary>
        public async Task<List<AdminConversationsSearchResponse>> AdminConversationsSearchAsync(AdminConversationsSearchParameter parameter, PagingContext<AdminConversationsSearchResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}
