using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/timeoff-put?view=graph-rest-1.0
/// </summary>
public partial class TimeoffPutParameter : IRestApiParameter
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
    string IRestApiParameter.HttpMethod { get; } = "PUT";
}
public partial class TimeoffPutResponse : RestApiResponse
{
    public DateTimeOffset? CreatedDateTime { get; set; }
    public TimeOffItem? DraftTimeOff { get; set; }
    public string? Id { get; set; }
    public IdentitySet? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedDateTime { get; set; }
    public TimeOffItem? SharedTimeOff { get; set; }
    public string? UserId { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/timeoff-put?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/timeoff-put?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TimeoffPutResponse> TimeoffPutAsync()
    {
        var p = new TimeoffPutParameter();
        return await this.SendAsync<TimeoffPutParameter, TimeoffPutResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/timeoff-put?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TimeoffPutResponse> TimeoffPutAsync(CancellationToken cancellationToken)
    {
        var p = new TimeoffPutParameter();
        return await this.SendAsync<TimeoffPutParameter, TimeoffPutResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/timeoff-put?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TimeoffPutResponse> TimeoffPutAsync(TimeoffPutParameter parameter)
    {
        return await this.SendAsync<TimeoffPutParameter, TimeoffPutResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/timeoff-put?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TimeoffPutResponse> TimeoffPutAsync(TimeoffPutParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<TimeoffPutParameter, TimeoffPutResponse>(parameter, cancellationToken);
    }
}
