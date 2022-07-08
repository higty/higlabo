using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChatTeamsappinstallationUpgradeParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string ChatId { get; set; }
            public string AppInstallationId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Chats_ChatId_InstalledApps_AppInstallationId_Upgrade: return $"/chats/{ChatId}/installedApps/{AppInstallationId}/upgrade";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Chats_ChatId_InstalledApps_AppInstallationId_Upgrade,
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
    public partial class ChatTeamsappinstallationUpgradeResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-teamsappinstallation-upgrade?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatTeamsappinstallationUpgradeResponse> ChatTeamsappinstallationUpgradeAsync()
        {
            var p = new ChatTeamsappinstallationUpgradeParameter();
            return await this.SendAsync<ChatTeamsappinstallationUpgradeParameter, ChatTeamsappinstallationUpgradeResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-teamsappinstallation-upgrade?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatTeamsappinstallationUpgradeResponse> ChatTeamsappinstallationUpgradeAsync(CancellationToken cancellationToken)
        {
            var p = new ChatTeamsappinstallationUpgradeParameter();
            return await this.SendAsync<ChatTeamsappinstallationUpgradeParameter, ChatTeamsappinstallationUpgradeResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-teamsappinstallation-upgrade?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatTeamsappinstallationUpgradeResponse> ChatTeamsappinstallationUpgradeAsync(ChatTeamsappinstallationUpgradeParameter parameter)
        {
            return await this.SendAsync<ChatTeamsappinstallationUpgradeParameter, ChatTeamsappinstallationUpgradeResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-teamsappinstallation-upgrade?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatTeamsappinstallationUpgradeResponse> ChatTeamsappinstallationUpgradeAsync(ChatTeamsappinstallationUpgradeParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatTeamsappinstallationUpgradeParameter, ChatTeamsappinstallationUpgradeResponse>(parameter, cancellationToken);
        }
    }
}
