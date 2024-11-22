using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/grouplifecyclepolicy-addgroup?view=graph-rest-1.0
/// </summary>
public partial class GrouplifecyclePolicyAddGroupParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.GroupLifecyclePolicies_Id_AddGroup: return $"/groupLifecyclePolicies/{Id}/addGroup";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        GroupLifecyclePolicies_Id_AddGroup,
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
public partial class GrouplifecyclePolicyAddGroupResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/grouplifecyclepolicy-addgroup?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/grouplifecyclepolicy-addgroup?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GrouplifecyclePolicyAddGroupResponse> GrouplifecyclePolicyAddGroupAsync()
    {
        var p = new GrouplifecyclePolicyAddGroupParameter();
        return await this.SendAsync<GrouplifecyclePolicyAddGroupParameter, GrouplifecyclePolicyAddGroupResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/grouplifecyclepolicy-addgroup?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GrouplifecyclePolicyAddGroupResponse> GrouplifecyclePolicyAddGroupAsync(CancellationToken cancellationToken)
    {
        var p = new GrouplifecyclePolicyAddGroupParameter();
        return await this.SendAsync<GrouplifecyclePolicyAddGroupParameter, GrouplifecyclePolicyAddGroupResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/grouplifecyclepolicy-addgroup?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GrouplifecyclePolicyAddGroupResponse> GrouplifecyclePolicyAddGroupAsync(GrouplifecyclePolicyAddGroupParameter parameter)
    {
        return await this.SendAsync<GrouplifecyclePolicyAddGroupParameter, GrouplifecyclePolicyAddGroupResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/grouplifecyclepolicy-addgroup?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GrouplifecyclePolicyAddGroupResponse> GrouplifecyclePolicyAddGroupAsync(GrouplifecyclePolicyAddGroupParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<GrouplifecyclePolicyAddGroupParameter, GrouplifecyclePolicyAddGroupResponse>(parameter, cancellationToken);
    }
}
