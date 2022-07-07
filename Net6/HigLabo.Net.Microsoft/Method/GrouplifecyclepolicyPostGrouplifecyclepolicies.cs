using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GrouplifecyclepolicyPostGrouplifecyclepoliciesParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            GroupLifecyclePolicies,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.GroupLifecyclePolicies: return $"/groupLifecyclePolicies";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
    }
    public partial class GrouplifecyclepolicyPostGrouplifecyclepoliciesResponse : RestApiResponse
    {
        public string? AlternateNotificationEmails { get; set; }
        public Int32? GroupLifetimeInDays { get; set; }
        public string? Id { get; set; }
        public string? ManagedGroupTypes { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/grouplifecyclepolicy-post-grouplifecyclepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<GrouplifecyclepolicyPostGrouplifecyclepoliciesResponse> GrouplifecyclepolicyPostGrouplifecyclepoliciesAsync()
        {
            var p = new GrouplifecyclepolicyPostGrouplifecyclepoliciesParameter();
            return await this.SendAsync<GrouplifecyclepolicyPostGrouplifecyclepoliciesParameter, GrouplifecyclepolicyPostGrouplifecyclepoliciesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/grouplifecyclepolicy-post-grouplifecyclepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<GrouplifecyclepolicyPostGrouplifecyclepoliciesResponse> GrouplifecyclepolicyPostGrouplifecyclepoliciesAsync(CancellationToken cancellationToken)
        {
            var p = new GrouplifecyclepolicyPostGrouplifecyclepoliciesParameter();
            return await this.SendAsync<GrouplifecyclepolicyPostGrouplifecyclepoliciesParameter, GrouplifecyclepolicyPostGrouplifecyclepoliciesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/grouplifecyclepolicy-post-grouplifecyclepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<GrouplifecyclepolicyPostGrouplifecyclepoliciesResponse> GrouplifecyclepolicyPostGrouplifecyclepoliciesAsync(GrouplifecyclepolicyPostGrouplifecyclepoliciesParameter parameter)
        {
            return await this.SendAsync<GrouplifecyclepolicyPostGrouplifecyclepoliciesParameter, GrouplifecyclepolicyPostGrouplifecyclepoliciesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/grouplifecyclepolicy-post-grouplifecyclepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<GrouplifecyclepolicyPostGrouplifecyclepoliciesResponse> GrouplifecyclepolicyPostGrouplifecyclepoliciesAsync(GrouplifecyclepolicyPostGrouplifecyclepoliciesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GrouplifecyclepolicyPostGrouplifecyclepoliciesParameter, GrouplifecyclepolicyPostGrouplifecyclepoliciesResponse>(parameter, cancellationToken);
        }
    }
}
