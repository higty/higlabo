using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignmentschedulerequests?view=graph-rest-1.0
/// </summary>
public partial class RbacApplicationListRoleAssignmentScheduleRequestsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.RoleManagement_Directory_RoleAssignmentScheduleRequests: return $"/roleManagement/directory/roleAssignmentScheduleRequests";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        RoleManagement_Directory_RoleAssignmentScheduleRequests,
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
public partial class RbacApplicationListRoleAssignmentScheduleRequestsResponse : RestApiResponse<UnifiedRoleAssignmentScheduleRequest>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignmentschedulerequests?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignmentschedulerequests?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<RbacApplicationListRoleAssignmentScheduleRequestsResponse> RbacApplicationListRoleAssignmentScheduleRequestsAsync()
    {
        var p = new RbacApplicationListRoleAssignmentScheduleRequestsParameter();
        return await this.SendAsync<RbacApplicationListRoleAssignmentScheduleRequestsParameter, RbacApplicationListRoleAssignmentScheduleRequestsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignmentschedulerequests?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<RbacApplicationListRoleAssignmentScheduleRequestsResponse> RbacApplicationListRoleAssignmentScheduleRequestsAsync(CancellationToken cancellationToken)
    {
        var p = new RbacApplicationListRoleAssignmentScheduleRequestsParameter();
        return await this.SendAsync<RbacApplicationListRoleAssignmentScheduleRequestsParameter, RbacApplicationListRoleAssignmentScheduleRequestsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignmentschedulerequests?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<RbacApplicationListRoleAssignmentScheduleRequestsResponse> RbacApplicationListRoleAssignmentScheduleRequestsAsync(RbacApplicationListRoleAssignmentScheduleRequestsParameter parameter)
    {
        return await this.SendAsync<RbacApplicationListRoleAssignmentScheduleRequestsParameter, RbacApplicationListRoleAssignmentScheduleRequestsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignmentschedulerequests?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<RbacApplicationListRoleAssignmentScheduleRequestsResponse> RbacApplicationListRoleAssignmentScheduleRequestsAsync(RbacApplicationListRoleAssignmentScheduleRequestsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<RbacApplicationListRoleAssignmentScheduleRequestsParameter, RbacApplicationListRoleAssignmentScheduleRequestsResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignmentschedulerequests?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<UnifiedRoleAssignmentScheduleRequest> RbacApplicationListRoleAssignmentScheduleRequestsEnumerateAsync(RbacApplicationListRoleAssignmentScheduleRequestsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<RbacApplicationListRoleAssignmentScheduleRequestsParameter, RbacApplicationListRoleAssignmentScheduleRequestsResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<UnifiedRoleAssignmentScheduleRequest>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
