using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/unifiedroleassignmentschedule-filterbycurrentuser?view=graph-rest-1.0
/// </summary>
public partial class UnifiedroleAssignmentScheduleFilterbycurrentUserParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.RoleManagement_Directory_RoleAssignmentSchedules_FilterByCurrentUser: return $"/roleManagement/directory/roleAssignmentSchedules/filterByCurrentUser";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        RoleManagement_Directory_RoleAssignmentSchedules_FilterByCurrentUser,
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
public partial class UnifiedroleAssignmentScheduleFilterbycurrentUserResponse : RestApiResponse<UnifiedRoleAssignmentSchedule>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/unifiedroleassignmentschedule-filterbycurrentuser?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedroleassignmentschedule-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UnifiedroleAssignmentScheduleFilterbycurrentUserResponse> UnifiedroleAssignmentScheduleFilterbycurrentUserAsync()
    {
        var p = new UnifiedroleAssignmentScheduleFilterbycurrentUserParameter();
        return await this.SendAsync<UnifiedroleAssignmentScheduleFilterbycurrentUserParameter, UnifiedroleAssignmentScheduleFilterbycurrentUserResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedroleassignmentschedule-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UnifiedroleAssignmentScheduleFilterbycurrentUserResponse> UnifiedroleAssignmentScheduleFilterbycurrentUserAsync(CancellationToken cancellationToken)
    {
        var p = new UnifiedroleAssignmentScheduleFilterbycurrentUserParameter();
        return await this.SendAsync<UnifiedroleAssignmentScheduleFilterbycurrentUserParameter, UnifiedroleAssignmentScheduleFilterbycurrentUserResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedroleassignmentschedule-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UnifiedroleAssignmentScheduleFilterbycurrentUserResponse> UnifiedroleAssignmentScheduleFilterbycurrentUserAsync(UnifiedroleAssignmentScheduleFilterbycurrentUserParameter parameter)
    {
        return await this.SendAsync<UnifiedroleAssignmentScheduleFilterbycurrentUserParameter, UnifiedroleAssignmentScheduleFilterbycurrentUserResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedroleassignmentschedule-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UnifiedroleAssignmentScheduleFilterbycurrentUserResponse> UnifiedroleAssignmentScheduleFilterbycurrentUserAsync(UnifiedroleAssignmentScheduleFilterbycurrentUserParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<UnifiedroleAssignmentScheduleFilterbycurrentUserParameter, UnifiedroleAssignmentScheduleFilterbycurrentUserResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedroleassignmentschedule-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<UnifiedRoleAssignmentSchedule> UnifiedroleAssignmentScheduleFilterbycurrentUserEnumerateAsync(UnifiedroleAssignmentScheduleFilterbycurrentUserParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<UnifiedroleAssignmentScheduleFilterbycurrentUserParameter, UnifiedroleAssignmentScheduleFilterbycurrentUserResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<UnifiedRoleAssignmentSchedule>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
