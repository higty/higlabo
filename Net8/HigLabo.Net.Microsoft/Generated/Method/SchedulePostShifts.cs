using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/schedule-post-shifts?view=graph-rest-1.0
/// </summary>
public partial class SchedulePostShiftsParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? TeamId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Teams_TeamId_Schedule_Shifts: return $"/teams/{TeamId}/schedule/shifts";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Teams_TeamId_Schedule_Shifts,
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
    public DateTimeOffset? CreatedDateTime { get; set; }
    public ShiftItem? DraftShift { get; set; }
    public string? Id { get; set; }
    public IdentitySet? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedDateTime { get; set; }
    public string? SchedulingGroupId { get; set; }
    public ShiftItem? SharedShift { get; set; }
    public string? UserId { get; set; }
}
public partial class SchedulePostShiftsResponse : RestApiResponse
{
    public DateTimeOffset? CreatedDateTime { get; set; }
    public ShiftItem? DraftShift { get; set; }
    public string? Id { get; set; }
    public IdentitySet? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedDateTime { get; set; }
    public string? SchedulingGroupId { get; set; }
    public ShiftItem? SharedShift { get; set; }
    public string? UserId { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/schedule-post-shifts?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/schedule-post-shifts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SchedulePostShiftsResponse> SchedulePostShiftsAsync()
    {
        var p = new SchedulePostShiftsParameter();
        return await this.SendAsync<SchedulePostShiftsParameter, SchedulePostShiftsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/schedule-post-shifts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SchedulePostShiftsResponse> SchedulePostShiftsAsync(CancellationToken cancellationToken)
    {
        var p = new SchedulePostShiftsParameter();
        return await this.SendAsync<SchedulePostShiftsParameter, SchedulePostShiftsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/schedule-post-shifts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SchedulePostShiftsResponse> SchedulePostShiftsAsync(SchedulePostShiftsParameter parameter)
    {
        return await this.SendAsync<SchedulePostShiftsParameter, SchedulePostShiftsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/schedule-post-shifts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SchedulePostShiftsResponse> SchedulePostShiftsAsync(SchedulePostShiftsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<SchedulePostShiftsParameter, SchedulePostShiftsResponse>(parameter, cancellationToken);
    }
}
