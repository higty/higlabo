using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GrouplifecyclepolicyRemovegroupParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            GroupLifecyclePolicies_Id_RemoveGroup,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.GroupLifecyclePolicies_Id_RemoveGroup: return $"/groupLifecyclePolicies/{Id}/removeGroup";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? GroupId { get; set; }
        public string Id { get; set; }
    }
    public partial class GrouplifecyclepolicyRemovegroupResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/grouplifecyclepolicy-removegroup?view=graph-rest-1.0
        /// </summary>
        public async Task<GrouplifecyclepolicyRemovegroupResponse> GrouplifecyclepolicyRemovegroupAsync()
        {
            var p = new GrouplifecyclepolicyRemovegroupParameter();
            return await this.SendAsync<GrouplifecyclepolicyRemovegroupParameter, GrouplifecyclepolicyRemovegroupResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/grouplifecyclepolicy-removegroup?view=graph-rest-1.0
        /// </summary>
        public async Task<GrouplifecyclepolicyRemovegroupResponse> GrouplifecyclepolicyRemovegroupAsync(CancellationToken cancellationToken)
        {
            var p = new GrouplifecyclepolicyRemovegroupParameter();
            return await this.SendAsync<GrouplifecyclepolicyRemovegroupParameter, GrouplifecyclepolicyRemovegroupResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/grouplifecyclepolicy-removegroup?view=graph-rest-1.0
        /// </summary>
        public async Task<GrouplifecyclepolicyRemovegroupResponse> GrouplifecyclepolicyRemovegroupAsync(GrouplifecyclepolicyRemovegroupParameter parameter)
        {
            return await this.SendAsync<GrouplifecyclepolicyRemovegroupParameter, GrouplifecyclepolicyRemovegroupResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/grouplifecyclepolicy-removegroup?view=graph-rest-1.0
        /// </summary>
        public async Task<GrouplifecyclepolicyRemovegroupResponse> GrouplifecyclepolicyRemovegroupAsync(GrouplifecyclepolicyRemovegroupParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GrouplifecyclepolicyRemovegroupParameter, GrouplifecyclepolicyRemovegroupResponse>(parameter, cancellationToken);
        }
    }
}
