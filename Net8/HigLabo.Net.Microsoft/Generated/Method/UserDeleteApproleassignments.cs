using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/user-delete-approleassignments?view=graph-rest-1.0
/// </summary>
public partial class UserDeleteApproleAssignmentsParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? UsersId { get; set; }
        public string? AppRoleAssignmentsId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Users_Id_AppRoleAssignments_Id: return $"/users/{UsersId}/appRoleAssignments/{AppRoleAssignmentsId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Users_Id_AppRoleAssignments_Id,
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
public partial class UserDeleteApproleAssignmentsResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/user-delete-approleassignments?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-delete-approleassignments?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UserDeleteApproleAssignmentsResponse> UserDeleteApproleAssignmentsAsync()
    {
        var p = new UserDeleteApproleAssignmentsParameter();
        return await this.SendAsync<UserDeleteApproleAssignmentsParameter, UserDeleteApproleAssignmentsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-delete-approleassignments?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UserDeleteApproleAssignmentsResponse> UserDeleteApproleAssignmentsAsync(CancellationToken cancellationToken)
    {
        var p = new UserDeleteApproleAssignmentsParameter();
        return await this.SendAsync<UserDeleteApproleAssignmentsParameter, UserDeleteApproleAssignmentsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-delete-approleassignments?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UserDeleteApproleAssignmentsResponse> UserDeleteApproleAssignmentsAsync(UserDeleteApproleAssignmentsParameter parameter)
    {
        return await this.SendAsync<UserDeleteApproleAssignmentsParameter, UserDeleteApproleAssignmentsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-delete-approleassignments?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UserDeleteApproleAssignmentsResponse> UserDeleteApproleAssignmentsAsync(UserDeleteApproleAssignmentsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<UserDeleteApproleAssignmentsParameter, UserDeleteApproleAssignmentsResponse>(parameter, cancellationToken);
    }
}
