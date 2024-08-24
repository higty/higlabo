using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/calendar-list-events?view=graph-rest-1.0
    /// </summary>
    public partial class CalendarListEventsParameter : IRestApiParameter, IQueryParameterProperty
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
                    case ApiPath.Me_Calendar_Events: return $"/me/calendar/events";
                    case ApiPath.Users_IdOrUserPrincipalName_Calendar_Events: return $"/users/{IdOrUserPrincipalName}/calendar/events";
                    case ApiPath.Groups_Id_Calendar_Events: return $"/groups/{Id}/calendar/events";
                    case ApiPath.Me_Calendars_Id_Events: return $"/me/calendars/{Id}/events";
                    case ApiPath.Users_IdOrUserPrincipalName_Calendars_Id_Events: return $"/users/{IdOrUserPrincipalName}/calendars/{Id}/events";
                    case ApiPath.Me_CalendarGroups_Id_Calendars_Id_Events: return $"/me/calendarGroups/{CalendarGroupsId}/calendars/{CalendarsId}/events";
                    case ApiPath.Users_IdOrUserPrincipalName_CalendarGroups_Id_Calendars_Id_Events: return $"/users/{UsersIdOrUserPrincipalName}/calendarGroups/{CalendarGroupsId}/calendars/{CalendarsId}/events";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Calendar_Events,
            Users_IdOrUserPrincipalName_Calendar_Events,
            Groups_Id_Calendar_Events,
            Me_Calendars_Id_Events,
            Users_IdOrUserPrincipalName_Calendars_Id_Events,
            Me_CalendarGroups_Id_Calendars_Id_Events,
            Users_IdOrUserPrincipalName_CalendarGroups_Id_Calendars_Id_Events,
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
    public partial class CalendarListEventsResponse : RestApiResponse<Event>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/calendar-list-events?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/calendar-list-events?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<CalendarListEventsResponse> CalendarListEventsAsync()
        {
            var p = new CalendarListEventsParameter();
            return await this.SendAsync<CalendarListEventsParameter, CalendarListEventsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/calendar-list-events?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<CalendarListEventsResponse> CalendarListEventsAsync(CancellationToken cancellationToken)
        {
            var p = new CalendarListEventsParameter();
            return await this.SendAsync<CalendarListEventsParameter, CalendarListEventsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/calendar-list-events?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<CalendarListEventsResponse> CalendarListEventsAsync(CalendarListEventsParameter parameter)
        {
            return await this.SendAsync<CalendarListEventsParameter, CalendarListEventsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/calendar-list-events?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<CalendarListEventsResponse> CalendarListEventsAsync(CalendarListEventsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CalendarListEventsParameter, CalendarListEventsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/calendar-list-events?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<Event> CalendarListEventsEnumerateAsync(CalendarListEventsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<CalendarListEventsParameter, CalendarListEventsResponse>(parameter, cancellationToken);
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
}
