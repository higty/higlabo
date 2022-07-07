using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChannelListMessagesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Teams_TeamId_Channels_ChannelId_Messages,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Teams_TeamId_Channels_ChannelId_Messages: return $"/teams/{TeamId}/channels/{ChannelId}/messages";
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
    public partial class ChannelListMessagesResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/channel-list-messages?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelListMessagesResponse> ChannelListMessagesAsync()
        {
            var p = new ChannelListMessagesParameter();
            return await this.SendAsync<ChannelListMessagesParameter, ChannelListMessagesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-list-messages?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelListMessagesResponse> ChannelListMessagesAsync(CancellationToken cancellationToken)
        {
            var p = new ChannelListMessagesParameter();
            return await this.SendAsync<ChannelListMessagesParameter, ChannelListMessagesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-list-messages?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelListMessagesResponse> ChannelListMessagesAsync(ChannelListMessagesParameter parameter)
        {
            return await this.SendAsync<ChannelListMessagesParameter, ChannelListMessagesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-list-messages?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelListMessagesResponse> ChannelListMessagesAsync(ChannelListMessagesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChannelListMessagesParameter, ChannelListMessagesResponse>(parameter, cancellationToken);
        }
    }
}
