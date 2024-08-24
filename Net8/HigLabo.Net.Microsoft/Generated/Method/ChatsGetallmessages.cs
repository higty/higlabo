using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chats-getallmessages?view=graph-rest-1.0
    /// </summary>
    public partial class ChatsGetAllMessagesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Users_IdOrUserPrincipalName_Chats_GetAllMessages: return $"/users/{IdOrUserPrincipalName}/chats/getAllMessages";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Users_IdOrUserPrincipalName_Chats_GetAllMessages,
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
    public partial class ChatsGetAllMessagesResponse : RestApiResponse
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
    /// https://learn.microsoft.com/en-us/graph/api/chats-getallmessages?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chats-getallmessages?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChatsGetAllMessagesResponse> ChatsGetAllMessagesAsync()
        {
            var p = new ChatsGetAllMessagesParameter();
            return await this.SendAsync<ChatsGetAllMessagesParameter, ChatsGetAllMessagesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chats-getallmessages?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChatsGetAllMessagesResponse> ChatsGetAllMessagesAsync(CancellationToken cancellationToken)
        {
            var p = new ChatsGetAllMessagesParameter();
            return await this.SendAsync<ChatsGetAllMessagesParameter, ChatsGetAllMessagesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chats-getallmessages?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChatsGetAllMessagesResponse> ChatsGetAllMessagesAsync(ChatsGetAllMessagesParameter parameter)
        {
            return await this.SendAsync<ChatsGetAllMessagesParameter, ChatsGetAllMessagesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chats-getallmessages?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChatsGetAllMessagesResponse> ChatsGetAllMessagesAsync(ChatsGetAllMessagesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatsGetAllMessagesParameter, ChatsGetAllMessagesResponse>(parameter, cancellationToken);
        }
    }
}
