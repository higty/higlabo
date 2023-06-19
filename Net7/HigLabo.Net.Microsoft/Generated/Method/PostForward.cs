using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/post-forward?view=graph-rest-1.0
    /// </summary>
    public partial class PostForwardParameter : IRestApiParameter
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
                    case ApiPath.Groups_Id_Threads_Id_Posts_Id_Forward: return $"/groups/{GroupsId}/threads/{ThreadsId}/posts/{PostsId}/forward";
                    case ApiPath.Groups_Id_Conversations_Id_Threads_Id_Posts_Id_Forward: return $"/groups/{GroupsId}/conversations/{ConversationsId}/threads/{ThreadsId}/posts/{PostsId}/forward";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Groups_Id_Threads_Id_Posts_Id_Forward,
            Groups_Id_Conversations_Id_Threads_Id_Posts_Id_Forward,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Comment { get; set; }
        public Recipient[]? ToRecipients { get; set; }
    }
    public partial class PostForwardResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/post-forward?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/post-forward?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PostForwardResponse> PostForwardAsync()
        {
            var p = new PostForwardParameter();
            return await this.SendAsync<PostForwardParameter, PostForwardResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/post-forward?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PostForwardResponse> PostForwardAsync(CancellationToken cancellationToken)
        {
            var p = new PostForwardParameter();
            return await this.SendAsync<PostForwardParameter, PostForwardResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/post-forward?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PostForwardResponse> PostForwardAsync(PostForwardParameter parameter)
        {
            return await this.SendAsync<PostForwardParameter, PostForwardResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/post-forward?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PostForwardResponse> PostForwardAsync(PostForwardParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PostForwardParameter, PostForwardResponse>(parameter, cancellationToken);
        }
    }
}
