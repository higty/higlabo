using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PostListAttachmentsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? GroupsId { get; set; }
            public string? ThreadsId { get; set; }
            public string? PostsId { get; set; }
            public string? ConversationsId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Groups_Id_Threads_Id_Posts_Id_Attachments: return $"/groups/{GroupsId}/threads/{ThreadsId}/posts/{PostsId}/attachments";
                    case ApiPath.Groups_Id_Conversations_Id_Threads_Id_Posts_Id_Attachments: return $"/groups/{GroupsId}/conversations/{ConversationsId}/threads/{ThreadsId}/posts/{PostsId}/attachments";
                    case ApiPath.Ttps__Graphmicrosoftcom_V10_Groups_Id_Threads_Id_Posts_Id: return $"/ttps://graph.microsoft.com/v1.0/groups/{GroupsId}/threads/{ThreadsId}/posts/{PostsId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            ContentType,
            Id,
            IsInline,
            LastModifiedDateTime,
            Name,
            Size,
        }
        public enum ApiPath
        {
            Groups_Id_Threads_Id_Posts_Id_Attachments,
            Groups_Id_Conversations_Id_Threads_Id_Posts_Id_Attachments,
            Ttps__Graphmicrosoftcom_V10_Groups_Id_Threads_Id_Posts_Id,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
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
    }
    public partial class PostListAttachmentsResponse : RestApiResponse
    {
        public Attachment[]? Value { get; set; }
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
