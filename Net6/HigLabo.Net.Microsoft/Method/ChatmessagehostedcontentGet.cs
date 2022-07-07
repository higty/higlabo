using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChatmessagehostedcontentGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Teams_TeamId_Channels_ChannelId_Messages_MessageId_HostedContents_HostedContentId,
            Teams_TeamId_Channels_ChannelId_Messages_MessageId_Replies_ReplyId_HostedContents_HostedContentId,
            Chats_ChatId_Messages_MessageId_HostedContents_HostedContentId,
            Users_UserIdOrUserPrincipalName_Chats_ChatId_Messages_MessageId_HostedContents_HostedContentId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Teams_TeamId_Channels_ChannelId_Messages_MessageId_HostedContents_HostedContentId: return $"/teams/{TeamId}/channels/{ChannelId}/messages/{MessageId}/hostedContents/{HostedContentId}";
                    case ApiPath.Teams_TeamId_Channels_ChannelId_Messages_MessageId_Replies_ReplyId_HostedContents_HostedContentId: return $"/teams/{TeamId}/channels/{ChannelId}/messages/{MessageId}/replies/{ReplyId}/hostedContents/{HostedContentId}";
                    case ApiPath.Chats_ChatId_Messages_MessageId_HostedContents_HostedContentId: return $"/chats/{ChatId}/messages/{MessageId}/hostedContents/{HostedContentId}";
                    case ApiPath.Users_UserIdOrUserPrincipalName_Chats_ChatId_Messages_MessageId_HostedContents_HostedContentId: return $"/users/{UserIdOrUserPrincipalName}/chats/{ChatId}/messages/{MessageId}/hostedContents/{HostedContentId}";
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
        public string HostedContentId { get; set; }
        public string ReplyId { get; set; }
        public string ChatId { get; set; }
        public string UserIdOrUserPrincipalName { get; set; }
    }
    public partial class ChatmessagehostedcontentGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? ContentBytes { get; set; }
        public string? ContentType { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chatmessagehostedcontent-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatmessagehostedcontentGetResponse> ChatmessagehostedcontentGetAsync()
        {
            var p = new ChatmessagehostedcontentGetParameter();
            return await this.SendAsync<ChatmessagehostedcontentGetParameter, ChatmessagehostedcontentGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chatmessagehostedcontent-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatmessagehostedcontentGetResponse> ChatmessagehostedcontentGetAsync(CancellationToken cancellationToken)
        {
            var p = new ChatmessagehostedcontentGetParameter();
            return await this.SendAsync<ChatmessagehostedcontentGetParameter, ChatmessagehostedcontentGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chatmessagehostedcontent-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatmessagehostedcontentGetResponse> ChatmessagehostedcontentGetAsync(ChatmessagehostedcontentGetParameter parameter)
        {
            return await this.SendAsync<ChatmessagehostedcontentGetParameter, ChatmessagehostedcontentGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chatmessagehostedcontent-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatmessagehostedcontentGetResponse> ChatmessagehostedcontentGetAsync(ChatmessagehostedcontentGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatmessagehostedcontentGetParameter, ChatmessagehostedcontentGetResponse>(parameter, cancellationToken);
        }
    }
}
