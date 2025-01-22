using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/group-delete-approleassignments?view=graph-rest-1.0
/// </summary>
public partial class GroupDeleteApproleAssignmentsParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? GroupsId { get; set; }
        public string? AppRoleAssignmentsId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Groups_Id_AppRoleAssignments_Id: return $"/groups/{GroupsId}/appRoleAssignments/{AppRoleAssignmentsId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Groups_Id_AppRoleAssignments_Id,
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
public partial class GroupDeleteApproleAssignmentsResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/group-delete-approleassignments?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-delete-approleassignments?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupDeleteApproleAssignmentsResponse> GroupDeleteApproleAssignmentsAsync()
    {
        var p = new GroupDeleteApproleAssignmentsParameter();
        return await this.SendAsync<GroupDeleteApproleAssignmentsParameter, GroupDeleteApproleAssignmentsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-delete-approleassignments?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupDeleteApproleAssignmentsResponse> GroupDeleteApproleAssignmentsAsync(CancellationToken cancellationToken)
    {
        var p = new GroupDeleteApproleAssignmentsParameter();
        return await this.SendAsync<GroupDeleteApproleAssignmentsParameter, GroupDeleteApproleAssignmentsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-delete-approleassignments?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupDeleteApproleAssignmentsResponse> GroupDeleteApproleAssignmentsAsync(GroupDeleteApproleAssignmentsParameter parameter)
    {
        return await this.SendAsync<GroupDeleteApproleAssignmentsParameter, GroupDeleteApproleAssignmentsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-delete-approleassignments?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupDeleteApproleAssignmentsResponse> GroupDeleteApproleAssignmentsAsync(GroupDeleteApproleAssignmentsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<GroupDeleteApproleAssignmentsParameter, GroupDeleteApproleAssignmentsResponse>(parameter, cancellationToken);
    }
}
