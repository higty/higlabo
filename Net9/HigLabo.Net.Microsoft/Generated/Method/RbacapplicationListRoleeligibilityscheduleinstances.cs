using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleeligibilityscheduleinstances?view=graph-rest-1.0
/// </summary>
public partial class RbacApplicationListRoleeligibilityScheduleinstancesParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.RoleManagement_Directory_RoleEligibilityScheduleInstances: return $"/roleManagement/directory/roleEligibilityScheduleInstances";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        RoleManagement_Directory_RoleEligibilityScheduleInstances,
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
public partial class RbacApplicationListRoleeligibilityScheduleinstancesResponse : RestApiResponse<UnifiedRoleEligibilityScheduleInstance>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleeligibilityscheduleinstances?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleeligibilityscheduleinstances?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<RbacApplicationListRoleeligibilityScheduleinstancesResponse> RbacApplicationListRoleeligibilityScheduleinstancesAsync()
    {
        var p = new RbacApplicationListRoleeligibilityScheduleinstancesParameter();
        return await this.SendAsync<RbacApplicationListRoleeligibilityScheduleinstancesParameter, RbacApplicationListRoleeligibilityScheduleinstancesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleeligibilityscheduleinstances?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<RbacApplicationListRoleeligibilityScheduleinstancesResponse> RbacApplicationListRoleeligibilityScheduleinstancesAsync(CancellationToken cancellationToken)
    {
        var p = new RbacApplicationListRoleeligibilityScheduleinstancesParameter();
        return await this.SendAsync<RbacApplicationListRoleeligibilityScheduleinstancesParameter, RbacApplicationListRoleeligibilityScheduleinstancesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleeligibilityscheduleinstances?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<RbacApplicationListRoleeligibilityScheduleinstancesResponse> RbacApplicationListRoleeligibilityScheduleinstancesAsync(RbacApplicationListRoleeligibilityScheduleinstancesParameter parameter)
    {
        return await this.SendAsync<RbacApplicationListRoleeligibilityScheduleinstancesParameter, RbacApplicationListRoleeligibilityScheduleinstancesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleeligibilityscheduleinstances?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<RbacApplicationListRoleeligibilityScheduleinstancesResponse> RbacApplicationListRoleeligibilityScheduleinstancesAsync(RbacApplicationListRoleeligibilityScheduleinstancesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<RbacApplicationListRoleeligibilityScheduleinstancesParameter, RbacApplicationListRoleeligibilityScheduleinstancesResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleeligibilityscheduleinstances?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<UnifiedRoleEligibilityScheduleInstance> RbacApplicationListRoleeligibilityScheduleinstancesEnumerateAsync(RbacApplicationListRoleeligibilityScheduleinstancesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<RbacApplicationListRoleeligibilityScheduleinstancesParameter, RbacApplicationListRoleeligibilityScheduleinstancesResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<UnifiedRoleEligibilityScheduleInstance>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
