using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChannelPostMessagesParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string TeamId { get; set; }
        public string ChannelId { get; set; }
    }
    public partial class ChannelPostMessagesResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/channel-post-messages?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelPostMessagesResponse> ChannelPostMessagesAsync()
        {
            var p = new ChannelPostMessagesParameter();
            return await this.SendAsync<ChannelPostMessagesParameter, ChannelPostMessagesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-post-messages?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelPostMessagesResponse> ChannelPostMessagesAsync(CancellationToken cancellationToken)
        {
            var p = new ChannelPostMessagesParameter();
            return await this.SendAsync<ChannelPostMessagesParameter, ChannelPostMessagesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-post-messages?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelPostMessagesResponse> ChannelPostMessagesAsync(ChannelPostMessagesParameter parameter)
        {
            return await this.SendAsync<ChannelPostMessagesParameter, ChannelPostMessagesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-post-messages?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelPostMessagesResponse> ChannelPostMessagesAsync(ChannelPostMessagesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChannelPostMessagesParameter, ChannelPostMessagesResponse>(parameter, cancellationToken);
        }
    }
}
