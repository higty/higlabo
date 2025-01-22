using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignments?view=graph-rest-1.0
/// </summary>
public partial class RbacApplicationListRoleAssignmentsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.RoleManagement_Directory_RoleAssignments: return $"/roleManagement/directory/roleAssignments";
                case ApiPath.RoleManagement_EntitlementManagement_RoleAssignments: return $"/roleManagement/entitlementManagement/roleAssignments";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        RoleManagement_Directory_RoleAssignments,
        RoleManagement_EntitlementManagement_RoleAssignments,
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
public partial class RbacApplicationListRoleAssignmentsResponse : RestApiResponse<UnifiedRoleAssignment>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignments?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignments?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<RbacApplicationListRoleAssignmentsResponse> RbacApplicationListRoleAssignmentsAsync()
    {
        var p = new RbacApplicationListRoleAssignmentsParameter();
        return await this.SendAsync<RbacApplicationListRoleAssignmentsParameter, RbacApplicationListRoleAssignmentsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignments?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<RbacApplicationListRoleAssignmentsResponse> RbacApplicationListRoleAssignmentsAsync(CancellationToken cancellationToken)
    {
        var p = new RbacApplicationListRoleAssignmentsParameter();
        return await this.SendAsync<RbacApplicationListRoleAssignmentsParameter, RbacApplicationListRoleAssignmentsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignments?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<RbacApplicationListRoleAssignmentsResponse> RbacApplicationListRoleAssignmentsAsync(RbacApplicationListRoleAssignmentsParameter parameter)
    {
        return await this.SendAsync<RbacApplicationListRoleAssignmentsParameter, RbacApplicationListRoleAssignmentsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignments?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<RbacApplicationListRoleAssignmentsResponse> RbacApplicationListRoleAssignmentsAsync(RbacApplicationListRoleAssignmentsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<RbacApplicationListRoleAssignmentsParameter, RbacApplicationListRoleAssignmentsResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignments?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<UnifiedRoleAssignment> RbacApplicationListRoleAssignmentsEnumerateAsync(RbacApplicationListRoleAssignmentsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<RbacApplicationListRoleAssignmentsParameter, RbacApplicationListRoleAssignmentsResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<UnifiedRoleAssignment>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
