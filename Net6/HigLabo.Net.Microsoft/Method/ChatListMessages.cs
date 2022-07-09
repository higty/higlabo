using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChatListMessagesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ChatId { get; set; }
            public string? UserIdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Chats_ChatId_Messages: return $"/me/chats/{ChatId}/messages";
                    case ApiPath.Users_UserIdOrUserPrincipalName_Chats_ChatId_Messages: return $"/users/{UserIdOrUserPrincipalName}/chats/{ChatId}/messages";
                    case ApiPath.Chats_ChatId_Messages: return $"/chats/{ChatId}/messages";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Id,
            ReplyToId,
            From,
            Etag,
            MessageType,
            CreatedDateTime,
            LastModifiedDateTime,
            LastEditedDateTime,
            DeletedDateTime,
            Subject,
            Body,
            Summary,
            Attachments,
            Mentions,
            Importance,
            Reactions,
            Locale,
            PolicyViolation,
            ChatId,
            ChannelIdentity,
            WebUrl,
            EventDetail,
            Replies,
            HostedContents,
        }
        public enum ApiPath
        {
            Me_Chats_ChatId_Messages,
            Users_UserIdOrUserPrincipalName_Chats_ChatId_Messages,
            Chats_ChatId_Messages,
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
    public partial class ChatListMessagesResponse : RestApiResponse
    {
        public ChatMessage[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-list-messages?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatListMessagesResponse> ChatListMessagesAsync()
        {
            var p = new ChatListMessagesParameter();
            return await this.SendAsync<ChatListMessagesParameter, ChatListMessagesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-list-messages?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatListMessagesResponse> ChatListMessagesAsync(CancellationToken cancellationToken)
        {
            var p = new ChatListMessagesParameter();
            return await this.SendAsync<ChatListMessagesParameter, ChatListMessagesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-list-messages?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatListMessagesResponse> ChatListMessagesAsync(ChatListMessagesParameter parameter)
        {
            return await this.SendAsync<ChatListMessagesParameter, ChatListMessagesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-list-messages?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatListMessagesResponse> ChatListMessagesAsync(ChatListMessagesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatListMessagesParameter, ChatListMessagesResponse>(parameter, cancellationToken);
        }
    }
}
