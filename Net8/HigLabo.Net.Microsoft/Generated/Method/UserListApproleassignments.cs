using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/user-list-approleassignments?view=graph-rest-1.0
/// </summary>
public partial class UserListApproleAssignmentsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? IdOrUserPrincipalName { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Users_IdOrUserPrincipalName_AppRoleAssignments: return $"/users/{IdOrUserPrincipalName}/appRoleAssignments";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Users_IdOrUserPrincipalName_AppRoleAssignments,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "GET";
    public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
    IQueryParameter IQueryParameterProperty.Query
    {
        get
        {
            return this.Query;
        }
    }
}
public partial class UserListApproleAssignmentsResponse : RestApiResponse<AppRoleAssignment>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/user-list-approleassignments?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-approleassignments?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UserListApproleAssignmentsResponse> UserListApproleAssignmentsAsync()
    {
        var p = new UserListApproleAssignmentsParameter();
        return await this.SendAsync<UserListApproleAssignmentsParameter, UserListApproleAssignmentsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-approleassignments?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UserListApproleAssignmentsResponse> UserListApproleAssignmentsAsync(CancellationToken cancellationToken)
    {
        var p = new UserListApproleAssignmentsParameter();
        return await this.SendAsync<UserListApproleAssignmentsParameter, UserListApproleAssignmentsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-approleassignments?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UserListApproleAssignmentsResponse> UserListApproleAssignmentsAsync(UserListApproleAssignmentsParameter parameter)
    {
        return await this.SendAsync<UserListApproleAssignmentsParameter, UserListApproleAssignmentsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-approleassignments?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UserListApproleAssignmentsResponse> UserListApproleAssignmentsAsync(UserListApproleAssignmentsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<UserListApproleAssignmentsParameter, UserListApproleAssignmentsResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-approleassignments?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<AppRoleAssignment> UserListApproleAssignmentsEnumerateAsync(UserListApproleAssignmentsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<UserListApproleAssignmentsParameter, UserListApproleAssignmentsResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<AppRoleAssignment>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
