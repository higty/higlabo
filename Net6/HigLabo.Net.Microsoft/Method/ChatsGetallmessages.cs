using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChatsGetallmessagesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Users_IdOrUserPrincipalName_Chats_GetAllMessages,
            Users_Id_Chats_GetAllMessages,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Users_IdOrUserPrincipalName_Chats_GetAllMessages: return $"/users/{IdOrUserPrincipalName}/chats/getAllMessages";
                    case ApiPath.Users_Id_Chats_GetAllMessages: return $"/users/{Id}/chats/getAllMessages";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
        public string IdOrUserPrincipalName { get; set; }
        public string Id { get; set; }
    }
    public partial class ChatsGetallmessagesResponse : RestApiResponse
    {
        public enum ChatMessageChatMessageType
        {
            Message,
            ChatEvent,
            Typing,
            UnknownFutureValue,
            SystemEventMessage,
        }
        public enum ChatMessagestring
        {
            Normal,
            High,
            Urgent,
        }

        public string? Id { get; set; }
        public string? ReplyToId { get; set; }
        public ChatMessageFromIdentitySet? From { get; set; }
        public string? Etag { get; set; }
        public ChatMessageChatMessageType MessageType { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DateTimeOffset? LastEditedDateTime { get; set; }
        public DateTimeOffset? DeletedDateTime { get; set; }
        public string? Subject { get; set; }
        public ItemBody? Body { get; set; }
        public string? Summary { get; set; }
        public ChatMessageAttachment[]? Attachments { get; set; }
        public ChatMessageMention[]? Mentions { get; set; }
        public ChatMessagestring Importance { get; set; }
        public ChatMessageReaction[]? Reactions { get; set; }
        public string? Locale { get; set; }
        public ChatMessagePolicyViolation? PolicyViolation { get; set; }
        public string? ChatId { get; set; }
        public ChannelIdentity? ChannelIdentity { get; set; }
        public string? WebUrl { get; set; }
        public EventMessageDetail? EventDetail { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chats-getallmessages?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatsGetallmessagesResponse> ChatsGetallmessagesAsync()
        {
            var p = new ChatsGetallmessagesParameter();
            return await this.SendAsync<ChatsGetallmessagesParameter, ChatsGetallmessagesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chats-getallmessages?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatsGetallmessagesResponse> ChatsGetallmessagesAsync(CancellationToken cancellationToken)
        {
            var p = new ChatsGetallmessagesParameter();
            return await this.SendAsync<ChatsGetallmessagesParameter, ChatsGetallmessagesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chats-getallmessages?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatsGetallmessagesResponse> ChatsGetallmessagesAsync(ChatsGetallmessagesParameter parameter)
        {
            return await this.SendAsync<ChatsGetallmessagesParameter, ChatsGetallmessagesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chats-getallmessages?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatsGetallmessagesResponse> ChatsGetallmessagesAsync(ChatsGetallmessagesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatsGetallmessagesParameter, ChatsGetallmessagesResponse>(parameter, cancellationToken);
        }
    }
}
