using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chat-get-members?view=graph-rest-1.0
    /// </summary>
    public partial class ChatGetMembersParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ChatId { get; set; }
            public string? MembershipId { get; set; }
            public string? UserId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Chats_ChatId_Members_MembershipId: return $"/chats/{ChatId}/members/{MembershipId}";
                    case ApiPath.Users_UserIdOrUserPrincipalName_Chats_ChatId_Members_MembershipId: return $"/users/{UserId} | user-principal-name/chats/{ChatId}/members/{MembershipId}";
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
            Chats_ChatId_Members_MembershipId,
            Users_UserIdOrUserPrincipalName_Chats_ChatId_Members_MembershipId,
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
    public partial class ChatGetMembersResponse : RestApiResponse
    {
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public string[]? Roles { get; set; }
        public DateTimeOffset? VisibleHistoryStartDateTime { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chat-get-members?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-get-members?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChatGetMembersResponse> ChatGetMembersAsync()
        {
            var p = new ChatGetMembersParameter();
            return await this.SendAsync<ChatGetMembersParameter, ChatGetMembersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-get-members?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChatGetMembersResponse> ChatGetMembersAsync(CancellationToken cancellationToken)
        {
            var p = new ChatGetMembersParameter();
            return await this.SendAsync<ChatGetMembersParameter, ChatGetMembersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-get-members?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChatGetMembersResponse> ChatGetMembersAsync(ChatGetMembersParameter parameter)
        {
            return await this.SendAsync<ChatGetMembersParameter, ChatGetMembersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-get-members?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChatGetMembersResponse> ChatGetMembersAsync(ChatGetMembersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatGetMembersParameter, ChatGetMembersResponse>(parameter, cancellationToken);
        }
    }
}
