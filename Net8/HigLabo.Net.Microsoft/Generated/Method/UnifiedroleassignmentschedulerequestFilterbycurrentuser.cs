using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/unifiedroleassignmentschedulerequest-filterbycurrentuser?view=graph-rest-1.0
/// </summary>
public partial class UnifiedroleAssignmentScheduleRequestFilterbycurrentUserParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.RoleManagement_Directory_RoleAssignmentScheduleRequests_FilterByCurrentUser: return $"/roleManagement/directory/roleAssignmentScheduleRequests/filterByCurrentUser";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        RoleManagement_Directory_RoleAssignmentScheduleRequests_FilterByCurrentUser,
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
public partial class UnifiedroleAssignmentScheduleRequestFilterbycurrentUserResponse : RestApiResponse<UnifiedRoleAssignmentScheduleRequest>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/unifiedroleassignmentschedulerequest-filterbycurrentuser?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedroleassignmentschedulerequest-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UnifiedroleAssignmentScheduleRequestFilterbycurrentUserResponse> UnifiedroleAssignmentScheduleRequestFilterbycurrentUserAsync()
    {
        var p = new UnifiedroleAssignmentScheduleRequestFilterbycurrentUserParameter();
        return await this.SendAsync<UnifiedroleAssignmentScheduleRequestFilterbycurrentUserParameter, UnifiedroleAssignmentScheduleRequestFilterbycurrentUserResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedroleassignmentschedulerequest-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UnifiedroleAssignmentScheduleRequestFilterbycurrentUserResponse> UnifiedroleAssignmentScheduleRequestFilterbycurrentUserAsync(CancellationToken cancellationToken)
    {
        var p = new UnifiedroleAssignmentScheduleRequestFilterbycurrentUserParameter();
        return await this.SendAsync<UnifiedroleAssignmentScheduleRequestFilterbycurrentUserParameter, UnifiedroleAssignmentScheduleRequestFilterbycurrentUserResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedroleassignmentschedulerequest-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UnifiedroleAssignmentScheduleRequestFilterbycurrentUserResponse> UnifiedroleAssignmentScheduleRequestFilterbycurrentUserAsync(UnifiedroleAssignmentScheduleRequestFilterbycurrentUserParameter parameter)
    {
        return await this.SendAsync<UnifiedroleAssignmentScheduleRequestFilterbycurrentUserParameter, UnifiedroleAssignmentScheduleRequestFilterbycurrentUserResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedroleassignmentschedulerequest-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UnifiedroleAssignmentScheduleRequestFilterbycurrentUserResponse> UnifiedroleAssignmentScheduleRequestFilterbycurrentUserAsync(UnifiedroleAssignmentScheduleRequestFilterbycurrentUserParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<UnifiedroleAssignmentScheduleRequestFilterbycurrentUserParameter, UnifiedroleAssignmentScheduleRequestFilterbycurrentUserResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedroleassignmentschedulerequest-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<UnifiedRoleAssignmentScheduleRequest> UnifiedroleAssignmentScheduleRequestFilterbycurrentUserEnumerateAsync(UnifiedroleAssignmentScheduleRequestFilterbycurrentUserParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<UnifiedroleAssignmentScheduleRequestFilterbycurrentUserParameter, UnifiedroleAssignmentScheduleRequestFilterbycurrentUserResponse>(parameter, cancellationToken);
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
