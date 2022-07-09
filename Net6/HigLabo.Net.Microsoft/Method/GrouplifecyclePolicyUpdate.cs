using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GrouplifecyclePolicyUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.GroupLifecyclePolicies_Id: return $"/groupLifecyclePolicies/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            GroupLifecyclePolicies_Id,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public string? AlternateNotificationEmails { get; set; }
        public Int32? GroupLifetimeInDays { get; set; }
        public string? ManagedGroupTypes { get; set; }
    }
    public partial class GrouplifecyclePolicyUpdateResponse : RestApiResponse
    {
        public string? AlternateNotificationEmails { get; set; }
        public Int32? GroupLifetimeInDays { get; set; }
        public string? Id { get; set; }
        public string? ManagedGroupTypes { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/grouplifecyclepolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<GrouplifecyclePolicyUpdateResponse> GrouplifecyclePolicyUpdateAsync()
        {
            var p = new GrouplifecyclePolicyUpdateParameter();
            return await this.SendAsync<GrouplifecyclePolicyUpdateParameter, GrouplifecyclePolicyUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/grouplifecyclepolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<GrouplifecyclePolicyUpdateResponse> GrouplifecyclePolicyUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new GrouplifecyclePolicyUpdateParameter();
            return await this.SendAsync<GrouplifecyclePolicyUpdateParameter, GrouplifecyclePolicyUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/grouplifecyclepolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<GrouplifecyclePolicyUpdateResponse> GrouplifecyclePolicyUpdateAsync(GrouplifecyclePolicyUpdateParameter parameter)
        {
            return await this.SendAsync<GrouplifecyclePolicyUpdateParameter, GrouplifecyclePolicyUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/grouplifecyclepolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<GrouplifecyclePolicyUpdateResponse> GrouplifecyclePolicyUpdateAsync(GrouplifecyclePolicyUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GrouplifecyclePolicyUpdateParameter, GrouplifecyclePolicyUpdateResponse>(parameter, cancellationToken);
        }
    }
}
