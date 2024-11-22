using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/timeoffrequest-get?view=graph-rest-1.0
/// </summary>
public partial class TimeoffRequestGetParameter : IRestApiParameter, IQueryParameterProperty
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
                case ApiPath.Teams_TeamId_Schedule_TimeOffRequests_TimeOffRequestId: return $"/teams/{TeamId}/schedule/timeOffRequests/{TimeOffRequestId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Teams_TeamId_Schedule_TimeOffRequests_TimeOffRequestId,
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
public partial class TimeoffRequestGetResponse : RestApiResponse
{
    public DateTimeOffset? EndDateTime { get; set; }
    public DateTimeOffset? StartDateTime { get; set; }
    public string? TimeOffReasonId { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/timeoffrequest-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/timeoffrequest-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TimeoffRequestGetResponse> TimeoffRequestGetAsync()
    {
        var p = new TimeoffRequestGetParameter();
        return await this.SendAsync<TimeoffRequestGetParameter, TimeoffRequestGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/timeoffrequest-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TimeoffRequestGetResponse> TimeoffRequestGetAsync(CancellationToken cancellationToken)
    {
        var p = new TimeoffRequestGetParameter();
        return await this.SendAsync<TimeoffRequestGetParameter, TimeoffRequestGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/timeoffrequest-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TimeoffRequestGetResponse> TimeoffRequestGetAsync(TimeoffRequestGetParameter parameter)
    {
        return await this.SendAsync<TimeoffRequestGetParameter, TimeoffRequestGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/timeoffrequest-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TimeoffRequestGetResponse> TimeoffRequestGetAsync(TimeoffRequestGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<TimeoffRequestGetParameter, TimeoffRequestGetResponse>(parameter, cancellationToken);
    }
}
