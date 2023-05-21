using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/calendar-post-calendarpermissions?view=graph-rest-1.0
    /// </summary>
    public partial class CalendarPostCalendarpermissionsParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
    }
    public partial class CalendarPostCalendarpermissionsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/calendar-post-calendarpermissions?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/calendar-post-calendarpermissions?view=graph-rest-1.0
        /// </summary>
        public async Task<CalendarPostCalendarpermissionsResponse> CalendarPostCalendarpermissionsAsync()
        {
            var p = new CalendarPostCalendarpermissionsParameter();
            return await this.SendAsync<CalendarPostCalendarpermissionsParameter, CalendarPostCalendarpermissionsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/calendar-post-calendarpermissions?view=graph-rest-1.0
        /// </summary>
        public async Task<CalendarPostCalendarpermissionsResponse> CalendarPostCalendarpermissionsAsync(CancellationToken cancellationToken)
        {
            var p = new CalendarPostCalendarpermissionsParameter();
            return await this.SendAsync<CalendarPostCalendarpermissionsParameter, CalendarPostCalendarpermissionsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/calendar-post-calendarpermissions?view=graph-rest-1.0
        /// </summary>
        public async Task<CalendarPostCalendarpermissionsResponse> CalendarPostCalendarpermissionsAsync(CalendarPostCalendarpermissionsParameter parameter)
        {
            return await this.SendAsync<CalendarPostCalendarpermissionsParameter, CalendarPostCalendarpermissionsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/calendar-post-calendarpermissions?view=graph-rest-1.0
        /// </summary>
        public async Task<CalendarPostCalendarpermissionsResponse> CalendarPostCalendarpermissionsAsync(CalendarPostCalendarpermissionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CalendarPostCalendarpermissionsParameter, CalendarPostCalendarpermissionsResponse>(parameter, cancellationToken);
        }
    }
}
