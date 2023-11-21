using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    /// <summary>
    /// https://api.slack.com/methods/admin.emoji.list
    /// </summary>
    public partial class AdminEmojiListParameter : IRestApiParameter, IRestApiPagingParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.emoji.list";
        string IRestApiParameter.HttpMethod { get; } = "GET";
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
    }
    public partial class AdminEmojiListResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.emoji.list
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.emoji.list
        /// </summary>
        public async ValueTask<AdminEmojiListResponse> AdminEmojiListAsync()
        {
            var p = new AdminEmojiListParameter();
            return await this.SendAsync<AdminEmojiListParameter, AdminEmojiListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.emoji.list
        /// </summary>
        public async ValueTask<AdminEmojiListResponse> AdminEmojiListAsync(CancellationToken cancellationToken)
        {
            var p = new AdminEmojiListParameter();
            return await this.SendAsync<AdminEmojiListParameter, AdminEmojiListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.emoji.list
        /// </summary>
        public async ValueTask<AdminEmojiListResponse> AdminEmojiListAsync(AdminEmojiListParameter parameter)
        {
            return await this.SendAsync<AdminEmojiListParameter, AdminEmojiListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.emoji.list
        /// </summary>
        public async ValueTask<AdminEmojiListResponse> AdminEmojiListAsync(AdminEmojiListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminEmojiListParameter, AdminEmojiListResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.emoji.list
        /// </summary>
        public async Task<List<AdminEmojiListResponse>> AdminEmojiListAsync(PagingContext<AdminEmojiListResponse> context)
        {
            var p = new AdminEmojiListParameter();
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.emoji.list
        /// </summary>
        public async Task<List<AdminEmojiListResponse>> AdminEmojiListAsync(CancellationToken cancellationToken, PagingContext<AdminEmojiListResponse> context)
        {
            var p = new AdminEmojiListParameter();
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.emoji.list
        /// </summary>
        public async ValueTask<List<AdminEmojiListResponse>> AdminEmojiListAsync(AdminEmojiListParameter parameter, PagingContext<AdminEmojiListResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.emoji.list
        /// </summary>
        public async ValueTask<List<AdminEmojiListResponse>> AdminEmojiListAsync(AdminEmojiListParameter parameter, PagingContext<AdminEmojiListResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}
