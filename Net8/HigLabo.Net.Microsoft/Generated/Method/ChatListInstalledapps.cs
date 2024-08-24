using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chat-list-installedapps?view=graph-rest-1.0
    /// </summary>
    public partial class ChatListInstalledappsParameter : IRestApiParameter, IQueryParameterProperty
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

        public enum Field
        {
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
    public partial class ChatListInstalledappsResponse : RestApiResponse<TeamsAppInstallation>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chat-list-installedapps?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-list-installedapps?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChatListInstalledappsResponse> ChatListInstalledappsAsync()
        {
            var p = new ChatListInstalledappsParameter();
            return await this.SendAsync<ChatListInstalledappsParameter, ChatListInstalledappsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-list-installedapps?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChatListInstalledappsResponse> ChatListInstalledappsAsync(CancellationToken cancellationToken)
        {
            var p = new ChatListInstalledappsParameter();
            return await this.SendAsync<ChatListInstalledappsParameter, ChatListInstalledappsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-list-installedapps?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChatListInstalledappsResponse> ChatListInstalledappsAsync(ChatListInstalledappsParameter parameter)
        {
            return await this.SendAsync<ChatListInstalledappsParameter, ChatListInstalledappsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-list-installedapps?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChatListInstalledappsResponse> ChatListInstalledappsAsync(ChatListInstalledappsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatListInstalledappsParameter, ChatListInstalledappsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-list-installedapps?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<TeamsAppInstallation> ChatListInstalledappsEnumerateAsync(ChatListInstalledappsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<ChatListInstalledappsParameter, ChatListInstalledappsResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<TeamsAppInstallation>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
