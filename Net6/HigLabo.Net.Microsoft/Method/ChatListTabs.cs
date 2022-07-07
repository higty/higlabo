using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChatListTabsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Chats_ChatId_Tabs,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Chats_ChatId_Tabs: return $"/chats/{ChatId}/tabs";
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
    }
    public partial class ChatListTabsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/teamstab?view=graph-rest-1.0
        /// </summary>
        public partial class TeamsTab
        {
            public string? Id { get; set; }
            public string? DisplayName { get; set; }
            public string? WebUrl { get; set; }
            public TeamsTabConfiguration? Configuration { get; set; }
        }

        public TeamsTab[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-list-tabs?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatListTabsResponse> ChatListTabsAsync()
        {
            var p = new ChatListTabsParameter();
            return await this.SendAsync<ChatListTabsParameter, ChatListTabsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-list-tabs?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatListTabsResponse> ChatListTabsAsync(CancellationToken cancellationToken)
        {
            var p = new ChatListTabsParameter();
            return await this.SendAsync<ChatListTabsParameter, ChatListTabsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-list-tabs?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatListTabsResponse> ChatListTabsAsync(ChatListTabsParameter parameter)
        {
            return await this.SendAsync<ChatListTabsParameter, ChatListTabsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-list-tabs?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatListTabsResponse> ChatListTabsAsync(ChatListTabsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatListTabsParameter, ChatListTabsResponse>(parameter, cancellationToken);
        }
    }
}
