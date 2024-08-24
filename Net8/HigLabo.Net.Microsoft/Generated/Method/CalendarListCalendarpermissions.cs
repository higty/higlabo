using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/calendar-list-calendarpermissions?view=graph-rest-1.0
    /// </summary>
    public partial class CalendarListCalendarPermissionsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }
            public string? UsersId { get; set; }
            public string? EventsId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Users_Id_Calendar_CalendarPermissions: return $"/users/{Id}/calendar/calendarPermissions";
                    case ApiPath.Groups_Id_Calendar_CalendarPermissions: return $"/groups/{Id}/calendar/calendarPermissions";
                    case ApiPath.Users_Id_Events_Id_Calendar_CalendarPermissions: return $"/users/{UsersId}/events/{EventsId}/calendar/calendarPermissions";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Users_Id_Calendar_CalendarPermissions,
            Groups_Id_Calendar_CalendarPermissions,
            Users_Id_Events_Id_Calendar_CalendarPermissions,
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
    public partial class CalendarListCalendarPermissionsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/calendar-list-calendarpermissions?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/calendar-list-calendarpermissions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<CalendarListCalendarPermissionsResponse> CalendarListCalendarPermissionsAsync()
        {
            var p = new CalendarListCalendarPermissionsParameter();
            return await this.SendAsync<CalendarListCalendarPermissionsParameter, CalendarListCalendarPermissionsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/calendar-list-calendarpermissions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<CalendarListCalendarPermissionsResponse> CalendarListCalendarPermissionsAsync(CancellationToken cancellationToken)
        {
            var p = new CalendarListCalendarPermissionsParameter();
            return await this.SendAsync<CalendarListCalendarPermissionsParameter, CalendarListCalendarPermissionsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/calendar-list-calendarpermissions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<CalendarListCalendarPermissionsResponse> CalendarListCalendarPermissionsAsync(CalendarListCalendarPermissionsParameter parameter)
        {
            return await this.SendAsync<CalendarListCalendarPermissionsParameter, CalendarListCalendarPermissionsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/calendar-list-calendarpermissions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<CalendarListCalendarPermissionsResponse> CalendarListCalendarPermissionsAsync(CalendarListCalendarPermissionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CalendarListCalendarPermissionsParameter, CalendarListCalendarPermissionsResponse>(parameter, cancellationToken);
        }
    }
}
