using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChatListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? UserIdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Chats: return $"/me/chats";
                    case ApiPath.Users_UserIdOrUserPrincipalName_Chats: return $"/users/{UserIdOrUserPrincipalName}/chats";
                    case ApiPath.Chats: return $"/chats";
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
            WebUrl,
            InstalledApps,
            Members,
            Messages,
            Tabs,
        }
        public enum ApiPath
        {
            Me_Chats,
            Users_UserIdOrUserPrincipalName_Chats,
            Chats,
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
    public partial class ChatListResponse : RestApiResponse
    {
        public Chat[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatListResponse> ChatListAsync()
        {
            var p = new ChatListParameter();
            return await this.SendAsync<ChatListParameter, ChatListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatListResponse> ChatListAsync(CancellationToken cancellationToken)
        {
            var p = new ChatListParameter();
            return await this.SendAsync<ChatListParameter, ChatListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatListResponse> ChatListAsync(ChatListParameter parameter)
        {
            return await this.SendAsync<ChatListParameter, ChatListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatListResponse> ChatListAsync(ChatListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatListParameter, ChatListResponse>(parameter, cancellationToken);
        }
    }
}
