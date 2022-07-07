using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ConversationthreadListPostsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Groups_GroupId_Threads_ThreadId_Posts,
            Groups_GroupId_Conversations_ConversationId_Threads_ThreadId_Posts,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Groups_GroupId_Threads_ThreadId_Posts: return $"/groups/{GroupId}/threads/{ThreadId}/posts";
                    case ApiPath.Groups_GroupId_Conversations_ConversationId_Threads_ThreadId_Posts: return $"/groups/{GroupId}/conversations/{ConversationId}/threads/{ThreadId}/posts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string GroupId { get; set; }
        public string ThreadId { get; set; }
        public string ConversationId { get; set; }
    }
    public partial class ConversationthreadListPostsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/post?view=graph-rest-1.0
        /// </summary>
        public partial class Post
        {
            public ItemBody? Body { get; set; }
            public String[]? Categories { get; set; }
            public string? ChangeKey { get; set; }
            public string? ConversationId { get; set; }
            public string? ConversationThreadId { get; set; }
            public DateTimeOffset? CreatedDateTime { get; set; }
            public Recipient? From { get; set; }
            public bool? HasAttachments { get; set; }
            public string? Id { get; set; }
            public DateTimeOffset? LastModifiedDateTime { get; set; }
            public Recipient[]? NewParticipants { get; set; }
            public DateTimeOffset? ReceivedDateTime { get; set; }
            public Recipient? Sender { get; set; }
        }

        public Post[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conversationthread-list-posts?view=graph-rest-1.0
        /// </summary>
        public async Task<ConversationthreadListPostsResponse> ConversationthreadListPostsAsync()
        {
            var p = new ConversationthreadListPostsParameter();
            return await this.SendAsync<ConversationthreadListPostsParameter, ConversationthreadListPostsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conversationthread-list-posts?view=graph-rest-1.0
        /// </summary>
        public async Task<ConversationthreadListPostsResponse> ConversationthreadListPostsAsync(CancellationToken cancellationToken)
        {
            var p = new ConversationthreadListPostsParameter();
            return await this.SendAsync<ConversationthreadListPostsParameter, ConversationthreadListPostsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conversationthread-list-posts?view=graph-rest-1.0
        /// </summary>
        public async Task<ConversationthreadListPostsResponse> ConversationthreadListPostsAsync(ConversationthreadListPostsParameter parameter)
        {
            return await this.SendAsync<ConversationthreadListPostsParameter, ConversationthreadListPostsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conversationthread-list-posts?view=graph-rest-1.0
        /// </summary>
        public async Task<ConversationthreadListPostsResponse> ConversationthreadListPostsAsync(ConversationthreadListPostsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConversationthreadListPostsParameter, ConversationthreadListPostsResponse>(parameter, cancellationToken);
        }
    }
}
