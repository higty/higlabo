using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChatListInstalledappsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string ChatId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Chats_ChatId_InstalledApps: return $"/chats/{ChatId}/installedApps";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Id,
            TeamsApp,
            TeamsAppDefinition,
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
    public partial class ChatListInstalledappsResponse : RestApiResponse
    {
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
