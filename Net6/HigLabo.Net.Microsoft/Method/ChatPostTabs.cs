using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChatPostTabsParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string ChatId { get; set; }
    }
    public partial class ChatPostTabsResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? WebUrl { get; set; }
        public TeamsTabConfiguration? Configuration { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-post-tabs?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatPostTabsResponse> ChatPostTabsAsync()
        {
            var p = new ChatPostTabsParameter();
            return await this.SendAsync<ChatPostTabsParameter, ChatPostTabsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-post-tabs?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatPostTabsResponse> ChatPostTabsAsync(CancellationToken cancellationToken)
        {
            var p = new ChatPostTabsParameter();
            return await this.SendAsync<ChatPostTabsParameter, ChatPostTabsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-post-tabs?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatPostTabsResponse> ChatPostTabsAsync(ChatPostTabsParameter parameter)
        {
            return await this.SendAsync<ChatPostTabsParameter, ChatPostTabsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-post-tabs?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatPostTabsResponse> ChatPostTabsAsync(ChatPostTabsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatPostTabsParameter, ChatPostTabsResponse>(parameter, cancellationToken);
        }
    }
}
