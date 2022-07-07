using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChatmessageListHostedcontentsParameter : IRestApiParameter, IQueryParameterProperty
    {
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

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Teams_TeamId_Channels_ChannelId_Messages_MessageId_HostedContents: return $"/teams/{TeamId}/channels/{ChannelId}/messages/{MessageId}/hostedContents";
                    case ApiPath.Teams_TeamId_Channels_ChannelId_Messages_MessageId_Replies_ReplyId_HostedContents: return $"/teams/{TeamId}/channels/{ChannelId}/messages/{MessageId}/replies/{ReplyId}/hostedContents";
                    case ApiPath.Chats_ChatId_Messages_MessageId_HostedContents: return $"/chats/{ChatId}/messages/{MessageId}/hostedContents";
                    case ApiPath.Users_UserIdOrUserPrincipalName_Chats_ChatId_Messages_MessageId_HostedContents: return $"/users/{UserIdOrUserPrincipalName}/chats/{ChatId}/messages/{MessageId}/hostedContents";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
        public string TeamId { get; set; }
        public string ChannelId { get; set; }
        public string MessageId { get; set; }
        public string ReplyId { get; set; }
        public string ChatId { get; set; }
        public string UserIdOrUserPrincipalName { get; set; }
    }
    public partial class ChatmessageListHostedcontentsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/chatmessagehostedcontent?view=graph-rest-1.0
        /// </summary>
        public partial class ChatMessageHostedContent
        {
            public string? Id { get; set; }
            public string? ContentBytes { get; set; }
            public string? ContentType { get; set; }
        }

        public ChatMessageHostedContent[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chatmessage-list-hostedcontents?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatmessageListHostedcontentsResponse> ChatmessageListHostedcontentsAsync()
        {
            var p = new ChatmessageListHostedcontentsParameter();
            return await this.SendAsync<ChatmessageListHostedcontentsParameter, ChatmessageListHostedcontentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chatmessage-list-hostedcontents?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatmessageListHostedcontentsResponse> ChatmessageListHostedcontentsAsync(CancellationToken cancellationToken)
        {
            var p = new ChatmessageListHostedcontentsParameter();
            return await this.SendAsync<ChatmessageListHostedcontentsParameter, ChatmessageListHostedcontentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chatmessage-list-hostedcontents?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatmessageListHostedcontentsResponse> ChatmessageListHostedcontentsAsync(ChatmessageListHostedcontentsParameter parameter)
        {
            return await this.SendAsync<ChatmessageListHostedcontentsParameter, ChatmessageListHostedcontentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chatmessage-list-hostedcontents?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatmessageListHostedcontentsResponse> ChatmessageListHostedcontentsAsync(ChatmessageListHostedcontentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatmessageListHostedcontentsParameter, ChatmessageListHostedcontentsResponse>(parameter, cancellationToken);
        }
    }
}
