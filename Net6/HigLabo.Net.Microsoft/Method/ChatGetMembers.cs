using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChatGetMembersParameter : IRestApiParameter, IQueryParameterProperty
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
            Chats_ChatId_Members_MembershipId,
            Users_UserIdOrUserPrincipalName_Chats_ChatId_Members_MembershipId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Chats_ChatId_Members_MembershipId: return $"/chats/{ChatId}/members/{MembershipId}";
                    case ApiPath.Users_UserIdOrUserPrincipalName_Chats_ChatId_Members_MembershipId: return $"/users/{UserId} | user-principal-name/chats/{ChatId}/members/{MembershipId}";
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
        public string MembershipId { get; set; }
        public string UserId { get; set; }
    }
    public partial class ChatGetMembersResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string[]? Roles { get; set; }
        public DateTimeOffset? VisibleHistoryStartDateTime { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-get-members?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatGetMembersResponse> ChatGetMembersAsync()
        {
            var p = new ChatGetMembersParameter();
            return await this.SendAsync<ChatGetMembersParameter, ChatGetMembersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-get-members?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatGetMembersResponse> ChatGetMembersAsync(CancellationToken cancellationToken)
        {
            var p = new ChatGetMembersParameter();
            return await this.SendAsync<ChatGetMembersParameter, ChatGetMembersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-get-members?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatGetMembersResponse> ChatGetMembersAsync(ChatGetMembersParameter parameter)
        {
            return await this.SendAsync<ChatGetMembersParameter, ChatGetMembersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-get-members?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatGetMembersResponse> ChatGetMembersAsync(ChatGetMembersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatGetMembersParameter, ChatGetMembersResponse>(parameter, cancellationToken);
        }
    }
}
