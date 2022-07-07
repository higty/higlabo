using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChatDeleteMembersParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Chats_ChatId_Members_MembershipId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Chats_ChatId_Members_MembershipId: return $"/chats/{ChatId}/members/{MembershipId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string ChatId { get; set; }
        public string MembershipId { get; set; }
    }
    public partial class ChatDeleteMembersResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-delete-members?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatDeleteMembersResponse> ChatDeleteMembersAsync()
        {
            var p = new ChatDeleteMembersParameter();
            return await this.SendAsync<ChatDeleteMembersParameter, ChatDeleteMembersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-delete-members?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatDeleteMembersResponse> ChatDeleteMembersAsync(CancellationToken cancellationToken)
        {
            var p = new ChatDeleteMembersParameter();
            return await this.SendAsync<ChatDeleteMembersParameter, ChatDeleteMembersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-delete-members?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatDeleteMembersResponse> ChatDeleteMembersAsync(ChatDeleteMembersParameter parameter)
        {
            return await this.SendAsync<ChatDeleteMembersParameter, ChatDeleteMembersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chat-delete-members?view=graph-rest-1.0
        /// </summary>
        public async Task<ChatDeleteMembersResponse> ChatDeleteMembersAsync(ChatDeleteMembersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatDeleteMembersParameter, ChatDeleteMembersResponse>(parameter, cancellationToken);
        }
    }
}
