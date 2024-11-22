using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/timeoffreason-delete?view=graph-rest-1.0
/// </summary>
public partial class TimeoffReasonDeleteParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? TeamId { get; set; }
        public string? TimeOffReasonId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Teams_TeamId_Schedule_TimeOffReasons_TimeOffReasonId: return $"/teams/{TeamId}/schedule/timeOffReasons/{TimeOffReasonId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Teams_TeamId_Schedule_TimeOffReasons_TimeOffReasonId,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "DELETE";
}
public partial class TimeoffReasonDeleteResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/timeoffreason-delete?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/timeoffreason-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TimeoffReasonDeleteResponse> TimeoffReasonDeleteAsync()
    {
        var p = new TimeoffReasonDeleteParameter();
        return await this.SendAsync<TimeoffReasonDeleteParameter, TimeoffReasonDeleteResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/timeoffreason-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TimeoffReasonDeleteResponse> TimeoffReasonDeleteAsync(CancellationToken cancellationToken)
    {
        var p = new TimeoffReasonDeleteParameter();
        return await this.SendAsync<TimeoffReasonDeleteParameter, TimeoffReasonDeleteResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/timeoffreason-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TimeoffReasonDeleteResponse> TimeoffReasonDeleteAsync(TimeoffReasonDeleteParameter parameter)
    {
        return await this.SendAsync<TimeoffReasonDeleteParameter, TimeoffReasonDeleteResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/timeoffreason-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TimeoffReasonDeleteResponse> TimeoffReasonDeleteAsync(TimeoffReasonDeleteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<TimeoffReasonDeleteParameter, TimeoffReasonDeleteResponse>(parameter, cancellationToken);
    }
}
