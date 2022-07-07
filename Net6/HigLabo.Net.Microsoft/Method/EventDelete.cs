using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EventDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Me_Events_Id,
            Users_IdOrUserPrincipalName_Events_Id,
            Groups_Id_Events_Id,
            Me_Calendar_Events_Id,
            Users_IdOrUserPrincipalName_Calendar_Events_Id,
            Groups_Id_Calendar_Events_Id_,
            Me_Calendars_Id_Events_Id,
            Users_IdOrUserPrincipalName_Calendars_Id_Events_Id,
            Me_Calendargroups_Id_Calendars_Id_Events_Id,
            Users_IdOrUserPrincipalName_Calendargroups_Id_Calendars_Id_Events_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Events_Id: return $"/me/events/{Id}";
                    case ApiPath.Users_IdOrUserPrincipalName_Events_Id: return $"/users/{IdOrUserPrincipalName}/events/{Id}";
                    case ApiPath.Groups_Id_Events_Id: return $"/groups/{GroupsId}/events/{EventsId}";
                    case ApiPath.Me_Calendar_Events_Id: return $"/me/calendar/events/{Id}";
                    case ApiPath.Users_IdOrUserPrincipalName_Calendar_Events_Id: return $"/users/{IdOrUserPrincipalName}/calendar/events/{Id}";
                    case ApiPath.Groups_Id_Calendar_Events_Id_: return $"/groups/{GroupsId}/calendar/events/{EventsId}/";
                    case ApiPath.Me_Calendars_Id_Events_Id: return $"/me/calendars/{CalendarsId}/events/{EventsId}";
                    case ApiPath.Users_IdOrUserPrincipalName_Calendars_Id_Events_Id: return $"/users/{UsersIdOrUserPrincipalName}/calendars/{CalendarsId}/events/{EventsId}";
                    case ApiPath.Me_Calendargroups_Id_Calendars_Id_Events_Id: return $"/me/calendargroups/{CalendargroupsId}/calendars/{CalendarsId}/events/{EventsId}";
                    case ApiPath.Users_IdOrUserPrincipalName_Calendargroups_Id_Calendars_Id_Events_Id: return $"/users/{UsersIdOrUserPrincipalName}/calendargroups/{CalendargroupsId}/calendars/{CalendarsId}/events/{EventsId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string Id { get; set; }
        public string IdOrUserPrincipalName { get; set; }
        public string GroupsId { get; set; }
        public string EventsId { get; set; }
        public string CalendarsId { get; set; }
        public string UsersIdOrUserPrincipalName { get; set; }
        public string CalendargroupsId { get; set; }
    }
    public partial class EventDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/event-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<EventDeleteResponse> EventDeleteAsync()
        {
            var p = new EventDeleteParameter();
            return await this.SendAsync<EventDeleteParameter, EventDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/event-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<EventDeleteResponse> EventDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new EventDeleteParameter();
            return await this.SendAsync<EventDeleteParameter, EventDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/event-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<EventDeleteResponse> EventDeleteAsync(EventDeleteParameter parameter)
        {
            return await this.SendAsync<EventDeleteParameter, EventDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/event-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<EventDeleteResponse> EventDeleteAsync(EventDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EventDeleteParameter, EventDeleteResponse>(parameter, cancellationToken);
        }
    }
}
