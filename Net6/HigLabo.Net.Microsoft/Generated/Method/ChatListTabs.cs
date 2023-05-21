using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chat-list-tabs?view=graph-rest-1.0
    /// </summary>
    public partial class ChatListTabsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ChatId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Chats_ChatId_Tabs: return $"/chats/{ChatId}/tabs";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Configuration,
            DisplayName,
            Id,
            WebUrl,
            TeamsApp,
        }
        public enum ApiPath
        {
            Chats_ChatId_Tabs,
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
    public partial class ChatListTabsResponse : RestApiResponse
    {
        public TeamsTab[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chat-list-tabs?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-list-tabs?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatListTabsResponse> ChatListTabsAsync()
        {
            var p = new ChatListTabsParameter();
            return await this.SendAsync<ChatListTabsParameter, ChatListTabsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-list-tabs?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatListTabsResponse> ChatListTabsAsync(CancellationToken cancellationToken)
        {
            var p = new ChatListTabsParameter();
            return await this.SendAsync<ChatListTabsParameter, ChatListTabsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-list-tabs?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatListTabsResponse> ChatListTabsAsync(ChatListTabsParameter parameter)
        {
            return await this.SendAsync<ChatListTabsParameter, ChatListTabsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-list-tabs?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatListTabsResponse> ChatListTabsAsync(ChatListTabsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatListTabsParameter, ChatListTabsResponse>(parameter, cancellationToken);
        }
    }
}
