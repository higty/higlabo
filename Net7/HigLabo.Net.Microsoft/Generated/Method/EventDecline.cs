using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/event-decline?view=graph-rest-1.0
    /// </summary>
    public partial class EventDeclineParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }
            public string? IdOrUserPrincipalName { get; set; }
            public string? CalendarsId { get; set; }
            public string? EventsId { get; set; }
            public string? UsersIdOrUserPrincipalName { get; set; }
            public string? CalendarGroupsId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Events_Id_Decline: return $"/me/events/{Id}/decline";
                    case ApiPath.Users_IdOrUserPrincipalName_Events_Id_Decline: return $"/users/{IdOrUserPrincipalName}/events/{Id}/decline";
                    case ApiPath.Me_Calendar_Events_Id_Decline: return $"/me/calendar/events/{Id}/decline";
                    case ApiPath.Users_IdOrUserPrincipalName_Calendar_Events_Id_Decline: return $"/users/{IdOrUserPrincipalName}/calendar/events/{Id}/decline";
                    case ApiPath.Me_Calendars_Id_Events_Id_Decline: return $"/me/calendars/{CalendarsId}/events/{EventsId}/decline";
                    case ApiPath.Users_IdOrUserPrincipalName_Calendars_Id_Events_Id_Decline: return $"/users/{UsersIdOrUserPrincipalName}/calendars/{CalendarsId}/events/{EventsId}/decline";
                    case ApiPath.Me_CalendarGroups_Id_Calendars_Id_Events_Id_Decline: return $"/me/calendarGroups/{CalendarGroupsId}/calendars/{CalendarsId}/events/{EventsId}/decline";
                    case ApiPath.Users_IdOrUserPrincipalName_CalendarGroups_Id_Calendars_Id_Events_Id_Decline: return $"/users/{UsersIdOrUserPrincipalName}/calendarGroups/{CalendarGroupsId}/calendars/{CalendarsId}/events/{EventsId}/decline";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_Events_Id_Decline,
            Users_IdOrUserPrincipalName_Events_Id_Decline,
            Me_Calendar_Events_Id_Decline,
            Users_IdOrUserPrincipalName_Calendar_Events_Id_Decline,
            Me_Calendars_Id_Events_Id_Decline,
            Users_IdOrUserPrincipalName_Calendars_Id_Events_Id_Decline,
            Me_CalendarGroups_Id_Calendars_Id_Events_Id_Decline,
            Users_IdOrUserPrincipalName_CalendarGroups_Id_Calendars_Id_Events_Id_Decline,
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
        public string? Comment { get; set; }
        public TimeSlot? ProposedNewTime { get; set; }
        public bool? SendResponse { get; set; }
    }
    public partial class EventDeclineResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/event-decline?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/event-decline?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EventDeclineResponse> EventDeclineAsync()
        {
            var p = new EventDeclineParameter();
            return await this.SendAsync<EventDeclineParameter, EventDeclineResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/event-decline?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EventDeclineResponse> EventDeclineAsync(CancellationToken cancellationToken)
        {
            var p = new EventDeclineParameter();
            return await this.SendAsync<EventDeclineParameter, EventDeclineResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/event-decline?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EventDeclineResponse> EventDeclineAsync(EventDeclineParameter parameter)
        {
            return await this.SendAsync<EventDeclineParameter, EventDeclineResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/event-decline?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EventDeclineResponse> EventDeclineAsync(EventDeclineParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EventDeclineParameter, EventDeclineResponse>(parameter, cancellationToken);
        }
    }
}
