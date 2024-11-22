using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/policyroot-list-rolemanagementpolicyassignments?view=graph-rest-1.0
/// </summary>
public partial class PolicyRootListRoleManagementPolicyAssignmentsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Policies_RoleManagementPolicyAssignments: return $"/policies/roleManagementPolicyAssignments";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Policies_RoleManagementPolicyAssignments,
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
public partial class PolicyRootListRoleManagementPolicyAssignmentsResponse : RestApiResponse<UnifiedRoleManagementPolicyAssignment>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/policyroot-list-rolemanagementpolicyassignments?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/policyroot-list-rolemanagementpolicyassignments?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PolicyRootListRoleManagementPolicyAssignmentsResponse> PolicyRootListRoleManagementPolicyAssignmentsAsync()
    {
        var p = new PolicyRootListRoleManagementPolicyAssignmentsParameter();
        return await this.SendAsync<PolicyRootListRoleManagementPolicyAssignmentsParameter, PolicyRootListRoleManagementPolicyAssignmentsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/policyroot-list-rolemanagementpolicyassignments?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PolicyRootListRoleManagementPolicyAssignmentsResponse> PolicyRootListRoleManagementPolicyAssignmentsAsync(CancellationToken cancellationToken)
    {
        var p = new PolicyRootListRoleManagementPolicyAssignmentsParameter();
        return await this.SendAsync<PolicyRootListRoleManagementPolicyAssignmentsParameter, PolicyRootListRoleManagementPolicyAssignmentsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/policyroot-list-rolemanagementpolicyassignments?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PolicyRootListRoleManagementPolicyAssignmentsResponse> PolicyRootListRoleManagementPolicyAssignmentsAsync(PolicyRootListRoleManagementPolicyAssignmentsParameter parameter)
    {
        return await this.SendAsync<PolicyRootListRoleManagementPolicyAssignmentsParameter, PolicyRootListRoleManagementPolicyAssignmentsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/policyroot-list-rolemanagementpolicyassignments?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PolicyRootListRoleManagementPolicyAssignmentsResponse> PolicyRootListRoleManagementPolicyAssignmentsAsync(PolicyRootListRoleManagementPolicyAssignmentsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<PolicyRootListRoleManagementPolicyAssignmentsParameter, PolicyRootListRoleManagementPolicyAssignmentsResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/policyroot-list-rolemanagementpolicyassignments?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<UnifiedRoleManagementPolicyAssignment> PolicyRootListRoleManagementPolicyAssignmentsEnumerateAsync(PolicyRootListRoleManagementPolicyAssignmentsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<PolicyRootListRoleManagementPolicyAssignmentsParameter, PolicyRootListRoleManagementPolicyAssignmentsResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<UnifiedRoleManagementPolicyAssignment>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
