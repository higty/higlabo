using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChatGetInstalledappsParameter : IRestApiParameter, IQueryParameterProperty
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
            Chats_ChatId_InstalledApps_AppInstallationId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Chats_ChatId_InstalledApps_AppInstallationId: return $"/chats/{ChatId}/installedApps/{AppInstallationId}";
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
        public string AppInstallationId { get; set; }
    }
    public partial class ChatGetInstalledappsResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? ExternalId { get; set; }
        public string? DisplayName { get; set; }
        public TeamsAppDistributionMethod? DistributionMethod { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-get-installedapps?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatGetInstalledappsResponse> ChatGetInstalledappsAsync()
        {
            var p = new ChatGetInstalledappsParameter();
            return await this.SendAsync<ChatGetInstalledappsParameter, ChatGetInstalledappsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-get-installedapps?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatGetInstalledappsResponse> ChatGetInstalledappsAsync(CancellationToken cancellationToken)
        {
            var p = new ChatGetInstalledappsParameter();
            return await this.SendAsync<ChatGetInstalledappsParameter, ChatGetInstalledappsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-get-installedapps?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatGetInstalledappsResponse> ChatGetInstalledappsAsync(ChatGetInstalledappsParameter parameter)
        {
            return await this.SendAsync<ChatGetInstalledappsParameter, ChatGetInstalledappsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-get-installedapps?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatGetInstalledappsResponse> ChatGetInstalledappsAsync(ChatGetInstalledappsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatGetInstalledappsParameter, ChatGetInstalledappsResponse>(parameter, cancellationToken);
        }
    }
}
