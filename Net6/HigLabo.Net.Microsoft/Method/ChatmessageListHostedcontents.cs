using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChatmessageListHostedContentsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? TeamId { get; set; }
            public string? ChannelId { get; set; }
            public string? MessageId { get; set; }
            public string? ReplyId { get; set; }
            public string? ChatId { get; set; }
            public string? UserIdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_TeamId_Channels_ChannelId_Messages_MessageId_HostedContents: return $"/teams/{TeamId}/channels/{ChannelId}/messages/{MessageId}/hostedContents";
                    case ApiPath.Teams_TeamId_Channels_ChannelId_Messages_MessageId_Replies_ReplyId_HostedContents: return $"/teams/{TeamId}/channels/{ChannelId}/messages/{MessageId}/replies/{ReplyId}/hostedContents";
                    case ApiPath.Chats_ChatId_Messages_MessageId_HostedContents: return $"/chats/{ChatId}/messages/{MessageId}/hostedContents";
                    case ApiPath.Users_UserIdOrUserPrincipalName_Chats_ChatId_Messages_MessageId_HostedContents: return $"/users/{UserIdOrUserPrincipalName}/chats/{ChatId}/messages/{MessageId}/hostedContents";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Teams_TeamId_Channels_ChannelId_Messages_MessageId_HostedContents,
            Teams_TeamId_Channels_ChannelId_Messages_MessageId_Replies_ReplyId_HostedContents,
            Chats_ChatId_Messages_MessageId_HostedContents,
            Users_UserIdOrUserPrincipalName_Chats_ChatId_Messages_MessageId_HostedContents,
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
    public partial class ChatmessageListHostedContentsResponse : RestApiResponse
    {
        public ChatMessageHostedContent[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chatmessage-list-hostedcontents?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatmessageListHostedContentsResponse> ChatmessageListHostedContentsAsync()
        {
            var p = new ChatmessageListHostedContentsParameter();
            return await this.SendAsync<ChatmessageListHostedContentsParameter, ChatmessageListHostedContentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chatmessage-list-hostedcontents?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatmessageListHostedContentsResponse> ChatmessageListHostedContentsAsync(CancellationToken cancellationToken)
        {
            var p = new ChatmessageListHostedContentsParameter();
            return await this.SendAsync<ChatmessageListHostedContentsParameter, ChatmessageListHostedContentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chatmessage-list-hostedcontents?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatmessageListHostedContentsResponse> ChatmessageListHostedContentsAsync(ChatmessageListHostedContentsParameter parameter)
        {
            return await this.SendAsync<ChatmessageListHostedContentsParameter, ChatmessageListHostedContentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chatmessage-list-hostedcontents?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatmessageListHostedContentsResponse> ChatmessageListHostedContentsAsync(ChatmessageListHostedContentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatmessageListHostedContentsParameter, ChatmessageListHostedContentsResponse>(parameter, cancellationToken);
        }
    }
}
