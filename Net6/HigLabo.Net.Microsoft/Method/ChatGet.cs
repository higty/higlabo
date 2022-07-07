using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChatGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
            ChatType,
            CreatedDateTime,
            Id,
            LastUpdatedDateTime,
            OnlineMeetingInfo,
            TenantId,
            Topic,
            WebUrl,
        }
        public enum ApiPath
        {
            Me_Chats_ChatId,
            Users_UserIdOrUserPrincipalName_Chats_ChatId,
            Chats_ChatId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Chats_ChatId: return $"/me/chats/{ChatId}";
                    case ApiPath.Users_UserIdOrUserPrincipalName_Chats_ChatId: return $"/users/{UserIdOrUserPrincipalName}/chats/{ChatId}";
                    case ApiPath.Chats_ChatId: return $"/chats/{ChatId}";
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
        public string ChatId { get; set; }
        public string UserIdOrUserPrincipalName { get; set; }
    }
    public partial class ChatGetResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/chat?view=graph-rest-1.0
        /// </summary>
        public partial class Chat
        {
            public enum ChatChatType
            {
                Group,
                OneOnOne,
                Meeting,
                UnknownFutureValue,
            }

            public Chat? ChatType { get; set; }
            public DateTimeOffset? CreatedDateTime { get; set; }
            public string? Id { get; set; }
            public DateTimeOffset? LastUpdatedDateTime { get; set; }
            public TeamworkOnlineMeetingInfo? OnlineMeetingInfo { get; set; }
            public string? TenantId { get; set; }
            public string? Topic { get; set; }
            public string? WebUrl { get; set; }
        }

        public enum ChatChatType
        {
            Group,
            OneOnOne,
            Meeting,
            UnknownFutureValue,
        }

        public Chat? ChatType { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? LastUpdatedDateTime { get; set; }
        public TeamworkOnlineMeetingInfo? OnlineMeetingInfo { get; set; }
        public string? TenantId { get; set; }
        public string? Topic { get; set; }
        public string? WebUrl { get; set; }
        public Chat[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatGetResponse> ChatGetAsync()
        {
            var p = new ChatGetParameter();
            return await this.SendAsync<ChatGetParameter, ChatGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatGetResponse> ChatGetAsync(CancellationToken cancellationToken)
        {
            var p = new ChatGetParameter();
            return await this.SendAsync<ChatGetParameter, ChatGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatGetResponse> ChatGetAsync(ChatGetParameter parameter)
        {
            return await this.SendAsync<ChatGetParameter, ChatGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatGetResponse> ChatGetAsync(ChatGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatGetParameter, ChatGetResponse>(parameter, cancellationToken);
        }
    }
}
