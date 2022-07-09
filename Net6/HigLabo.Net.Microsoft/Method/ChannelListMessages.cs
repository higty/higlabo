using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
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
