using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/unifiedroleeligibilityschedulerequest-cancel?view=graph-rest-1.0
/// </summary>
public partial class UnifiedroleeligibilityScheduleRequestCancelParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? UnifiedRoleEligibilityScheduleRequestId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.RoleManagement_Directory_RoleEligibilityScheduleRequests_UnifiedRoleEligibilityScheduleRequestId_Cancel: return $"/roleManagement/directory/roleEligibilityScheduleRequests/{UnifiedRoleEligibilityScheduleRequestId}/cancel";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        RoleManagement_Directory_RoleEligibilityScheduleRequests_UnifiedRoleEligibilityScheduleRequestId_Cancel,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "POST";
}
public partial class UnifiedroleeligibilityScheduleRequestCancelResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/unifiedroleeligibilityschedulerequest-cancel?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedroleeligibilityschedulerequest-cancel?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UnifiedroleeligibilityScheduleRequestCancelResponse> UnifiedroleeligibilityScheduleRequestCancelAsync()
    {
        var p = new UnifiedroleeligibilityScheduleRequestCancelParameter();
        return await this.SendAsync<UnifiedroleeligibilityScheduleRequestCancelParameter, UnifiedroleeligibilityScheduleRequestCancelResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedroleeligibilityschedulerequest-cancel?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UnifiedroleeligibilityScheduleRequestCancelResponse> UnifiedroleeligibilityScheduleRequestCancelAsync(CancellationToken cancellationToken)
    {
        var p = new UnifiedroleeligibilityScheduleRequestCancelParameter();
        return await this.SendAsync<UnifiedroleeligibilityScheduleRequestCancelParameter, UnifiedroleeligibilityScheduleRequestCancelResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedroleeligibilityschedulerequest-cancel?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UnifiedroleeligibilityScheduleRequestCancelResponse> UnifiedroleeligibilityScheduleRequestCancelAsync(UnifiedroleeligibilityScheduleRequestCancelParameter parameter)
    {
        return await this.SendAsync<UnifiedroleeligibilityScheduleRequestCancelParameter, UnifiedroleeligibilityScheduleRequestCancelResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedroleeligibilityschedulerequest-cancel?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UnifiedroleeligibilityScheduleRequestCancelResponse> UnifiedroleeligibilityScheduleRequestCancelAsync(UnifiedroleeligibilityScheduleRequestCancelParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<UnifiedroleeligibilityScheduleRequestCancelParameter, UnifiedroleeligibilityScheduleRequestCancelResponse>(parameter, cancellationToken);
    }
}
