using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChatListInstalledappsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
    }
    public partial class ChatListInstalledappsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/teamsappinstallation?view=graph-rest-1.0
        /// </summary>
        public partial class TeamsAppInstallation
        {
            public string? Id { get; set; }
        }

        public TeamsAppInstallation[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-list-installedapps?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatListInstalledappsResponse> ChatListInstalledappsAsync()
        {
            var p = new ChatListInstalledappsParameter();
            return await this.SendAsync<ChatListInstalledappsParameter, ChatListInstalledappsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-list-installedapps?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatListInstalledappsResponse> ChatListInstalledappsAsync(CancellationToken cancellationToken)
        {
            var p = new ChatListInstalledappsParameter();
            return await this.SendAsync<ChatListInstalledappsParameter, ChatListInstalledappsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-list-installedapps?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatListInstalledappsResponse> ChatListInstalledappsAsync(ChatListInstalledappsParameter parameter)
        {
            return await this.SendAsync<ChatListInstalledappsParameter, ChatListInstalledappsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-list-installedapps?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatListInstalledappsResponse> ChatListInstalledappsAsync(ChatListInstalledappsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatListInstalledappsParameter, ChatListInstalledappsResponse>(parameter, cancellationToken);
        }
    }
}
