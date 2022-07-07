using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChatGetTabsParameter : IRestApiParameter, IQueryParameterProperty
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
            Chats_ChatId_Tabs_TabId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Chats_ChatId_Tabs_TabId: return $"/chats/{ChatId}/tabs/{TabId}";
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
        public string TabId { get; set; }
    }
    public partial class ChatGetTabsResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? WebUrl { get; set; }
        public TeamsTabConfiguration? Configuration { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-get-tabs?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatGetTabsResponse> ChatGetTabsAsync()
        {
            var p = new ChatGetTabsParameter();
            return await this.SendAsync<ChatGetTabsParameter, ChatGetTabsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-get-tabs?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatGetTabsResponse> ChatGetTabsAsync(CancellationToken cancellationToken)
        {
            var p = new ChatGetTabsParameter();
            return await this.SendAsync<ChatGetTabsParameter, ChatGetTabsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-get-tabs?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatGetTabsResponse> ChatGetTabsAsync(ChatGetTabsParameter parameter)
        {
            return await this.SendAsync<ChatGetTabsParameter, ChatGetTabsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-get-tabs?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatGetTabsResponse> ChatGetTabsAsync(ChatGetTabsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatGetTabsParameter, ChatGetTabsResponse>(parameter, cancellationToken);
        }
    }
}
