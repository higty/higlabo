using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PostGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
            Body,
            Categories,
            ChangeKey,
            ConversationId,
            ConversationThreadId,
            CreatedDateTime,
            From,
            HasAttachments,
            Id,
            LastModifiedDateTime,
            NewParticipants,
            ReceivedDateTime,
            Sender,
        }
        public enum ApiPath
        {
            Groups_Id_Threads_Id_Posts_Id,
            Groups_Id_Conversations_Id_Threads_Id_Posts_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Groups_Id_Threads_Id_Posts_Id: return $"/groups/{GroupsId}/threads/{ThreadsId}/posts/{PostsId}";
                    case ApiPath.Groups_Id_Conversations_Id_Threads_Id_Posts_Id: return $"/groups/{GroupsId}/conversations/{ConversationsId}/threads/{ThreadsId}/posts/{PostsId}";
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
        public string GroupsId { get; set; }
        public string ThreadsId { get; set; }
        public string PostsId { get; set; }
        public string ConversationsId { get; set; }
    }
    public partial class PostGetResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/post-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PostGetResponse> PostGetAsync()
        {
            var p = new PostGetParameter();
            return await this.SendAsync<PostGetParameter, PostGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/post-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PostGetResponse> PostGetAsync(CancellationToken cancellationToken)
        {
            var p = new PostGetParameter();
            return await this.SendAsync<PostGetParameter, PostGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/post-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PostGetResponse> PostGetAsync(PostGetParameter parameter)
        {
            return await this.SendAsync<PostGetParameter, PostGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/post-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PostGetResponse> PostGetAsync(PostGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PostGetParameter, PostGetResponse>(parameter, cancellationToken);
        }
    }
}
