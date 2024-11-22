using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/timeoffrequest-decline?view=graph-rest-1.0
/// </summary>
public partial class TimeoffRequestDeclineParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? TeamId { get; set; }
        public string? TimeOffRequestId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Teams_TeamId_Schedule_TimeOffRequests_TimeOffRequestId_Decline: return $"/teams/{TeamId}/schedule/timeOffRequests/{TimeOffRequestId}/decline";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Teams_TeamId_Schedule_TimeOffRequests_TimeOffRequestId_Decline,
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
    public string? Message { get; set; }
}
public partial class TimeoffRequestDeclineResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/timeoffrequest-decline?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/timeoffrequest-decline?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TimeoffRequestDeclineResponse> TimeoffRequestDeclineAsync()
    {
        var p = new TimeoffRequestDeclineParameter();
        return await this.SendAsync<TimeoffRequestDeclineParameter, TimeoffRequestDeclineResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/timeoffrequest-decline?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TimeoffRequestDeclineResponse> TimeoffRequestDeclineAsync(CancellationToken cancellationToken)
    {
        var p = new TimeoffRequestDeclineParameter();
        return await this.SendAsync<TimeoffRequestDeclineParameter, TimeoffRequestDeclineResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/timeoffrequest-decline?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TimeoffRequestDeclineResponse> TimeoffRequestDeclineAsync(TimeoffRequestDeclineParameter parameter)
    {
        return await this.SendAsync<TimeoffRequestDeclineParameter, TimeoffRequestDeclineResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/timeoffrequest-decline?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TimeoffRequestDeclineResponse> TimeoffRequestDeclineAsync(TimeoffRequestDeclineParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<TimeoffRequestDeclineParameter, TimeoffRequestDeclineResponse>(parameter, cancellationToken);
    }
}
