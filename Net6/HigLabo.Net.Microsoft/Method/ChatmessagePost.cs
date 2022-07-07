using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChatmessagePostParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Teams_TeamId_Channels_ChannelId_Messages,
            Teams_TeamId_Channels_ChannelId_Messages_MessageId_Replies,
            Chats_ChatId_Messages,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Teams_TeamId_Channels_ChannelId_Messages: return $"/teams/{TeamId}/channels/{ChannelId}/messages";
                    case ApiPath.Teams_TeamId_Channels_ChannelId_Messages_MessageId_Replies: return $"/teams/{TeamId}/channels/{ChannelId}/messages/{MessageId}/replies";
                    case ApiPath.Chats_ChatId_Messages: return $"/chats/{ChatId}/messages";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string TeamId { get; set; }
        public string ChannelId { get; set; }
        public string MessageId { get; set; }
        public string ChatId { get; set; }
    }
    public partial class ChatmessagePostResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/chatmessage-post?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatmessagePostResponse> ChatmessagePostAsync()
        {
            var p = new ChatmessagePostParameter();
            return await this.SendAsync<ChatmessagePostParameter, ChatmessagePostResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chatmessage-post?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatmessagePostResponse> ChatmessagePostAsync(CancellationToken cancellationToken)
        {
            var p = new ChatmessagePostParameter();
            return await this.SendAsync<ChatmessagePostParameter, ChatmessagePostResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chatmessage-post?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatmessagePostResponse> ChatmessagePostAsync(ChatmessagePostParameter parameter)
        {
            return await this.SendAsync<ChatmessagePostParameter, ChatmessagePostResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chatmessage-post?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatmessagePostResponse> ChatmessagePostAsync(ChatmessagePostParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatmessagePostParameter, ChatmessagePostResponse>(parameter, cancellationToken);
        }
    }
}
