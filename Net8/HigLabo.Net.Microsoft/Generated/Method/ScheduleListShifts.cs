using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/schedule-list-shifts?view=graph-rest-1.0
/// </summary>
public partial class ScheduleListShiftsParameter : IRestApiParameter, IQueryParameterProperty
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

    public enum Field
    {
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
public partial class ScheduleListShiftsResponse : RestApiResponse<Shift>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/schedule-list-shifts?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/schedule-list-shifts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ScheduleListShiftsResponse> ScheduleListShiftsAsync()
    {
        var p = new ScheduleListShiftsParameter();
        return await this.SendAsync<ScheduleListShiftsParameter, ScheduleListShiftsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/schedule-list-shifts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ScheduleListShiftsResponse> ScheduleListShiftsAsync(CancellationToken cancellationToken)
    {
        var p = new ScheduleListShiftsParameter();
        return await this.SendAsync<ScheduleListShiftsParameter, ScheduleListShiftsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/schedule-list-shifts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ScheduleListShiftsResponse> ScheduleListShiftsAsync(ScheduleListShiftsParameter parameter)
    {
        return await this.SendAsync<ScheduleListShiftsParameter, ScheduleListShiftsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/schedule-list-shifts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ScheduleListShiftsResponse> ScheduleListShiftsAsync(ScheduleListShiftsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ScheduleListShiftsParameter, ScheduleListShiftsResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/schedule-list-shifts?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<Shift> ScheduleListShiftsEnumerateAsync(ScheduleListShiftsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<ScheduleListShiftsParameter, ScheduleListShiftsResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<Shift>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
