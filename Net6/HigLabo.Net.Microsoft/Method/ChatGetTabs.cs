using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chat-get-tabs?view=graph-rest-1.0
    /// </summary>
    public partial class ChatGetTabsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ChatId { get; set; }
            public string? TabId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Chats_ChatId_Tabs_TabId: return $"/chats/{ChatId}/tabs/{TabId}";
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
            Chats_ChatId_Tabs_TabId,
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
    public partial class ChatGetTabsResponse : RestApiResponse
    {
        public TeamsTabConfiguration? Configuration { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public string? WebUrl { get; set; }
        public TeamsApp? TeamsApp { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chat-get-tabs?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-get-tabs?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatGetTabsResponse> ChatGetTabsAsync()
        {
            var p = new ChatGetTabsParameter();
            return await this.SendAsync<ChatGetTabsParameter, ChatGetTabsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-get-tabs?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatGetTabsResponse> ChatGetTabsAsync(CancellationToken cancellationToken)
        {
            var p = new ChatGetTabsParameter();
            return await this.SendAsync<ChatGetTabsParameter, ChatGetTabsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-get-tabs?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatGetTabsResponse> ChatGetTabsAsync(ChatGetTabsParameter parameter)
        {
            return await this.SendAsync<ChatGetTabsParameter, ChatGetTabsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-get-tabs?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatGetTabsResponse> ChatGetTabsAsync(ChatGetTabsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatGetTabsParameter, ChatGetTabsResponse>(parameter, cancellationToken);
        }
    }
}
