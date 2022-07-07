using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChatListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Chats,
            Users_UserIdOrUserPrincipalName_Chats,
            Chats,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Chats: return $"/me/chats";
                    case ApiPath.Users_UserIdOrUserPrincipalName_Chats: return $"/users/{UserIdOrUserPrincipalName}/chats";
                    case ApiPath.Chats: return $"/chats";
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
        public string UserIdOrUserPrincipalName { get; set; }
    }
    public partial class ChatListResponse : RestApiResponse
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

        public Chat[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatListResponse> ChatListAsync()
        {
            var p = new ChatListParameter();
            return await this.SendAsync<ChatListParameter, ChatListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatListResponse> ChatListAsync(CancellationToken cancellationToken)
        {
            var p = new ChatListParameter();
            return await this.SendAsync<ChatListParameter, ChatListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatListResponse> ChatListAsync(ChatListParameter parameter)
        {
            return await this.SendAsync<ChatListParameter, ChatListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatListResponse> ChatListAsync(ChatListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatListParameter, ChatListResponse>(parameter, cancellationToken);
        }
    }
}
