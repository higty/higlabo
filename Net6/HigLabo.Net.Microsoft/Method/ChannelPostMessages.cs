using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChannelPostMessagesParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? TeamId { get; set; }
            public string? ChannelId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_TeamId_Channels_ChannelId_Messages: return $"/teams/{TeamId}/channels/{ChannelId}/messages";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

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
        public enum ApiPath
        {
            Teams_TeamId_Channels_ChannelId_Messages,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
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
        public ChatMessageReAction[]? Reactions { get; set; }
        public string? Locale { get; set; }
        public ChatMessagePolicyViolation? PolicyViolation { get; set; }
        public string? ChatId { get; set; }
        public ChannelIdentity? ChannelIdentity { get; set; }
        public string? WebUrl { get; set; }
        public EventMessageDetail? EventDetail { get; set; }
        public ChatMessage? Replies { get; set; }
        public ChatMessageHostedContent? HostedContents { get; set; }
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
        public ChatMessageReAction[]? Reactions { get; set; }
        public string? Locale { get; set; }
        public ChatMessagePolicyViolation? PolicyViolation { get; set; }
        public string? ChatId { get; set; }
        public ChannelIdentity? ChannelIdentity { get; set; }
        public string? WebUrl { get; set; }
        public EventMessageDetail? EventDetail { get; set; }
        public ChatMessage? Replies { get; set; }
        public ChatMessageHostedContent? HostedContents { get; set; }
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
