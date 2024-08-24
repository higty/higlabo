using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/conversationthread-list-posts?view=graph-rest-1.0
    /// </summary>
    public partial class ConversationthreadListPostsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? GroupId { get; set; }
            public string? ThreadId { get; set; }
            public string? ConversationId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Groups_GroupId_Threads_ThreadId_Posts: return $"/groups/{GroupId}/threads/{ThreadId}/posts";
                    case ApiPath.Groups_GroupId_Conversations_ConversationId_Threads_ThreadId_Posts: return $"/groups/{GroupId}/conversations/{ConversationId}/threads/{ThreadId}/posts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Groups_GroupId_Threads_ThreadId_Posts,
            Groups_GroupId_Conversations_ConversationId_Threads_ThreadId_Posts,
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
    public partial class ConversationthreadListPostsResponse : RestApiResponse<Post>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/conversationthread-list-posts?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/conversationthread-list-posts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ConversationthreadListPostsResponse> ConversationthreadListPostsAsync()
        {
            var p = new ConversationthreadListPostsParameter();
            return await this.SendAsync<ConversationthreadListPostsParameter, ConversationthreadListPostsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/conversationthread-list-posts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ConversationthreadListPostsResponse> ConversationthreadListPostsAsync(CancellationToken cancellationToken)
        {
            var p = new ConversationthreadListPostsParameter();
            return await this.SendAsync<ConversationthreadListPostsParameter, ConversationthreadListPostsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/conversationthread-list-posts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ConversationthreadListPostsResponse> ConversationthreadListPostsAsync(ConversationthreadListPostsParameter parameter)
        {
            return await this.SendAsync<ConversationthreadListPostsParameter, ConversationthreadListPostsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/conversationthread-list-posts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ConversationthreadListPostsResponse> ConversationthreadListPostsAsync(ConversationthreadListPostsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConversationthreadListPostsParameter, ConversationthreadListPostsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/conversationthread-list-posts?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<Post> ConversationthreadListPostsEnumerateAsync(ConversationthreadListPostsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<ConversationthreadListPostsParameter, ConversationthreadListPostsResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<Post>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
