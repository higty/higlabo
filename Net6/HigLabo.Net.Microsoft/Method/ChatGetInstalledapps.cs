using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chat-get-installedapps?view=graph-rest-1.0
    /// </summary>
    public partial class ChatGetInstalledappsParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class ChatGetInstalledappsResponse : RestApiResponse
    {
        public string? DisplayName { get; set; }
        public TeamsAppDistributionMethod? DistributionMethod { get; set; }
        public string? ExternalId { get; set; }
        public string? Id { get; set; }
        public TeamsAppDefinition[]? AppDefinitions { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chat-get-installedapps?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-get-installedapps?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatGetInstalledappsResponse> ChatGetInstalledappsAsync()
        {
            var p = new ChatGetInstalledappsParameter();
            return await this.SendAsync<ChatGetInstalledappsParameter, ChatGetInstalledappsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-get-installedapps?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatGetInstalledappsResponse> ChatGetInstalledappsAsync(CancellationToken cancellationToken)
        {
            var p = new ChatGetInstalledappsParameter();
            return await this.SendAsync<ChatGetInstalledappsParameter, ChatGetInstalledappsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-get-installedapps?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatGetInstalledappsResponse> ChatGetInstalledappsAsync(ChatGetInstalledappsParameter parameter)
        {
            return await this.SendAsync<ChatGetInstalledappsParameter, ChatGetInstalledappsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-get-installedapps?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatGetInstalledappsResponse> ChatGetInstalledappsAsync(ChatGetInstalledappsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatGetInstalledappsParameter, ChatGetInstalledappsResponse>(parameter, cancellationToken);
        }
    }
}
