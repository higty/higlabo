using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChatmessageDeltaParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Teams_TeamId_Channels_ChannelId_Messages_Delta,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Teams_TeamId_Channels_ChannelId_Messages_Delta: return $"/teams/{TeamId}/channels/{ChannelId}/messages/delta";
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
        public string TeamId { get; set; }
        public string ChannelId { get; set; }
    }
    public partial class ChatmessageDeltaResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/chatmessage?view=graph-rest-1.0
        /// </summary>
        public partial class ChatMessage
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

        public ChatMessage[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chatmessage-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatmessageDeltaResponse> ChatmessageDeltaAsync()
        {
            var p = new ChatmessageDeltaParameter();
            return await this.SendAsync<ChatmessageDeltaParameter, ChatmessageDeltaResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chatmessage-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatmessageDeltaResponse> ChatmessageDeltaAsync(CancellationToken cancellationToken)
        {
            var p = new ChatmessageDeltaParameter();
            return await this.SendAsync<ChatmessageDeltaParameter, ChatmessageDeltaResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chatmessage-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatmessageDeltaResponse> ChatmessageDeltaAsync(ChatmessageDeltaParameter parameter)
        {
            return await this.SendAsync<ChatmessageDeltaParameter, ChatmessageDeltaResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chatmessage-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatmessageDeltaResponse> ChatmessageDeltaAsync(ChatmessageDeltaParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatmessageDeltaParameter, ChatmessageDeltaResponse>(parameter, cancellationToken);
        }
    }
}
