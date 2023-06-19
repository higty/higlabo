using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chat-patch-tabs?view=graph-rest-1.0
    /// </summary>
    public partial class ChatPatchTabsParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
    }
    public partial class ChatPatchTabsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chat-patch-tabs?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-patch-tabs?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChatPatchTabsResponse> ChatPatchTabsAsync()
        {
            var p = new ChatPatchTabsParameter();
            return await this.SendAsync<ChatPatchTabsParameter, ChatPatchTabsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-patch-tabs?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChatPatchTabsResponse> ChatPatchTabsAsync(CancellationToken cancellationToken)
        {
            var p = new ChatPatchTabsParameter();
            return await this.SendAsync<ChatPatchTabsParameter, ChatPatchTabsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-patch-tabs?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChatPatchTabsResponse> ChatPatchTabsAsync(ChatPatchTabsParameter parameter)
        {
            return await this.SendAsync<ChatPatchTabsParameter, ChatPatchTabsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-patch-tabs?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChatPatchTabsResponse> ChatPatchTabsAsync(ChatPatchTabsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatPatchTabsParameter, ChatPatchTabsResponse>(parameter, cancellationToken);
        }
    }
}
