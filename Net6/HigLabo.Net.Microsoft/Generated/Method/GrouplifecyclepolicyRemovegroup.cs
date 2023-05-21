using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/grouplifecyclepolicy-removegroup?view=graph-rest-1.0
    /// </summary>
    public partial class GrouplifecyclePolicyRemoveGroupParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.GroupLifecyclePolicies_Id_RemoveGroup: return $"/groupLifecyclePolicies/{Id}/removeGroup";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            GroupLifecyclePolicies_Id_RemoveGroup,
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
        public string? GroupId { get; set; }
    }
    public partial class GrouplifecyclePolicyRemoveGroupResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/grouplifecyclepolicy-removegroup?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/grouplifecyclepolicy-removegroup?view=graph-rest-1.0
        /// </summary>
        public async Task<GrouplifecyclePolicyRemoveGroupResponse> GrouplifecyclePolicyRemoveGroupAsync()
        {
            var p = new GrouplifecyclePolicyRemoveGroupParameter();
            return await this.SendAsync<GrouplifecyclePolicyRemoveGroupParameter, GrouplifecyclePolicyRemoveGroupResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/grouplifecyclepolicy-removegroup?view=graph-rest-1.0
        /// </summary>
        public async Task<GrouplifecyclePolicyRemoveGroupResponse> GrouplifecyclePolicyRemoveGroupAsync(CancellationToken cancellationToken)
        {
            var p = new GrouplifecyclePolicyRemoveGroupParameter();
            return await this.SendAsync<GrouplifecyclePolicyRemoveGroupParameter, GrouplifecyclePolicyRemoveGroupResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/grouplifecyclepolicy-removegroup?view=graph-rest-1.0
        /// </summary>
        public async Task<GrouplifecyclePolicyRemoveGroupResponse> GrouplifecyclePolicyRemoveGroupAsync(GrouplifecyclePolicyRemoveGroupParameter parameter)
        {
            return await this.SendAsync<GrouplifecyclePolicyRemoveGroupParameter, GrouplifecyclePolicyRemoveGroupResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/grouplifecyclepolicy-removegroup?view=graph-rest-1.0
        /// </summary>
        public async Task<GrouplifecyclePolicyRemoveGroupResponse> GrouplifecyclePolicyRemoveGroupAsync(GrouplifecyclePolicyRemoveGroupParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GrouplifecyclePolicyRemoveGroupParameter, GrouplifecyclePolicyRemoveGroupResponse>(parameter, cancellationToken);
        }
    }
}
