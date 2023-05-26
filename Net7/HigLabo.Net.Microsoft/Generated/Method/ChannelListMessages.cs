using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/channel-list-messages?view=graph-rest-1.0
    /// </summary>
    public partial class ChannelListMessagesParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class ChannelListMessagesResponse : RestApiResponse
    {
        public ChatMessage[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/channel-list-messages?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/channel-list-messages?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelListMessagesResponse> ChannelListMessagesAsync()
        {
            var p = new ChannelListMessagesParameter();
            return await this.SendAsync<ChannelListMessagesParameter, ChannelListMessagesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/channel-list-messages?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelListMessagesResponse> ChannelListMessagesAsync(CancellationToken cancellationToken)
        {
            var p = new ChannelListMessagesParameter();
            return await this.SendAsync<ChannelListMessagesParameter, ChannelListMessagesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/channel-list-messages?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelListMessagesResponse> ChannelListMessagesAsync(ChannelListMessagesParameter parameter)
        {
            return await this.SendAsync<ChannelListMessagesParameter, ChannelListMessagesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/channel-list-messages?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelListMessagesResponse> ChannelListMessagesAsync(ChannelListMessagesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChannelListMessagesParameter, ChannelListMessagesResponse>(parameter, cancellationToken);
        }
    }
}
