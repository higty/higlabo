using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/group-post-approleassignments?view=graph-rest-1.0
/// </summary>
public partial class GroupPostApproleAssignmentsParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? GroupId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Groups_GroupId_AppRoleAssignments: return $"/groups/{GroupId}/appRoleAssignments";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Groups_GroupId_AppRoleAssignments,
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
    public Guid? AppRoleId { get; set; }
    public Guid? PrincipalId { get; set; }
    public Guid? ResourceId { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public DateTimeOffset? DeletedDateTime { get; set; }
    public string? Id { get; set; }
    public string? PrincipalDisplayName { get; set; }
    public string? PrincipalType { get; set; }
    public string? ResourceDisplayName { get; set; }
}
public partial class GroupPostApproleAssignmentsResponse : RestApiResponse
{
    public Guid? AppRoleId { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public DateTimeOffset? DeletedDateTime { get; set; }
    public string? Id { get; set; }
    public string? PrincipalDisplayName { get; set; }
    public Guid? PrincipalId { get; set; }
    public string? PrincipalType { get; set; }
    public string? ResourceDisplayName { get; set; }
    public Guid? ResourceId { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/group-post-approleassignments?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-post-approleassignments?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupPostApproleAssignmentsResponse> GroupPostApproleAssignmentsAsync()
    {
        var p = new GroupPostApproleAssignmentsParameter();
        return await this.SendAsync<GroupPostApproleAssignmentsParameter, GroupPostApproleAssignmentsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-post-approleassignments?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupPostApproleAssignmentsResponse> GroupPostApproleAssignmentsAsync(CancellationToken cancellationToken)
    {
        var p = new GroupPostApproleAssignmentsParameter();
        return await this.SendAsync<GroupPostApproleAssignmentsParameter, GroupPostApproleAssignmentsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-post-approleassignments?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupPostApproleAssignmentsResponse> GroupPostApproleAssignmentsAsync(GroupPostApproleAssignmentsParameter parameter)
    {
        return await this.SendAsync<GroupPostApproleAssignmentsParameter, GroupPostApproleAssignmentsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-post-approleassignments?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupPostApproleAssignmentsResponse> GroupPostApproleAssignmentsAsync(GroupPostApproleAssignmentsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<GroupPostApproleAssignmentsParameter, GroupPostApproleAssignmentsResponse>(parameter, cancellationToken);
    }
}
