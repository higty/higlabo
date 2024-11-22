using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/calendargroup-list-calendars?view=graph-rest-1.0
/// </summary>
public partial class CalendarGroupListCalendarsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? IdOrUserPrincipalName { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Me_Calendars: return $"/me/calendars";
                case ApiPath.Users_IdOrUserPrincipalName_Calendars: return $"/users/{IdOrUserPrincipalName}/calendars";
                case ApiPath.Me_CalendarGroups_Id_Calendars: return $"/me/calendarGroups/{Id}/calendars";
                case ApiPath.Users_IdOrUserPrincipalName_CalendarGroups_Id_Calendars: return $"/users/{IdOrUserPrincipalName}/calendarGroups/{Id}/calendars";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Me_Calendars,
        Users_IdOrUserPrincipalName_Calendars,
        Me_CalendarGroups_Id_Calendars,
        Users_IdOrUserPrincipalName_CalendarGroups_Id_Calendars,
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
public partial class CalendarGroupListCalendarsResponse : RestApiResponse<Calendar>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/calendargroup-list-calendars?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/calendargroup-list-calendars?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CalendarGroupListCalendarsResponse> CalendarGroupListCalendarsAsync()
    {
        var p = new CalendarGroupListCalendarsParameter();
        return await this.SendAsync<CalendarGroupListCalendarsParameter, CalendarGroupListCalendarsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/calendargroup-list-calendars?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CalendarGroupListCalendarsResponse> CalendarGroupListCalendarsAsync(CancellationToken cancellationToken)
    {
        var p = new CalendarGroupListCalendarsParameter();
        return await this.SendAsync<CalendarGroupListCalendarsParameter, CalendarGroupListCalendarsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/calendargroup-list-calendars?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CalendarGroupListCalendarsResponse> CalendarGroupListCalendarsAsync(CalendarGroupListCalendarsParameter parameter)
    {
        return await this.SendAsync<CalendarGroupListCalendarsParameter, CalendarGroupListCalendarsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/calendargroup-list-calendars?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CalendarGroupListCalendarsResponse> CalendarGroupListCalendarsAsync(CalendarGroupListCalendarsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<CalendarGroupListCalendarsParameter, CalendarGroupListCalendarsResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/calendargroup-list-calendars?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<Calendar> CalendarGroupListCalendarsEnumerateAsync(CalendarGroupListCalendarsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<CalendarGroupListCalendarsParameter, CalendarGroupListCalendarsResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<Calendar>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
