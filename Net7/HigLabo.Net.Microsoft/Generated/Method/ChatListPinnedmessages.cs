using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chat-list-pinnedmessages?view=graph-rest-1.0
    /// </summary>
    public partial class ChatListPinnedmessagesParameter : IRestApiParameter, IQueryParameterProperty
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

        public enum Field
        {
            Id,
            Message,
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
    public partial class ChatListPinnedmessagesResponse : RestApiResponse
    {
        public PinnedChatMessageInfo[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chat-list-pinnedmessages?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-list-pinnedmessages?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChatListPinnedmessagesResponse> ChatListPinnedmessagesAsync()
        {
            var p = new ChatListPinnedmessagesParameter();
            return await this.SendAsync<ChatListPinnedmessagesParameter, ChatListPinnedmessagesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-list-pinnedmessages?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChatListPinnedmessagesResponse> ChatListPinnedmessagesAsync(CancellationToken cancellationToken)
        {
            var p = new ChatListPinnedmessagesParameter();
            return await this.SendAsync<ChatListPinnedmessagesParameter, ChatListPinnedmessagesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-list-pinnedmessages?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChatListPinnedmessagesResponse> ChatListPinnedmessagesAsync(ChatListPinnedmessagesParameter parameter)
        {
            return await this.SendAsync<ChatListPinnedmessagesParameter, ChatListPinnedmessagesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-list-pinnedmessages?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChatListPinnedmessagesResponse> ChatListPinnedmessagesAsync(ChatListPinnedmessagesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatListPinnedmessagesParameter, ChatListPinnedmessagesResponse>(parameter, cancellationToken);
        }
    }
}
