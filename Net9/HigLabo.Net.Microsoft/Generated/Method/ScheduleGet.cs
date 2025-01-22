using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/schedule-get?view=graph-rest-1.0
/// </summary>
public partial class ScheduleGetParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? TeamId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Teams_TeamId_Schedule: return $"/teams/{TeamId}/schedule";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Teams_TeamId_Schedule,
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
public partial class ScheduleGetResponse : RestApiResponse
{
    public enum ScheduleOperationStatus
    {
        NotStarted,
        Running,
        Completed,
        Failed,
    }

    public bool? Enabled { get; set; }
    public string? Id { get; set; }
    public bool? OfferShiftRequestsEnabled { get; set; }
    public bool? OpenShiftsEnabled { get; set; }
    public ScheduleOperationStatus ProvisionStatus { get; set; }
    public string? ProvisionStatusCode { get; set; }
    public bool? SwapShiftsRequestsEnabled { get; set; }
    public bool? TimeClockEnabled { get; set; }
    public bool? TimeOffRequestsEnabled { get; set; }
    public string? TimeZone { get; set; }
    public OpenShiftChangeRequest[]? OpenShiftChangeRequests { get; set; }
    public OpenShift[]? OpenShifts { get; set; }
    public SchedulingGroup[]? SchedulingGroups { get; set; }
    public Shift[]? Shifts { get; set; }
    public SwapShiftsChangeRequest[]? SwapShiftChangeRequests { get; set; }
    public TimeOff[]? TimesOff { get; set; }
    public TimeOffReason[]? TimeOffReasons { get; set; }
    public TimeOffRequest[]? Timeoffrequest { get; set; }
    public WorkforceIntegration[]? WorkforceIntegrations { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/schedule-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/schedule-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ScheduleGetResponse> ScheduleGetAsync()
    {
        var p = new ScheduleGetParameter();
        return await this.SendAsync<ScheduleGetParameter, ScheduleGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/schedule-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ScheduleGetResponse> ScheduleGetAsync(CancellationToken cancellationToken)
    {
        var p = new ScheduleGetParameter();
        return await this.SendAsync<ScheduleGetParameter, ScheduleGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/schedule-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ScheduleGetResponse> ScheduleGetAsync(ScheduleGetParameter parameter)
    {
        return await this.SendAsync<ScheduleGetParameter, ScheduleGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/schedule-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ScheduleGetResponse> ScheduleGetAsync(ScheduleGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ScheduleGetParameter, ScheduleGetResponse>(parameter, cancellationToken);
    }
}
