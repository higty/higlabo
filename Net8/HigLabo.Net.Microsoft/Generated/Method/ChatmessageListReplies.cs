using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chatmessage-list-replies?view=graph-rest-1.0
    /// </summary>
    public partial class ChatmessageListRepliesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? TeamId { get; set; }
            public string? ChannelId { get; set; }
            public string? MessageId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_TeamId_Channels_ChannelId_Messages_MessageId_Replies: return $"/teams/{TeamId}/channels/{ChannelId}/messages/{MessageId}/replies";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Attachments,
            Body,
            ChatId,
            ChannelIdentity,
            CreatedDateTime,
            DeletedDateTime,
            Etag,
            EventDetail,
            From,
            Id,
            Importance,
            LastModifiedDateTime,
            LastEditedDateTime,
            Locale,
            Mentions,
            MessageHistory,
            MessageType,
            PolicyViolation,
            Reactions,
            ReplyToId,
            Subject,
            Summary,
            WebUrl,
            HostedContents,
            Replies,
        }
        public enum ApiPath
        {
            Teams_TeamId_Channels_ChannelId_Messages_MessageId_Replies,
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
    public partial class ChatmessageListRepliesResponse : RestApiResponse
    {
        public ChatMessage[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chatmessage-list-replies?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chatmessage-list-replies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChatmessageListRepliesResponse> ChatmessageListRepliesAsync()
        {
            var p = new ChatmessageListRepliesParameter();
            return await this.SendAsync<ChatmessageListRepliesParameter, ChatmessageListRepliesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chatmessage-list-replies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChatmessageListRepliesResponse> ChatmessageListRepliesAsync(CancellationToken cancellationToken)
        {
            var p = new ChatmessageListRepliesParameter();
            return await this.SendAsync<ChatmessageListRepliesParameter, ChatmessageListRepliesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chatmessage-list-replies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChatmessageListRepliesResponse> ChatmessageListRepliesAsync(ChatmessageListRepliesParameter parameter)
        {
            return await this.SendAsync<ChatmessageListRepliesParameter, ChatmessageListRepliesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chatmessage-list-replies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChatmessageListRepliesResponse> ChatmessageListRepliesAsync(ChatmessageListRepliesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatmessageListRepliesParameter, ChatmessageListRepliesResponse>(parameter, cancellationToken);
        }
    }
}
