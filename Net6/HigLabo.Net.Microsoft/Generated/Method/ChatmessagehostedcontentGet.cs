using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chatmessagehostedcontent-get?view=graph-rest-1.0
    /// </summary>
    public partial class ChatmessagehostedContentGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? TeamId { get; set; }
            public string? ChannelId { get; set; }
            public string? MessageId { get; set; }
            public string? HostedContentId { get; set; }
            public string? ReplyId { get; set; }
            public string? ChatId { get; set; }
            public string? UserIdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_TeamId_Channels_ChannelId_Messages_MessageId_HostedContents_HostedContentId: return $"/teams/{TeamId}/channels/{ChannelId}/messages/{MessageId}/hostedContents/{HostedContentId}";
                    case ApiPath.Teams_TeamId_Channels_ChannelId_Messages_MessageId_Replies_ReplyId_HostedContents_HostedContentId: return $"/teams/{TeamId}/channels/{ChannelId}/messages/{MessageId}/replies/{ReplyId}/hostedContents/{HostedContentId}";
                    case ApiPath.Chats_ChatId_Messages_MessageId_HostedContents_HostedContentId: return $"/chats/{ChatId}/messages/{MessageId}/hostedContents/{HostedContentId}";
                    case ApiPath.Users_UserIdOrUserPrincipalName_Chats_ChatId_Messages_MessageId_HostedContents_HostedContentId: return $"/users/{UserIdOrUserPrincipalName}/chats/{ChatId}/messages/{MessageId}/hostedContents/{HostedContentId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

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
    public partial class ChatmessagehostedContentGetResponse : RestApiResponse
    {
        public string? ContentBytes { get; set; }
        public string? ContentType { get; set; }
        public string? Id { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chatmessagehostedcontent-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chatmessagehostedcontent-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatmessagehostedContentGetResponse> ChatmessagehostedContentGetAsync()
        {
            var p = new ChatmessagehostedContentGetParameter();
            return await this.SendAsync<ChatmessagehostedContentGetParameter, ChatmessagehostedContentGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chatmessagehostedcontent-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatmessagehostedContentGetResponse> ChatmessagehostedContentGetAsync(CancellationToken cancellationToken)
        {
            var p = new ChatmessagehostedContentGetParameter();
            return await this.SendAsync<ChatmessagehostedContentGetParameter, ChatmessagehostedContentGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chatmessagehostedcontent-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatmessagehostedContentGetResponse> ChatmessagehostedContentGetAsync(ChatmessagehostedContentGetParameter parameter)
        {
            return await this.SendAsync<ChatmessagehostedContentGetParameter, ChatmessagehostedContentGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chatmessagehostedcontent-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatmessagehostedContentGetResponse> ChatmessagehostedContentGetAsync(ChatmessagehostedContentGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatmessagehostedContentGetParameter, ChatmessagehostedContentGetResponse>(parameter, cancellationToken);
        }
    }
}
