using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PostListAttachmentsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Groups_Id_Threads_Id_Posts_Id_Attachments,
            Groups_Id_Conversations_Id_Threads_Id_Posts_Id_Attachments,
            Ttps__Graphmicrosoftcom_V10_Groups_Id_Threads_Id_Posts_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Groups_Id_Threads_Id_Posts_Id_Attachments: return $"/groups/{GroupsId}/threads/{ThreadsId}/posts/{PostsId}/attachments";
                    case ApiPath.Groups_Id_Conversations_Id_Threads_Id_Posts_Id_Attachments: return $"/groups/{GroupsId}/conversations/{ConversationsId}/threads/{ThreadsId}/posts/{PostsId}/attachments";
                    case ApiPath.Ttps__Graphmicrosoftcom_V10_Groups_Id_Threads_Id_Posts_Id: return $"/ttps://graph.microsoft.com/v1.0/groups/{GroupsId}/threads/{ThreadsId}/posts/{PostsId}";
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
    public partial class PostListAttachmentsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/attachment?view=graph-rest-1.0
        /// </summary>
        public partial class Attachment
        {
            public string? ContentType { get; set; }
            public string? Id { get; set; }
            public bool? IsInline { get; set; }
            public DateTimeOffset? LastModifiedDateTime { get; set; }
            public string? Name { get; set; }
            public Int32? Size { get; set; }
        }

        public Attachment[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/post-list-attachments?view=graph-rest-1.0
        /// </summary>
        public async Task<PostListAttachmentsResponse> PostListAttachmentsAsync()
        {
            var p = new PostListAttachmentsParameter();
            return await this.SendAsync<PostListAttachmentsParameter, PostListAttachmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/post-list-attachments?view=graph-rest-1.0
        /// </summary>
        public async Task<PostListAttachmentsResponse> PostListAttachmentsAsync(CancellationToken cancellationToken)
        {
            var p = new PostListAttachmentsParameter();
            return await this.SendAsync<PostListAttachmentsParameter, PostListAttachmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/post-list-attachments?view=graph-rest-1.0
        /// </summary>
        public async Task<PostListAttachmentsResponse> PostListAttachmentsAsync(PostListAttachmentsParameter parameter)
        {
            return await this.SendAsync<PostListAttachmentsParameter, PostListAttachmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/post-list-attachments?view=graph-rest-1.0
        /// </summary>
        public async Task<PostListAttachmentsResponse> PostListAttachmentsAsync(PostListAttachmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PostListAttachmentsParameter, PostListAttachmentsResponse>(parameter, cancellationToken);
        }
    }
}
