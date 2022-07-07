using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserscopeteamsappinstallationGetChatParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Users_UserIdOrUserPrincipalName_Teamwork_InstalledApps_AppInstallationId_Chat,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Users_UserIdOrUserPrincipalName_Teamwork_InstalledApps_AppInstallationId_Chat: return $"/users/{UserIdOrUserPrincipalName}/teamwork/installedApps/{AppInstallationId}/chat";
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
        public string UserIdOrUserPrincipalName { get; set; }
        public string AppInstallationId { get; set; }
    }
    public partial class UserscopeteamsappinstallationGetChatResponse : RestApiResponse
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
        public string? WebUrl { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userscopeteamsappinstallation-get-chat?view=graph-rest-1.0
        /// </summary>
        public async Task<UserscopeteamsappinstallationGetChatResponse> UserscopeteamsappinstallationGetChatAsync()
        {
            var p = new UserscopeteamsappinstallationGetChatParameter();
            return await this.SendAsync<UserscopeteamsappinstallationGetChatParameter, UserscopeteamsappinstallationGetChatResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userscopeteamsappinstallation-get-chat?view=graph-rest-1.0
        /// </summary>
        public async Task<UserscopeteamsappinstallationGetChatResponse> UserscopeteamsappinstallationGetChatAsync(CancellationToken cancellationToken)
        {
            var p = new UserscopeteamsappinstallationGetChatParameter();
            return await this.SendAsync<UserscopeteamsappinstallationGetChatParameter, UserscopeteamsappinstallationGetChatResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userscopeteamsappinstallation-get-chat?view=graph-rest-1.0
        /// </summary>
        public async Task<UserscopeteamsappinstallationGetChatResponse> UserscopeteamsappinstallationGetChatAsync(UserscopeteamsappinstallationGetChatParameter parameter)
        {
            return await this.SendAsync<UserscopeteamsappinstallationGetChatParameter, UserscopeteamsappinstallationGetChatResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userscopeteamsappinstallation-get-chat?view=graph-rest-1.0
        /// </summary>
        public async Task<UserscopeteamsappinstallationGetChatResponse> UserscopeteamsappinstallationGetChatAsync(UserscopeteamsappinstallationGetChatParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserscopeteamsappinstallationGetChatParameter, UserscopeteamsappinstallationGetChatResponse>(parameter, cancellationToken);
        }
    }
}
