using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/chatmessage?view=graph-rest-1.0
    /// </summary>
    public partial class ChatMessage
    {
        public string Id { get; set; }
        public String? ReplyToId { get; set; }
        public ChatMessageFromIdentitySet? From { get; set; }
        public String? Etag { get; set; }
        public ChatMessageChatMessageType MessageType { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public DateTimeOffset LastModifiedDateTime { get; set; }
        public DateTimeOffset LastEditedDateTime { get; set; }
        public DateTimeOffset DeletedDateTime { get; set; }
        public String? Subject { get; set; }
        public ItemBody? Body { get; set; }
        public String? Summary { get; set; }
        public ChatMessageAttachment[] Attachments { get; set; }
        public ChatMessageMention[] Mentions { get; set; }
        public ChatMessageString Importance { get; set; }
        public ChatMessageReaction[] Reactions { get; set; }
        public String? Locale { get; set; }
        public ChatMessagePolicyViolation? PolicyViolation { get; set; }
        public String? ChatId { get; set; }
        public ChannelIdentity? ChannelIdentity { get; set; }
        public String? WebUrl { get; set; }
        public EventMessageDetail? EventDetail { get; set; }
    }
}
