using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GrouplifecyclepolicyDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            GroupLifecyclePolicies_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.GroupLifecyclePolicies_Id: return $"/groupLifecyclePolicies/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string Id { get; set; }
    }
    public partial class GrouplifecyclepolicyDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/grouplifecyclepolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<GrouplifecyclepolicyDeleteResponse> GrouplifecyclepolicyDeleteAsync()
        {
            var p = new GrouplifecyclepolicyDeleteParameter();
            return await this.SendAsync<GrouplifecyclepolicyDeleteParameter, GrouplifecyclepolicyDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/grouplifecyclepolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<GrouplifecyclepolicyDeleteResponse> GrouplifecyclepolicyDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new GrouplifecyclepolicyDeleteParameter();
            return await this.SendAsync<GrouplifecyclepolicyDeleteParameter, GrouplifecyclepolicyDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/grouplifecyclepolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<GrouplifecyclepolicyDeleteResponse> GrouplifecyclepolicyDeleteAsync(GrouplifecyclepolicyDeleteParameter parameter)
        {
            return await this.SendAsync<GrouplifecyclepolicyDeleteParameter, GrouplifecyclepolicyDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/grouplifecyclepolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<GrouplifecyclepolicyDeleteResponse> GrouplifecyclepolicyDeleteAsync(GrouplifecyclepolicyDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GrouplifecyclepolicyDeleteParameter, GrouplifecyclepolicyDeleteResponse>(parameter, cancellationToken);
        }
    }
}
