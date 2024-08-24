using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/post-list-attachments?view=graph-rest-1.0
    /// </summary>
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
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Groups_Id_Threads_Id_Posts_Id_Attachments,
            Groups_Id_Conversations_Id_Threads_Id_Posts_Id_Attachments,
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
    public partial class PostListAttachmentsResponse : RestApiResponse<Attachment>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/post-list-attachments?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/post-list-attachments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PostListAttachmentsResponse> PostListAttachmentsAsync()
        {
            var p = new PostListAttachmentsParameter();
            return await this.SendAsync<PostListAttachmentsParameter, PostListAttachmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/post-list-attachments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PostListAttachmentsResponse> PostListAttachmentsAsync(CancellationToken cancellationToken)
        {
            var p = new PostListAttachmentsParameter();
            return await this.SendAsync<PostListAttachmentsParameter, PostListAttachmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/post-list-attachments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PostListAttachmentsResponse> PostListAttachmentsAsync(PostListAttachmentsParameter parameter)
        {
            return await this.SendAsync<PostListAttachmentsParameter, PostListAttachmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/post-list-attachments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PostListAttachmentsResponse> PostListAttachmentsAsync(PostListAttachmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PostListAttachmentsParameter, PostListAttachmentsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/post-list-attachments?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<Attachment> PostListAttachmentsEnumerateAsync(PostListAttachmentsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<PostListAttachmentsParameter, PostListAttachmentsResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<Attachment>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
