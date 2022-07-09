using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PostPostAttachmentsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? GroupsId { get; set; }
            public string? ThreadsId { get; set; }
            public string? ConversationsId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Groups_Id_Threads_Id_Reply: return $"/groups/{GroupsId}/threads/{ThreadsId}/reply";
                    case ApiPath.Groups_Id_Conversations_Id_Threads_Id_Reply: return $"/groups/{GroupsId}/conversations/{ConversationsId}/threads/{ThreadsId}/reply";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Groups_Id_Threads_Id_Reply,
            Groups_Id_Conversations_Id_Threads_Id_Reply,
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
        public Post? Post { get; set; }
    }
    public partial class PostPostAttachmentsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/post-post-attachments?view=graph-rest-1.0
        /// </summary>
        public async Task<PostPostAttachmentsResponse> PostPostAttachmentsAsync()
        {
            var p = new PostPostAttachmentsParameter();
            return await this.SendAsync<PostPostAttachmentsParameter, PostPostAttachmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/post-post-attachments?view=graph-rest-1.0
        /// </summary>
        public async Task<PostPostAttachmentsResponse> PostPostAttachmentsAsync(CancellationToken cancellationToken)
        {
            var p = new PostPostAttachmentsParameter();
            return await this.SendAsync<PostPostAttachmentsParameter, PostPostAttachmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/post-post-attachments?view=graph-rest-1.0
        /// </summary>
        public async Task<PostPostAttachmentsResponse> PostPostAttachmentsAsync(PostPostAttachmentsParameter parameter)
        {
            return await this.SendAsync<PostPostAttachmentsParameter, PostPostAttachmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/post-post-attachments?view=graph-rest-1.0
        /// </summary>
        public async Task<PostPostAttachmentsResponse> PostPostAttachmentsAsync(PostPostAttachmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PostPostAttachmentsParameter, PostPostAttachmentsResponse>(parameter, cancellationToken);
        }
    }
}
