using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/userscopeteamsappinstallation-get-chat?view=graph-rest-1.0
    /// </summary>
    public partial class UserscopeTeamsappinstallationGetChatParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? UserIdOrUserPrincipalName { get; set; }
            public string? AppInstallationId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Users_UserIdOrUserPrincipalName_Teamwork_InstalledApps_AppInstallationId_Chat: return $"/users/{UserIdOrUserPrincipalName}/teamwork/installedApps/{AppInstallationId}/chat";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Users_UserIdOrUserPrincipalName_Teamwork_InstalledApps_AppInstallationId_Chat,
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
    public partial class UserscopeTeamsappinstallationGetChatResponse : RestApiResponse
    {
        public enum ChatChatType
        {
            Group,
            OneOnOne,
            Meeting,
            UnknownFutureValue,
        }

        public Chat? ChatType { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? LastUpdatedDateTime { get; set; }
        public TeamworkOnlineMeetingInfo? OnlineMeetingInfo { get; set; }
        public string? TenantId { get; set; }
        public string? Topic { get; set; }
        public ChatViewpoint? Viewpoint { get; set; }
        public string? WebUrl { get; set; }
        public TeamsAppInstallation[]? InstalledApps { get; set; }
        public ChatMessageInfo? LastMessagePreview { get; set; }
        public ConversationMember[]? Members { get; set; }
        public ChatMessage[]? Messages { get; set; }
        public PinnedChatMessageInfo[]? PinnedMessages { get; set; }
        public TeamsTab[]? Tabs { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/userscopeteamsappinstallation-get-chat?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/userscopeteamsappinstallation-get-chat?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserscopeTeamsappinstallationGetChatResponse> UserscopeTeamsappinstallationGetChatAsync()
        {
            var p = new UserscopeTeamsappinstallationGetChatParameter();
            return await this.SendAsync<UserscopeTeamsappinstallationGetChatParameter, UserscopeTeamsappinstallationGetChatResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/userscopeteamsappinstallation-get-chat?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserscopeTeamsappinstallationGetChatResponse> UserscopeTeamsappinstallationGetChatAsync(CancellationToken cancellationToken)
        {
            var p = new UserscopeTeamsappinstallationGetChatParameter();
            return await this.SendAsync<UserscopeTeamsappinstallationGetChatParameter, UserscopeTeamsappinstallationGetChatResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/userscopeteamsappinstallation-get-chat?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserscopeTeamsappinstallationGetChatResponse> UserscopeTeamsappinstallationGetChatAsync(UserscopeTeamsappinstallationGetChatParameter parameter)
        {
            return await this.SendAsync<UserscopeTeamsappinstallationGetChatParameter, UserscopeTeamsappinstallationGetChatResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/userscopeteamsappinstallation-get-chat?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserscopeTeamsappinstallationGetChatResponse> UserscopeTeamsappinstallationGetChatAsync(UserscopeTeamsappinstallationGetChatParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserscopeTeamsappinstallationGetChatParameter, UserscopeTeamsappinstallationGetChatResponse>(parameter, cancellationToken);
        }
    }
}
