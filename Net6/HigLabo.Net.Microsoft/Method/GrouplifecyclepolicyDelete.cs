using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GrouplifecyclePolicyDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }

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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class GrouplifecyclePolicyDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/grouplifecyclepolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<GrouplifecyclePolicyDeleteResponse> GrouplifecyclePolicyDeleteAsync()
        {
            var p = new GrouplifecyclePolicyDeleteParameter();
            return await this.SendAsync<GrouplifecyclePolicyDeleteParameter, GrouplifecyclePolicyDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/grouplifecyclepolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<GrouplifecyclePolicyDeleteResponse> GrouplifecyclePolicyDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new GrouplifecyclePolicyDeleteParameter();
            return await this.SendAsync<GrouplifecyclePolicyDeleteParameter, GrouplifecyclePolicyDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/grouplifecyclepolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<GrouplifecyclePolicyDeleteResponse> GrouplifecyclePolicyDeleteAsync(GrouplifecyclePolicyDeleteParameter parameter)
        {
            return await this.SendAsync<GrouplifecyclePolicyDeleteParameter, GrouplifecyclePolicyDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/grouplifecyclepolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<GrouplifecyclePolicyDeleteResponse> GrouplifecyclePolicyDeleteAsync(GrouplifecyclePolicyDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GrouplifecyclePolicyDeleteParameter, GrouplifecyclePolicyDeleteResponse>(parameter, cancellationToken);
        }
    }
}
