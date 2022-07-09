using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChatDeleteInstalledappsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ChatId { get; set; }
            public string? AppInstallationId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Chats_ChatId_InstalledApps_AppInstallationId: return $"/chats/{ChatId}/installedApps/{AppInstallationId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Chats_ChatId_InstalledApps_AppInstallationId,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class ChatDeleteInstalledappsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-delete-installedapps?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatDeleteInstalledappsResponse> ChatDeleteInstalledappsAsync()
        {
            var p = new ChatDeleteInstalledappsParameter();
            return await this.SendAsync<ChatDeleteInstalledappsParameter, ChatDeleteInstalledappsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-delete-installedapps?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatDeleteInstalledappsResponse> ChatDeleteInstalledappsAsync(CancellationToken cancellationToken)
        {
            var p = new ChatDeleteInstalledappsParameter();
            return await this.SendAsync<ChatDeleteInstalledappsParameter, ChatDeleteInstalledappsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-delete-installedapps?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatDeleteInstalledappsResponse> ChatDeleteInstalledappsAsync(ChatDeleteInstalledappsParameter parameter)
        {
            return await this.SendAsync<ChatDeleteInstalledappsParameter, ChatDeleteInstalledappsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-delete-installedapps?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatDeleteInstalledappsResponse> ChatDeleteInstalledappsAsync(ChatDeleteInstalledappsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatDeleteInstalledappsParameter, ChatDeleteInstalledappsResponse>(parameter, cancellationToken);
        }
    }
}
