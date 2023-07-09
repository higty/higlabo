using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chat-post-pinnedmessages?view=graph-rest-1.0
    /// </summary>
    public partial class ChatPostPinnedmessagesParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ChatId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Chats_ChatId_PinnedMessages: return $"/chats/{ChatId}/pinnedMessages";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Chats_ChatId_PinnedMessages,
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
        public string? Id { get; set; }
        public ChatMessage? Message { get; set; }
    }
    public partial class ChatPostPinnedmessagesResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public ChatMessage? Message { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chat-post-pinnedmessages?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-post-pinnedmessages?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChatPostPinnedmessagesResponse> ChatPostPinnedmessagesAsync()
        {
            var p = new ChatPostPinnedmessagesParameter();
            return await this.SendAsync<ChatPostPinnedmessagesParameter, ChatPostPinnedmessagesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-post-pinnedmessages?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChatPostPinnedmessagesResponse> ChatPostPinnedmessagesAsync(CancellationToken cancellationToken)
        {
            var p = new ChatPostPinnedmessagesParameter();
            return await this.SendAsync<ChatPostPinnedmessagesParameter, ChatPostPinnedmessagesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-post-pinnedmessages?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChatPostPinnedmessagesResponse> ChatPostPinnedmessagesAsync(ChatPostPinnedmessagesParameter parameter)
        {
            return await this.SendAsync<ChatPostPinnedmessagesParameter, ChatPostPinnedmessagesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-post-pinnedmessages?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChatPostPinnedmessagesResponse> ChatPostPinnedmessagesAsync(ChatPostPinnedmessagesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatPostPinnedmessagesParameter, ChatPostPinnedmessagesResponse>(parameter, cancellationToken);
        }
    }
}
