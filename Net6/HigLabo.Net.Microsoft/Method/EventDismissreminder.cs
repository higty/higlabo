using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EventDismissreminderParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Me_Events_Id_DismissReminder,
            Users_IdOrUserPrincipalName_Events_Id_DismissReminder,
            Me_Calendar_Events_Id_DismissReminder,
            Users_IdOrUserPrincipalName_Calendar_Events_Id_DismissReminder,
            Me_Calendars_Id_Events_Id_DismissReminder,
            Users_IdOrUserPrincipalName_Calendars_Id_Events_Id_DismissReminder,
            Me_Calendargroups_Id_Calendars_Id_Events_Id_DismissReminder,
            Users_IdOrUserPrincipalName_Calendargroups_Id_Calendars_Id_Events_Id_DismissReminder,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Events_Id_DismissReminder: return $"/me/events/{Id}/dismissReminder";
                    case ApiPath.Users_IdOrUserPrincipalName_Events_Id_DismissReminder: return $"/users/{IdOrUserPrincipalName}/events/{Id}/dismissReminder";
                    case ApiPath.Me_Calendar_Events_Id_DismissReminder: return $"/me/calendar/events/{Id}/dismissReminder";
                    case ApiPath.Users_IdOrUserPrincipalName_Calendar_Events_Id_DismissReminder: return $"/users/{IdOrUserPrincipalName}/calendar/events/{Id}/dismissReminder";
                    case ApiPath.Me_Calendars_Id_Events_Id_DismissReminder: return $"/me/calendars/{CalendarsId}/events/{EventsId}/dismissReminder";
                    case ApiPath.Users_IdOrUserPrincipalName_Calendars_Id_Events_Id_DismissReminder: return $"/users/{UsersIdOrUserPrincipalName}/calendars/{CalendarsId}/events/{EventsId}/dismissReminder";
                    case ApiPath.Me_Calendargroups_Id_Calendars_Id_Events_Id_DismissReminder: return $"/me/calendargroups/{CalendargroupsId}/calendars/{CalendarsId}/events/{EventsId}/dismissReminder";
                    case ApiPath.Users_IdOrUserPrincipalName_Calendargroups_Id_Calendars_Id_Events_Id_DismissReminder: return $"/users/{UsersIdOrUserPrincipalName}/calendargroups/{CalendargroupsId}/calendars/{CalendarsId}/events/{EventsId}/dismissReminder";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Id { get; set; }
        public string IdOrUserPrincipalName { get; set; }
        public string CalendarsId { get; set; }
        public string EventsId { get; set; }
        public string UsersIdOrUserPrincipalName { get; set; }
        public string CalendargroupsId { get; set; }
    }
    public partial class EventDismissreminderResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/event-dismissreminder?view=graph-rest-1.0
        /// </summary>
        public async Task<EventDismissreminderResponse> EventDismissreminderAsync()
        {
            var p = new EventDismissreminderParameter();
            return await this.SendAsync<EventDismissreminderParameter, EventDismissreminderResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/event-dismissreminder?view=graph-rest-1.0
        /// </summary>
        public async Task<EventDismissreminderResponse> EventDismissreminderAsync(CancellationToken cancellationToken)
        {
            var p = new EventDismissreminderParameter();
            return await this.SendAsync<EventDismissreminderParameter, EventDismissreminderResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/event-dismissreminder?view=graph-rest-1.0
        /// </summary>
        public async Task<EventDismissreminderResponse> EventDismissreminderAsync(EventDismissreminderParameter parameter)
        {
            return await this.SendAsync<EventDismissreminderParameter, EventDismissreminderResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/event-dismissreminder?view=graph-rest-1.0
        /// </summary>
        public async Task<EventDismissreminderResponse> EventDismissreminderAsync(EventDismissreminderParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EventDismissreminderParameter, EventDismissreminderResponse>(parameter, cancellationToken);
        }
    }
}
