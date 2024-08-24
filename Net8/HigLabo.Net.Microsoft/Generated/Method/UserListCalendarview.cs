using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-calendarview?view=graph-rest-1.0
    /// </summary>
    public partial class UserListCalendarviewParameter : IRestApiParameter, IQueryParameterProperty
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
                    case ApiPath.Users_IdOrUserPrincipalName_CalendarView: return $"/users/{IdOrUserPrincipalName}/calendarView";
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
            Users_IdOrUserPrincipalName_CalendarView,
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
    public partial class UserListCalendarviewResponse : RestApiResponse<Event>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-calendarview?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-calendarview?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListCalendarviewResponse> UserListCalendarviewAsync()
        {
            var p = new UserListCalendarviewParameter();
            return await this.SendAsync<UserListCalendarviewParameter, UserListCalendarviewResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-calendarview?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListCalendarviewResponse> UserListCalendarviewAsync(CancellationToken cancellationToken)
        {
            var p = new UserListCalendarviewParameter();
            return await this.SendAsync<UserListCalendarviewParameter, UserListCalendarviewResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-calendarview?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListCalendarviewResponse> UserListCalendarviewAsync(UserListCalendarviewParameter parameter)
        {
            return await this.SendAsync<UserListCalendarviewParameter, UserListCalendarviewResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-calendarview?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListCalendarviewResponse> UserListCalendarviewAsync(UserListCalendarviewParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserListCalendarviewParameter, UserListCalendarviewResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-calendarview?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<Event> UserListCalendarviewEnumerateAsync(UserListCalendarviewParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<UserListCalendarviewParameter, UserListCalendarviewResponse>(parameter, cancellationToken);
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
