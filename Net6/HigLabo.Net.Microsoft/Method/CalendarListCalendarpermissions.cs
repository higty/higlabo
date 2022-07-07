using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class CalendarListCalendarpermissionsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Users_Id_Calendar_CalendarPermissions,
            Groups_Id_Calendar_CalendarPermissions,
            Users_Id_Events_Id_Calendar_CalendarPermissions,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Users_Id_Calendar_CalendarPermissions: return $"/users/{Id}/calendar/calendarPermissions";
                    case ApiPath.Groups_Id_Calendar_CalendarPermissions: return $"/groups/{Id}/calendar/calendarPermissions";
                    case ApiPath.Users_Id_Events_Id_Calendar_CalendarPermissions: return $"/users/{UsersId}/events/{EventsId}/calendar/calendarPermissions";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
        public string Id { get; set; }
        public string UsersId { get; set; }
        public string EventsId { get; set; }
    }
    public partial class CalendarListCalendarpermissionsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/calendar-list-calendarpermissions?view=graph-rest-1.0
        /// </summary>
        public async Task<CalendarListCalendarpermissionsResponse> CalendarListCalendarpermissionsAsync()
        {
            var p = new CalendarListCalendarpermissionsParameter();
            return await this.SendAsync<CalendarListCalendarpermissionsParameter, CalendarListCalendarpermissionsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/calendar-list-calendarpermissions?view=graph-rest-1.0
        /// </summary>
        public async Task<CalendarListCalendarpermissionsResponse> CalendarListCalendarpermissionsAsync(CancellationToken cancellationToken)
        {
            var p = new CalendarListCalendarpermissionsParameter();
            return await this.SendAsync<CalendarListCalendarpermissionsParameter, CalendarListCalendarpermissionsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/calendar-list-calendarpermissions?view=graph-rest-1.0
        /// </summary>
        public async Task<CalendarListCalendarpermissionsResponse> CalendarListCalendarpermissionsAsync(CalendarListCalendarpermissionsParameter parameter)
        {
            return await this.SendAsync<CalendarListCalendarpermissionsParameter, CalendarListCalendarpermissionsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/calendar-list-calendarpermissions?view=graph-rest-1.0
        /// </summary>
        public async Task<CalendarListCalendarpermissionsResponse> CalendarListCalendarpermissionsAsync(CalendarListCalendarpermissionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CalendarListCalendarpermissionsParameter, CalendarListCalendarpermissionsResponse>(parameter, cancellationToken);
        }
    }
}
