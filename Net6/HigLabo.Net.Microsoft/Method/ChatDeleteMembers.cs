using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chat-delete-members?view=graph-rest-1.0
    /// </summary>
    public partial class ChatDeleteMembersParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ChatId { get; set; }
            public string? MembershipId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Chats_ChatId_Members_MembershipId: return $"/chats/{ChatId}/members/{MembershipId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Chats_ChatId_Members_MembershipId,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class ChatDeleteMembersResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chat-delete-members?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-delete-members?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatDeleteMembersResponse> ChatDeleteMembersAsync()
        {
            var p = new ChatDeleteMembersParameter();
            return await this.SendAsync<ChatDeleteMembersParameter, ChatDeleteMembersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-delete-members?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatDeleteMembersResponse> ChatDeleteMembersAsync(CancellationToken cancellationToken)
        {
            var p = new ChatDeleteMembersParameter();
            return await this.SendAsync<ChatDeleteMembersParameter, ChatDeleteMembersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-delete-members?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatDeleteMembersResponse> ChatDeleteMembersAsync(ChatDeleteMembersParameter parameter)
        {
            return await this.SendAsync<ChatDeleteMembersParameter, ChatDeleteMembersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-delete-members?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatDeleteMembersResponse> ChatDeleteMembersAsync(ChatDeleteMembersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatDeleteMembersParameter, ChatDeleteMembersResponse>(parameter, cancellationToken);
        }
    }
}
