using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChatPostInstalledappsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ChatId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Chats_ChatId_InstalledApps: return $"/chats/{ChatId}/installedApps";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Chats_ChatId_InstalledApps,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
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
