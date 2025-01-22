using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/policyroot-list-rolemanagementpolicies?view=graph-rest-1.0
/// </summary>
public partial class PolicyRootListRoleManagementpoliciesParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Policies_RoleManagementPolicies: return $"/policies/roleManagementPolicies";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Policies_RoleManagementPolicies,
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
public partial class PolicyRootListRoleManagementpoliciesResponse : RestApiResponse<UnifiedRoleManagementPolicy>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/policyroot-list-rolemanagementpolicies?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/policyroot-list-rolemanagementpolicies?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PolicyRootListRoleManagementpoliciesResponse> PolicyRootListRoleManagementpoliciesAsync()
    {
        var p = new PolicyRootListRoleManagementpoliciesParameter();
        return await this.SendAsync<PolicyRootListRoleManagementpoliciesParameter, PolicyRootListRoleManagementpoliciesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/policyroot-list-rolemanagementpolicies?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PolicyRootListRoleManagementpoliciesResponse> PolicyRootListRoleManagementpoliciesAsync(CancellationToken cancellationToken)
    {
        var p = new PolicyRootListRoleManagementpoliciesParameter();
        return await this.SendAsync<PolicyRootListRoleManagementpoliciesParameter, PolicyRootListRoleManagementpoliciesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/policyroot-list-rolemanagementpolicies?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PolicyRootListRoleManagementpoliciesResponse> PolicyRootListRoleManagementpoliciesAsync(PolicyRootListRoleManagementpoliciesParameter parameter)
    {
        return await this.SendAsync<PolicyRootListRoleManagementpoliciesParameter, PolicyRootListRoleManagementpoliciesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/policyroot-list-rolemanagementpolicies?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PolicyRootListRoleManagementpoliciesResponse> PolicyRootListRoleManagementpoliciesAsync(PolicyRootListRoleManagementpoliciesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<PolicyRootListRoleManagementpoliciesParameter, PolicyRootListRoleManagementpoliciesResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/policyroot-list-rolemanagementpolicies?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<UnifiedRoleManagementPolicy> PolicyRootListRoleManagementpoliciesEnumerateAsync(PolicyRootListRoleManagementpoliciesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<PolicyRootListRoleManagementpoliciesParameter, PolicyRootListRoleManagementpoliciesResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<UnifiedRoleManagementPolicy>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
