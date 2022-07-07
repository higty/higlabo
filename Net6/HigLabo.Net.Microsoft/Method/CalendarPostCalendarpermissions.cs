using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class CalendarPostCalendarpermissionsParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Id { get; set; }
        public string UsersId { get; set; }
        public string EventsId { get; set; }
    }
    public partial class CalendarPostCalendarpermissionsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/calendar-post-calendarpermissions?view=graph-rest-1.0
        /// </summary>
        public async Task<CalendarPostCalendarpermissionsResponse> CalendarPostCalendarpermissionsAsync()
        {
            var p = new CalendarPostCalendarpermissionsParameter();
            return await this.SendAsync<CalendarPostCalendarpermissionsParameter, CalendarPostCalendarpermissionsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/calendar-post-calendarpermissions?view=graph-rest-1.0
        /// </summary>
        public async Task<CalendarPostCalendarpermissionsResponse> CalendarPostCalendarpermissionsAsync(CancellationToken cancellationToken)
        {
            var p = new CalendarPostCalendarpermissionsParameter();
            return await this.SendAsync<CalendarPostCalendarpermissionsParameter, CalendarPostCalendarpermissionsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/calendar-post-calendarpermissions?view=graph-rest-1.0
        /// </summary>
        public async Task<CalendarPostCalendarpermissionsResponse> CalendarPostCalendarpermissionsAsync(CalendarPostCalendarpermissionsParameter parameter)
        {
            return await this.SendAsync<CalendarPostCalendarpermissionsParameter, CalendarPostCalendarpermissionsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/calendar-post-calendarpermissions?view=graph-rest-1.0
        /// </summary>
        public async Task<CalendarPostCalendarpermissionsResponse> CalendarPostCalendarpermissionsAsync(CalendarPostCalendarpermissionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CalendarPostCalendarpermissionsParameter, CalendarPostCalendarpermissionsResponse>(parameter, cancellationToken);
        }
    }
}
