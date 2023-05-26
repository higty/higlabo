using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chatmessage-get?view=graph-rest-1.0
    /// </summary>
    public partial class ChatmessageGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? TeamId { get; set; }
            public string? ChannelId { get; set; }
            public string? MessageId { get; set; }
            public string? ReplyId { get; set; }
            public string? ChatId { get; set; }
            public string? UserIdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_TeamId_Channels_ChannelId_Messages_MessageId: return $"/teams/{TeamId}/channels/{ChannelId}/messages/{MessageId}";
                    case ApiPath.Teams_TeamId_Channels_ChannelId_Messages_MessageId_Replies_ReplyId: return $"/teams/{TeamId}/channels/{ChannelId}/messages/{MessageId}/replies/{ReplyId}";
                    case ApiPath.Chats_ChatId_Messages_MessageId: return $"/chats/{ChatId}/messages/{MessageId}";
                    case ApiPath.Users_UserIdOrUserPrincipalName_Chats_ChatId_Messages_MessageId: return $"/users/{UserIdOrUserPrincipalName}/chats/{ChatId}/messages/{MessageId}";
                    case ApiPath.Me_Chats_ChatId_Messages_MessageId: return $"/me/chats/{ChatId}/messages/{MessageId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Teams_TeamId_Channels_ChannelId_Messages_MessageId,
            Teams_TeamId_Channels_ChannelId_Messages_MessageId_Replies_ReplyId,
            Chats_ChatId_Messages_MessageId,
            Users_UserIdOrUserPrincipalName_Chats_ChatId_Messages_MessageId,
            Me_Chats_ChatId_Messages_MessageId,
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
    public partial class ChatmessageGetResponse : RestApiResponse
    {
        public enum ChatMessagestring
        {
            Normal,
            High,
            Urgent,
        }
        public enum ChatMessageChatMessageType
        {
            Message,
            ChatEvent,
            Typing,
            UnknownFutureValue,
            SystemEventMessage,
        }

        public ChatMessageAttachment[]? Attachments { get; set; }
        public ItemBody? Body { get; set; }
        public string? ChatId { get; set; }
        public ChannelIdentity? ChannelIdentity { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public DateTimeOffset? DeletedDateTime { get; set; }
        public string? Etag { get; set; }
        public EventMessageDetail? EventDetail { get; set; }
        public ChatMessageFromIdentitySet? From { get; set; }
        public string? Id { get; set; }
        public ChatMessagestring Importance { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DateTimeOffset? LastEditedDateTime { get; set; }
        public string? Locale { get; set; }
        public ChatMessageMention[]? Mentions { get; set; }
        public ChatMessageHistoryItem[]? MessageHistory { get; set; }
        public ChatMessageChatMessageType MessageType { get; set; }
        public ChatMessagePolicyViolation? PolicyViolation { get; set; }
        public ChatMessageReAction[]? Reactions { get; set; }
        public string? ReplyToId { get; set; }
        public string? Subject { get; set; }
        public string? Summary { get; set; }
        public string? WebUrl { get; set; }
        public ChatMessageHostedContent? HostedContents { get; set; }
        public ChatMessage? Replies { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chatmessage-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chatmessage-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatmessageGetResponse> ChatmessageGetAsync()
        {
            var p = new ChatmessageGetParameter();
            return await this.SendAsync<ChatmessageGetParameter, ChatmessageGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chatmessage-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatmessageGetResponse> ChatmessageGetAsync(CancellationToken cancellationToken)
        {
            var p = new ChatmessageGetParameter();
            return await this.SendAsync<ChatmessageGetParameter, ChatmessageGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chatmessage-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatmessageGetResponse> ChatmessageGetAsync(ChatmessageGetParameter parameter)
        {
            return await this.SendAsync<ChatmessageGetParameter, ChatmessageGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chatmessage-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatmessageGetResponse> ChatmessageGetAsync(ChatmessageGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatmessageGetParameter, ChatmessageGetResponse>(parameter, cancellationToken);
        }
    }
}
