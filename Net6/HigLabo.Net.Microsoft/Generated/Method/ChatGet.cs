using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chat-get?view=graph-rest-1.0
    /// </summary>
    public partial class ChatGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ChatId { get; set; }
            public string? UserIdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Chats_ChatId: return $"/me/chats/{ChatId}";
                    case ApiPath.Users_UserIdOrUserPrincipalName_Chats_ChatId: return $"/users/{UserIdOrUserPrincipalName}/chats/{ChatId}";
                    case ApiPath.Chats_ChatId: return $"/chats/{ChatId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            ChatType,
            CreatedDateTime,
            Id,
            LastUpdatedDateTime,
            OnlineMeetingInfo,
            TenantId,
            Topic,
            Viewpoint,
            WebUrl,
            InstalledApps,
            LastMessagePreview,
            Members,
            Messages,
            PinnedMessages,
            Tabs,
        }
        public enum ApiPath
        {
            Me_Chats_ChatId,
            Users_UserIdOrUserPrincipalName_Chats_ChatId,
            Chats_ChatId,
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
    public partial class ChatGetResponse : RestApiResponse
    {
        public enum ChatChatType
        {
            Group,
            OneOnOne,
            Meeting,
            UnknownFutureValue,
        }

        public Chat[]? Value { get; set; }
        public ChatChatType ChatType { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? LastUpdatedDateTime { get; set; }
        public TeamworkOnlineMeetingInfo? OnlineMeetingInfo { get; set; }
        public string? TenantId { get; set; }
        public string? Topic { get; set; }
        public ChatViewpoint? Viewpoint { get; set; }
        public string? WebUrl { get; set; }
        public TeamsAppInstallation[]? InstalledApps { get; set; }
        public ChatMessageInfo? LastMessagePreview { get; set; }
        public ConversationMember[]? Members { get; set; }
        public ChatMessage[]? Messages { get; set; }
        public PinnedChatMessageInfo[]? PinnedMessages { get; set; }
        public TeamsTab[]? Tabs { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chat-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatGetResponse> ChatGetAsync()
        {
            var p = new ChatGetParameter();
            return await this.SendAsync<ChatGetParameter, ChatGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatGetResponse> ChatGetAsync(CancellationToken cancellationToken)
        {
            var p = new ChatGetParameter();
            return await this.SendAsync<ChatGetParameter, ChatGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatGetResponse> ChatGetAsync(ChatGetParameter parameter)
        {
            return await this.SendAsync<ChatGetParameter, ChatGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatGetResponse> ChatGetAsync(ChatGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatGetParameter, ChatGetResponse>(parameter, cancellationToken);
        }
    }
}
