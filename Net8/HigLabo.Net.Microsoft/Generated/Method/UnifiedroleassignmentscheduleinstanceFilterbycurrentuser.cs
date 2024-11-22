using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/unifiedroleassignmentscheduleinstance-filterbycurrentuser?view=graph-rest-1.0
/// </summary>
public partial class UnifiedroleAssignmentScheduleinstanceFilterbycurrentUserParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.RoleManagement_Directory_RoleAssignmentScheduleInstances_FilterByCurrentUser: return $"/roleManagement/directory/roleAssignmentScheduleInstances/filterByCurrentUser";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        RoleManagement_Directory_RoleAssignmentScheduleInstances_FilterByCurrentUser,
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
public partial class UnifiedroleAssignmentScheduleinstanceFilterbycurrentUserResponse : RestApiResponse<UnifiedRoleAssignmentScheduleInstance>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/unifiedroleassignmentscheduleinstance-filterbycurrentuser?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedroleassignmentscheduleinstance-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UnifiedroleAssignmentScheduleinstanceFilterbycurrentUserResponse> UnifiedroleAssignmentScheduleinstanceFilterbycurrentUserAsync()
    {
        var p = new UnifiedroleAssignmentScheduleinstanceFilterbycurrentUserParameter();
        return await this.SendAsync<UnifiedroleAssignmentScheduleinstanceFilterbycurrentUserParameter, UnifiedroleAssignmentScheduleinstanceFilterbycurrentUserResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedroleassignmentscheduleinstance-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UnifiedroleAssignmentScheduleinstanceFilterbycurrentUserResponse> UnifiedroleAssignmentScheduleinstanceFilterbycurrentUserAsync(CancellationToken cancellationToken)
    {
        var p = new UnifiedroleAssignmentScheduleinstanceFilterbycurrentUserParameter();
        return await this.SendAsync<UnifiedroleAssignmentScheduleinstanceFilterbycurrentUserParameter, UnifiedroleAssignmentScheduleinstanceFilterbycurrentUserResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedroleassignmentscheduleinstance-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UnifiedroleAssignmentScheduleinstanceFilterbycurrentUserResponse> UnifiedroleAssignmentScheduleinstanceFilterbycurrentUserAsync(UnifiedroleAssignmentScheduleinstanceFilterbycurrentUserParameter parameter)
    {
        return await this.SendAsync<UnifiedroleAssignmentScheduleinstanceFilterbycurrentUserParameter, UnifiedroleAssignmentScheduleinstanceFilterbycurrentUserResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedroleassignmentscheduleinstance-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UnifiedroleAssignmentScheduleinstanceFilterbycurrentUserResponse> UnifiedroleAssignmentScheduleinstanceFilterbycurrentUserAsync(UnifiedroleAssignmentScheduleinstanceFilterbycurrentUserParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<UnifiedroleAssignmentScheduleinstanceFilterbycurrentUserParameter, UnifiedroleAssignmentScheduleinstanceFilterbycurrentUserResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedroleassignmentscheduleinstance-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<UnifiedRoleAssignmentScheduleInstance> UnifiedroleAssignmentScheduleinstanceFilterbycurrentUserEnumerateAsync(UnifiedroleAssignmentScheduleinstanceFilterbycurrentUserParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<UnifiedroleAssignmentScheduleinstanceFilterbycurrentUserParameter, UnifiedroleAssignmentScheduleinstanceFilterbycurrentUserResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<UnifiedRoleAssignmentScheduleInstance>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
