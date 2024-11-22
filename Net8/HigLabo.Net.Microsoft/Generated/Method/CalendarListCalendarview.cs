using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/calendar-list-calendarview?view=graph-rest-1.0
/// </summary>
public partial class CalendarListCalendarviewParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? IdOrUserPrincipalName { get; set; }
        public string? Id { get; set; }
        public string? CalendarGroupsId { get; set; }
        public string? CalendarsId { get; set; }
        public string? UsersIdOrUserPrincipalName { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Me_Calendar_CalendarView: return $"/me/calendar/calendarView";
                case ApiPath.Users_IdOrUserPrincipalName_Calendar_CalendarView: return $"/users/{IdOrUserPrincipalName}/calendar/calendarView";
                case ApiPath.Me_Calendars_Id_CalendarView: return $"/me/calendars/{Id}/calendarView";
                case ApiPath.Users_IdOrUserPrincipalName_Calendars_Id_CalendarView: return $"/users/{IdOrUserPrincipalName}/calendars/{Id}/calendarView";
                case ApiPath.Me_CalendarGroups_Id_Calendars_Id_CalendarView: return $"/me/calendarGroups/{CalendarGroupsId}/calendars/{CalendarsId}/calendarView";
                case ApiPath.Users_IdOrUserPrincipalName_CalendarGroups_Id_Calendars_Id_CalendarView: return $"/users/{UsersIdOrUserPrincipalName}/calendarGroups/{CalendarGroupsId}/calendars/{CalendarsId}/calendarView";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Me_Calendar_CalendarView,
        Users_IdOrUserPrincipalName_Calendar_CalendarView,
        Me_Calendars_Id_CalendarView,
        Users_IdOrUserPrincipalName_Calendars_Id_CalendarView,
        Me_CalendarGroups_Id_Calendars_Id_CalendarView,
        Users_IdOrUserPrincipalName_CalendarGroups_Id_Calendars_Id_CalendarView,
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
public partial class CalendarListCalendarviewResponse : RestApiResponse<Event>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/calendar-list-calendarview?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/calendar-list-calendarview?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CalendarListCalendarviewResponse> CalendarListCalendarviewAsync()
    {
        var p = new CalendarListCalendarviewParameter();
        return await this.SendAsync<CalendarListCalendarviewParameter, CalendarListCalendarviewResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/calendar-list-calendarview?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CalendarListCalendarviewResponse> CalendarListCalendarviewAsync(CancellationToken cancellationToken)
    {
        var p = new CalendarListCalendarviewParameter();
        return await this.SendAsync<CalendarListCalendarviewParameter, CalendarListCalendarviewResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/calendar-list-calendarview?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CalendarListCalendarviewResponse> CalendarListCalendarviewAsync(CalendarListCalendarviewParameter parameter)
    {
        return await this.SendAsync<CalendarListCalendarviewParameter, CalendarListCalendarviewResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/calendar-list-calendarview?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CalendarListCalendarviewResponse> CalendarListCalendarviewAsync(CalendarListCalendarviewParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<CalendarListCalendarviewParameter, CalendarListCalendarviewResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/calendar-list-calendarview?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<Event> CalendarListCalendarviewEnumerateAsync(CalendarListCalendarviewParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<CalendarListCalendarviewParameter, CalendarListCalendarviewResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<Event>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
