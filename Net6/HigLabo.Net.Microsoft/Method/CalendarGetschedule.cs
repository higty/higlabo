using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class CalendarGetscheduleParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Calendar_GetSchedule: return $"/me/calendar/getSchedule";
                    case ApiPath.Users_IdOruserPrincipalName_Calendar_GetSchedule: return $"/users/{IdOrUserPrincipalName}/calendar/getSchedule";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_Calendar_GetSchedule,
            Users_IdOruserPrincipalName_Calendar_GetSchedule,
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
        public Int32? AvailabilityViewInterval { get; set; }
        public DateTimeTimeZone? EndTime { get; set; }
        public String[]? Schedules { get; set; }
        public DateTimeTimeZone? StartTime { get; set; }
    }
    public partial class CalendarGetscheduleResponse : RestApiResponse
    {
        public ScheduleInformation[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/calendar-getschedule?view=graph-rest-1.0
        /// </summary>
        public async Task<CalendarGetscheduleResponse> CalendarGetscheduleAsync()
        {
            var p = new CalendarGetscheduleParameter();
            return await this.SendAsync<CalendarGetscheduleParameter, CalendarGetscheduleResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/calendar-getschedule?view=graph-rest-1.0
        /// </summary>
        public async Task<CalendarGetscheduleResponse> CalendarGetscheduleAsync(CancellationToken cancellationToken)
        {
            var p = new CalendarGetscheduleParameter();
            return await this.SendAsync<CalendarGetscheduleParameter, CalendarGetscheduleResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/calendar-getschedule?view=graph-rest-1.0
        /// </summary>
        public async Task<CalendarGetscheduleResponse> CalendarGetscheduleAsync(CalendarGetscheduleParameter parameter)
        {
            return await this.SendAsync<CalendarGetscheduleParameter, CalendarGetscheduleResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/calendar-getschedule?view=graph-rest-1.0
        /// </summary>
        public async Task<CalendarGetscheduleResponse> CalendarGetscheduleAsync(CalendarGetscheduleParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CalendarGetscheduleParameter, CalendarGetscheduleResponse>(parameter, cancellationToken);
        }
    }
}
