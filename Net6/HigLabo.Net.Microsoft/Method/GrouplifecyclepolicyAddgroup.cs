using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GrouplifecyclepolicyAddgroupParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            GroupLifecyclePolicies_Id_AddGroup,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.GroupLifecyclePolicies_Id_AddGroup: return $"/groupLifecyclePolicies/{Id}/addGroup";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? GroupId { get; set; }
        public string Id { get; set; }
    }
    public partial class GrouplifecyclepolicyAddgroupResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/grouplifecyclepolicy-addgroup?view=graph-rest-1.0
        /// </summary>
        public async Task<GrouplifecyclepolicyAddgroupResponse> GrouplifecyclepolicyAddgroupAsync()
        {
            var p = new GrouplifecyclepolicyAddgroupParameter();
            return await this.SendAsync<GrouplifecyclepolicyAddgroupParameter, GrouplifecyclepolicyAddgroupResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/grouplifecyclepolicy-addgroup?view=graph-rest-1.0
        /// </summary>
        public async Task<GrouplifecyclepolicyAddgroupResponse> GrouplifecyclepolicyAddgroupAsync(CancellationToken cancellationToken)
        {
            var p = new GrouplifecyclepolicyAddgroupParameter();
            return await this.SendAsync<GrouplifecyclepolicyAddgroupParameter, GrouplifecyclepolicyAddgroupResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/grouplifecyclepolicy-addgroup?view=graph-rest-1.0
        /// </summary>
        public async Task<GrouplifecyclepolicyAddgroupResponse> GrouplifecyclepolicyAddgroupAsync(GrouplifecyclepolicyAddgroupParameter parameter)
        {
            return await this.SendAsync<GrouplifecyclepolicyAddgroupParameter, GrouplifecyclepolicyAddgroupResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/grouplifecyclepolicy-addgroup?view=graph-rest-1.0
        /// </summary>
        public async Task<GrouplifecyclepolicyAddgroupResponse> GrouplifecyclepolicyAddgroupAsync(GrouplifecyclepolicyAddgroupParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GrouplifecyclepolicyAddgroupParameter, GrouplifecyclepolicyAddgroupResponse>(parameter, cancellationToken);
        }
    }
}
