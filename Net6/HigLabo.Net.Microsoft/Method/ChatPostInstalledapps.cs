using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChatPostInstalledappsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Chats_ChatId_InstalledApps,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Chats_ChatId_InstalledApps: return $"/chats/{ChatId}/installedApps";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string ChatId { get; set; }
    }
    public partial class ChatPostInstalledappsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-post-installedapps?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatPostInstalledappsResponse> ChatPostInstalledappsAsync()
        {
            var p = new ChatPostInstalledappsParameter();
            return await this.SendAsync<ChatPostInstalledappsParameter, ChatPostInstalledappsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-post-installedapps?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatPostInstalledappsResponse> ChatPostInstalledappsAsync(CancellationToken cancellationToken)
        {
            var p = new ChatPostInstalledappsParameter();
            return await this.SendAsync<ChatPostInstalledappsParameter, ChatPostInstalledappsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-post-installedapps?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatPostInstalledappsResponse> ChatPostInstalledappsAsync(ChatPostInstalledappsParameter parameter)
        {
            return await this.SendAsync<ChatPostInstalledappsParameter, ChatPostInstalledappsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-post-installedapps?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatPostInstalledappsResponse> ChatPostInstalledappsAsync(ChatPostInstalledappsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatPostInstalledappsParameter, ChatPostInstalledappsResponse>(parameter, cancellationToken);
        }
    }
}
