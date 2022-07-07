using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupPostConversationsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Groups_Id_Conversations,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Groups_Id_Conversations: return $"/groups/{Id}/conversations";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Id { get; set; }
    }
    public partial class GroupPostConversationsResponse : RestApiResponse
    {
        public bool? HasAttachments { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? LastDeliveredDateTime { get; set; }
        public string? Preview { get; set; }
        public string? Topic { get; set; }
        public String[]? UniqueSenders { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-post-conversations?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupPostConversationsResponse> GroupPostConversationsAsync()
        {
            var p = new GroupPostConversationsParameter();
            return await this.SendAsync<GroupPostConversationsParameter, GroupPostConversationsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-post-conversations?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupPostConversationsResponse> GroupPostConversationsAsync(CancellationToken cancellationToken)
        {
            var p = new GroupPostConversationsParameter();
            return await this.SendAsync<GroupPostConversationsParameter, GroupPostConversationsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-post-conversations?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupPostConversationsResponse> GroupPostConversationsAsync(GroupPostConversationsParameter parameter)
        {
            return await this.SendAsync<GroupPostConversationsParameter, GroupPostConversationsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-post-conversations?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupPostConversationsResponse> GroupPostConversationsAsync(GroupPostConversationsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupPostConversationsParameter, GroupPostConversationsResponse>(parameter, cancellationToken);
        }
    }
}
