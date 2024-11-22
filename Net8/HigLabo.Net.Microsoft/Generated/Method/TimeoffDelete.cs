using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/timeoff-delete?view=graph-rest-1.0
/// </summary>
public partial class TimeoffDeleteParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? TeamId { get; set; }
        public string? TimeOffId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Teams_TeamId_Schedule_TimesOff_TimeOffId: return $"/teams/{TeamId}/schedule/timesOff/{TimeOffId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Teams_TeamId_Schedule_TimesOff_TimeOffId,
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
public partial class TimeoffDeleteResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/timeoff-delete?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/timeoff-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TimeoffDeleteResponse> TimeoffDeleteAsync()
    {
        var p = new TimeoffDeleteParameter();
        return await this.SendAsync<TimeoffDeleteParameter, TimeoffDeleteResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/timeoff-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TimeoffDeleteResponse> TimeoffDeleteAsync(CancellationToken cancellationToken)
    {
        var p = new TimeoffDeleteParameter();
        return await this.SendAsync<TimeoffDeleteParameter, TimeoffDeleteResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/timeoff-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TimeoffDeleteResponse> TimeoffDeleteAsync(TimeoffDeleteParameter parameter)
    {
        return await this.SendAsync<TimeoffDeleteParameter, TimeoffDeleteResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/timeoff-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TimeoffDeleteResponse> TimeoffDeleteAsync(TimeoffDeleteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<TimeoffDeleteParameter, TimeoffDeleteResponse>(parameter, cancellationToken);
    }
}
