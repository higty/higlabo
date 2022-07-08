using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChatmessageListRepliesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string TeamId { get; set; }
            public string ChannelId { get; set; }
            public string MessageId { get; set; }

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
            Id,
            ReplyToId,
            From,
            Etag,
            MessageType,
            CreatedDateTime,
            LastModifiedDateTime,
            LastEditedDateTime,
            DeletedDateTime,
            Subject,
            Body,
            Summary,
            Attachments,
            Mentions,
            Importance,
            Reactions,
            Locale,
            PolicyViolation,
            ChatId,
            ChannelIdentity,
            WebUrl,
            EventDetail,
            Replies,
            HostedContents,
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
        public ChatMessage[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chatmessage-list-replies?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatmessageListRepliesResponse> ChatmessageListRepliesAsync()
        {
            var p = new ChatmessageListRepliesParameter();
            return await this.SendAsync<ChatmessageListRepliesParameter, ChatmessageListRepliesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chatmessage-list-replies?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatmessageListRepliesResponse> ChatmessageListRepliesAsync(CancellationToken cancellationToken)
        {
            var p = new ChatmessageListRepliesParameter();
            return await this.SendAsync<ChatmessageListRepliesParameter, ChatmessageListRepliesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chatmessage-list-replies?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatmessageListRepliesResponse> ChatmessageListRepliesAsync(ChatmessageListRepliesParameter parameter)
        {
            return await this.SendAsync<ChatmessageListRepliesParameter, ChatmessageListRepliesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chatmessage-list-replies?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatmessageListRepliesResponse> ChatmessageListRepliesAsync(ChatmessageListRepliesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatmessageListRepliesParameter, ChatmessageListRepliesResponse>(parameter, cancellationToken);
        }
    }
}
