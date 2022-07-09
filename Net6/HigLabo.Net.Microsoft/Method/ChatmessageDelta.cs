using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChatmessageDeltaParameter : IRestApiParameter, IQueryParameterProperty
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
                    case ApiPath.Teams_TeamId_Channels_ChannelId_Messages_Delta: return $"/teams/{TeamId}/channels/{ChannelId}/messages/delta";
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
            Teams_TeamId_Channels_ChannelId_Messages_Delta,
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
    public partial class ChatmessageDeltaResponse : RestApiResponse
    {
        public ChatMessage[]? Value { get; set; }
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
