using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/grouplifecyclepolicy-post-grouplifecyclepolicies?view=graph-rest-1.0
    /// </summary>
    public partial class GrouplifecyclePolicyPostGrouplifecyclepoliciesParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.GroupLifecyclePolicies: return $"/groupLifecyclePolicies";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            GroupLifecyclePolicies,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? AlternateNotificationEmails { get; set; }
        public Int32? GroupLifetimeInDays { get; set; }
        public string? Id { get; set; }
        public string? ManagedGroupTypes { get; set; }
    }
    public partial class GrouplifecyclePolicyPostGrouplifecyclepoliciesResponse : RestApiResponse
    {
        public string? AlternateNotificationEmails { get; set; }
        public Int32? GroupLifetimeInDays { get; set; }
        public string? Id { get; set; }
        public string? ManagedGroupTypes { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/grouplifecyclepolicy-post-grouplifecyclepolicies?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/grouplifecyclepolicy-post-grouplifecyclepolicies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<GrouplifecyclePolicyPostGrouplifecyclepoliciesResponse> GrouplifecyclePolicyPostGrouplifecyclepoliciesAsync()
        {
            var p = new GrouplifecyclePolicyPostGrouplifecyclepoliciesParameter();
            return await this.SendAsync<GrouplifecyclePolicyPostGrouplifecyclepoliciesParameter, GrouplifecyclePolicyPostGrouplifecyclepoliciesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/grouplifecyclepolicy-post-grouplifecyclepolicies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<GrouplifecyclePolicyPostGrouplifecyclepoliciesResponse> GrouplifecyclePolicyPostGrouplifecyclepoliciesAsync(CancellationToken cancellationToken)
        {
            var p = new GrouplifecyclePolicyPostGrouplifecyclepoliciesParameter();
            return await this.SendAsync<GrouplifecyclePolicyPostGrouplifecyclepoliciesParameter, GrouplifecyclePolicyPostGrouplifecyclepoliciesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/grouplifecyclepolicy-post-grouplifecyclepolicies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<GrouplifecyclePolicyPostGrouplifecyclepoliciesResponse> GrouplifecyclePolicyPostGrouplifecyclepoliciesAsync(GrouplifecyclePolicyPostGrouplifecyclepoliciesParameter parameter)
        {
            return await this.SendAsync<GrouplifecyclePolicyPostGrouplifecyclepoliciesParameter, GrouplifecyclePolicyPostGrouplifecyclepoliciesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/grouplifecyclepolicy-post-grouplifecyclepolicies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<GrouplifecyclePolicyPostGrouplifecyclepoliciesResponse> GrouplifecyclePolicyPostGrouplifecyclepoliciesAsync(GrouplifecyclePolicyPostGrouplifecyclepoliciesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GrouplifecyclePolicyPostGrouplifecyclepoliciesParameter, GrouplifecyclePolicyPostGrouplifecyclepoliciesResponse>(parameter, cancellationToken);
        }
    }
}
