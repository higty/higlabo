using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PostReplyParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Groups_Id_Threads_Id_Posts_Id_Reply,
            Groups_Id_Conversations_Id_Threads_Id_Posts_Id_Reply,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Groups_Id_Threads_Id_Posts_Id_Reply: return $"/groups/{GroupsId}/threads/{ThreadsId}/posts/{PostsId}/reply";
                    case ApiPath.Groups_Id_Conversations_Id_Threads_Id_Posts_Id_Reply: return $"/groups/{GroupsId}/conversations/{ConversationsId}/threads/{ThreadsId}/posts/{PostsId}/reply";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public Post? Post { get; set; }
        public string GroupsId { get; set; }
        public string ThreadsId { get; set; }
        public string PostsId { get; set; }
        public string ConversationsId { get; set; }
    }
    public partial class PostReplyResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/post-reply?view=graph-rest-1.0
        /// </summary>
        public async Task<PostReplyResponse> PostReplyAsync()
        {
            var p = new PostReplyParameter();
            return await this.SendAsync<PostReplyParameter, PostReplyResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/post-reply?view=graph-rest-1.0
        /// </summary>
        public async Task<PostReplyResponse> PostReplyAsync(CancellationToken cancellationToken)
        {
            var p = new PostReplyParameter();
            return await this.SendAsync<PostReplyParameter, PostReplyResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/post-reply?view=graph-rest-1.0
        /// </summary>
        public async Task<PostReplyResponse> PostReplyAsync(PostReplyParameter parameter)
        {
            return await this.SendAsync<PostReplyParameter, PostReplyResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/post-reply?view=graph-rest-1.0
        /// </summary>
        public async Task<PostReplyResponse> PostReplyAsync(PostReplyParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PostReplyParameter, PostReplyResponse>(parameter, cancellationToken);
        }
    }
}
