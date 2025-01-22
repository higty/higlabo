using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/unifiedroleeligibilityschedule-filterbycurrentuser?view=graph-rest-1.0
/// </summary>
public partial class UnifiedroleeligibilityScheduleFilterbycurrentUserParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.RoleManagement_Directory_RoleEligibilitySchedules_FilterByCurrentUser: return $"/roleManagement/directory/roleEligibilitySchedules/filterByCurrentUser";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        RoleManagement_Directory_RoleEligibilitySchedules_FilterByCurrentUser,
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
public partial class UnifiedroleeligibilityScheduleFilterbycurrentUserResponse : RestApiResponse<UnifiedRoleEligibilitySchedule>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/unifiedroleeligibilityschedule-filterbycurrentuser?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedroleeligibilityschedule-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UnifiedroleeligibilityScheduleFilterbycurrentUserResponse> UnifiedroleeligibilityScheduleFilterbycurrentUserAsync()
    {
        var p = new UnifiedroleeligibilityScheduleFilterbycurrentUserParameter();
        return await this.SendAsync<UnifiedroleeligibilityScheduleFilterbycurrentUserParameter, UnifiedroleeligibilityScheduleFilterbycurrentUserResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedroleeligibilityschedule-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UnifiedroleeligibilityScheduleFilterbycurrentUserResponse> UnifiedroleeligibilityScheduleFilterbycurrentUserAsync(CancellationToken cancellationToken)
    {
        var p = new UnifiedroleeligibilityScheduleFilterbycurrentUserParameter();
        return await this.SendAsync<UnifiedroleeligibilityScheduleFilterbycurrentUserParameter, UnifiedroleeligibilityScheduleFilterbycurrentUserResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedroleeligibilityschedule-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UnifiedroleeligibilityScheduleFilterbycurrentUserResponse> UnifiedroleeligibilityScheduleFilterbycurrentUserAsync(UnifiedroleeligibilityScheduleFilterbycurrentUserParameter parameter)
    {
        return await this.SendAsync<UnifiedroleeligibilityScheduleFilterbycurrentUserParameter, UnifiedroleeligibilityScheduleFilterbycurrentUserResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedroleeligibilityschedule-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UnifiedroleeligibilityScheduleFilterbycurrentUserResponse> UnifiedroleeligibilityScheduleFilterbycurrentUserAsync(UnifiedroleeligibilityScheduleFilterbycurrentUserParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<UnifiedroleeligibilityScheduleFilterbycurrentUserParameter, UnifiedroleeligibilityScheduleFilterbycurrentUserResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedroleeligibilityschedule-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<UnifiedRoleEligibilitySchedule> UnifiedroleeligibilityScheduleFilterbycurrentUserEnumerateAsync(UnifiedroleeligibilityScheduleFilterbycurrentUserParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<UnifiedroleeligibilityScheduleFilterbycurrentUserParameter, UnifiedroleeligibilityScheduleFilterbycurrentUserResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<UnifiedRoleEligibilitySchedule>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
