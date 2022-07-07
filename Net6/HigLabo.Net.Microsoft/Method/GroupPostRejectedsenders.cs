using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupPostRejectedsendersParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Id { get; set; }
    }
    public partial class GroupPostRejectedsendersResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-post-rejectedsenders?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupPostRejectedsendersResponse> GroupPostRejectedsendersAsync()
        {
            var p = new GroupPostRejectedsendersParameter();
            return await this.SendAsync<GroupPostRejectedsendersParameter, GroupPostRejectedsendersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-post-rejectedsenders?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupPostRejectedsendersResponse> GroupPostRejectedsendersAsync(CancellationToken cancellationToken)
        {
            var p = new GroupPostRejectedsendersParameter();
            return await this.SendAsync<GroupPostRejectedsendersParameter, GroupPostRejectedsendersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-post-rejectedsenders?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupPostRejectedsendersResponse> GroupPostRejectedsendersAsync(GroupPostRejectedsendersParameter parameter)
        {
            return await this.SendAsync<GroupPostRejectedsendersParameter, GroupPostRejectedsendersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-post-rejectedsenders?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupPostRejectedsendersResponse> GroupPostRejectedsendersAsync(GroupPostRejectedsendersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupPostRejectedsendersParameter, GroupPostRejectedsendersResponse>(parameter, cancellationToken);
        }
    }
}
