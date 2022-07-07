using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupDeleteRejectedsendersParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Groups_Id_RejectedSenders_ref,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Groups_Id_RejectedSenders_ref: return $"/groups/{Id}/rejectedSenders/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string Id { get; set; }
    }
    public partial class GroupDeleteRejectedsendersResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-delete-rejectedsenders?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupDeleteRejectedsendersResponse> GroupDeleteRejectedsendersAsync()
        {
            var p = new GroupDeleteRejectedsendersParameter();
            return await this.SendAsync<GroupDeleteRejectedsendersParameter, GroupDeleteRejectedsendersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-delete-rejectedsenders?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupDeleteRejectedsendersResponse> GroupDeleteRejectedsendersAsync(CancellationToken cancellationToken)
        {
            var p = new GroupDeleteRejectedsendersParameter();
            return await this.SendAsync<GroupDeleteRejectedsendersParameter, GroupDeleteRejectedsendersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-delete-rejectedsenders?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupDeleteRejectedsendersResponse> GroupDeleteRejectedsendersAsync(GroupDeleteRejectedsendersParameter parameter)
        {
            return await this.SendAsync<GroupDeleteRejectedsendersParameter, GroupDeleteRejectedsendersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-delete-rejectedsenders?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupDeleteRejectedsendersResponse> GroupDeleteRejectedsendersAsync(GroupDeleteRejectedsendersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupDeleteRejectedsendersParameter, GroupDeleteRejectedsendersResponse>(parameter, cancellationToken);
        }
    }
}
