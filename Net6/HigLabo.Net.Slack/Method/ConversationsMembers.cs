using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class ConversationsMembersParameter : IRestApiParameter, IRestApiPagingParameter
    {
        string IRestApiParameter.ApiPath { get; } = "conversations.members";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string Channel { get; set; }
        public string Cursor { get; set; }
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
        public double? Limit { get; set; }
    }
    public partial class ConversationsMembersResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/conversations.members
        /// </summary>
        public async Task<ConversationsMembersResponse> ConversationsMembersAsync(string channel)
        {
            var p = new ConversationsMembersParameter();
            p.Channel = channel;
            return await this.SendAsync<ConversationsMembersParameter, ConversationsMembersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/conversations.members
        /// </summary>
        public async Task<ConversationsMembersResponse> ConversationsMembersAsync(string channel, CancellationToken cancellationToken)
        {
            var p = new ConversationsMembersParameter();
            p.Channel = channel;
            return await this.SendAsync<ConversationsMembersParameter, ConversationsMembersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/conversations.members
        /// </summary>
        public async Task<ConversationsMembersResponse> ConversationsMembersAsync(ConversationsMembersParameter parameter)
        {
            return await this.SendAsync<ConversationsMembersParameter, ConversationsMembersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/conversations.members
        /// </summary>
        public async Task<ConversationsMembersResponse> ConversationsMembersAsync(ConversationsMembersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConversationsMembersParameter, ConversationsMembersResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/conversations.members
        /// </summary>
        public async Task<List<ConversationsMembersResponse>> ConversationsMembersAsync(string channel, PagingContext<ConversationsMembersResponse> context)
        {
            var p = new ConversationsMembersParameter();
            p.Channel = channel;
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/conversations.members
        /// </summary>
        public async Task<List<ConversationsMembersResponse>> ConversationsMembersAsync(string channel, PagingContext<ConversationsMembersResponse> context, CancellationToken cancellationToken)
        {
            var p = new ConversationsMembersParameter();
            p.Channel = channel;
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/conversations.members
        /// </summary>
        public async Task<List<ConversationsMembersResponse>> ConversationsMembersAsync(ConversationsMembersParameter parameter, PagingContext<ConversationsMembersResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/conversations.members
        /// </summary>
        public async Task<List<ConversationsMembersResponse>> ConversationsMembersAsync(ConversationsMembersParameter parameter, PagingContext<ConversationsMembersResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}
