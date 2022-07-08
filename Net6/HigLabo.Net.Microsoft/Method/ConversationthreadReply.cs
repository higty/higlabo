using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ConversationthreadReplyParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string GroupsId { get; set; }
            public string ThreadsId { get; set; }
            public string ConversationsId { get; set; }

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
    public partial class ConversationthreadReplyResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conversationthread-reply?view=graph-rest-1.0
        /// </summary>
        public async Task<ConversationthreadReplyResponse> ConversationthreadReplyAsync()
        {
            var p = new ConversationthreadReplyParameter();
            return await this.SendAsync<ConversationthreadReplyParameter, ConversationthreadReplyResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conversationthread-reply?view=graph-rest-1.0
        /// </summary>
        public async Task<ConversationthreadReplyResponse> ConversationthreadReplyAsync(CancellationToken cancellationToken)
        {
            var p = new ConversationthreadReplyParameter();
            return await this.SendAsync<ConversationthreadReplyParameter, ConversationthreadReplyResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conversationthread-reply?view=graph-rest-1.0
        /// </summary>
        public async Task<ConversationthreadReplyResponse> ConversationthreadReplyAsync(ConversationthreadReplyParameter parameter)
        {
            return await this.SendAsync<ConversationthreadReplyParameter, ConversationthreadReplyResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conversationthread-reply?view=graph-rest-1.0
        /// </summary>
        public async Task<ConversationthreadReplyResponse> ConversationthreadReplyAsync(ConversationthreadReplyParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConversationthreadReplyParameter, ConversationthreadReplyResponse>(parameter, cancellationToken);
        }
    }
}
