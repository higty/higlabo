using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/unifiedroleeligibilityscheduleinstance-filterbycurrentuser?view=graph-rest-1.0
/// </summary>
public partial class UnifiedroleeligibilityScheduleinstanceFilterbycurrentUserParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.RoleManagement_Directory_RoleEligibilityScheduleInstances_FilterByCurrentUser: return $"/roleManagement/directory/roleEligibilityScheduleInstances/filterByCurrentUser";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        RoleManagement_Directory_RoleEligibilityScheduleInstances_FilterByCurrentUser,
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
public partial class UnifiedroleeligibilityScheduleinstanceFilterbycurrentUserResponse : RestApiResponse<UnifiedRoleEligibilityScheduleInstance>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/unifiedroleeligibilityscheduleinstance-filterbycurrentuser?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedroleeligibilityscheduleinstance-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UnifiedroleeligibilityScheduleinstanceFilterbycurrentUserResponse> UnifiedroleeligibilityScheduleinstanceFilterbycurrentUserAsync()
    {
        var p = new UnifiedroleeligibilityScheduleinstanceFilterbycurrentUserParameter();
        return await this.SendAsync<UnifiedroleeligibilityScheduleinstanceFilterbycurrentUserParameter, UnifiedroleeligibilityScheduleinstanceFilterbycurrentUserResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedroleeligibilityscheduleinstance-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UnifiedroleeligibilityScheduleinstanceFilterbycurrentUserResponse> UnifiedroleeligibilityScheduleinstanceFilterbycurrentUserAsync(CancellationToken cancellationToken)
    {
        var p = new UnifiedroleeligibilityScheduleinstanceFilterbycurrentUserParameter();
        return await this.SendAsync<UnifiedroleeligibilityScheduleinstanceFilterbycurrentUserParameter, UnifiedroleeligibilityScheduleinstanceFilterbycurrentUserResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedroleeligibilityscheduleinstance-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UnifiedroleeligibilityScheduleinstanceFilterbycurrentUserResponse> UnifiedroleeligibilityScheduleinstanceFilterbycurrentUserAsync(UnifiedroleeligibilityScheduleinstanceFilterbycurrentUserParameter parameter)
    {
        return await this.SendAsync<UnifiedroleeligibilityScheduleinstanceFilterbycurrentUserParameter, UnifiedroleeligibilityScheduleinstanceFilterbycurrentUserResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedroleeligibilityscheduleinstance-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UnifiedroleeligibilityScheduleinstanceFilterbycurrentUserResponse> UnifiedroleeligibilityScheduleinstanceFilterbycurrentUserAsync(UnifiedroleeligibilityScheduleinstanceFilterbycurrentUserParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<UnifiedroleeligibilityScheduleinstanceFilterbycurrentUserParameter, UnifiedroleeligibilityScheduleinstanceFilterbycurrentUserResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedroleeligibilityscheduleinstance-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<UnifiedRoleEligibilityScheduleInstance> UnifiedroleeligibilityScheduleinstanceFilterbycurrentUserEnumerateAsync(UnifiedroleeligibilityScheduleinstanceFilterbycurrentUserParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<UnifiedroleeligibilityScheduleinstanceFilterbycurrentUserParameter, UnifiedroleeligibilityScheduleinstanceFilterbycurrentUserResponse>(parameter, cancellationToken);
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
