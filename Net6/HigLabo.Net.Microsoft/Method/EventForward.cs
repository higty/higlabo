using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EventForwardParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }
            public string? IdOrUserPrincipalName { get; set; }
            public string? GroupsId { get; set; }
            public string? EventsId { get; set; }
            public string? CalendarsId { get; set; }
            public string? UsersIdOrUserPrincipalName { get; set; }
            public string? CalendargroupsId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Events_Id_Forward: return $"/me/events/{Id}/forward";
                    case ApiPath.Users_IdOrUserPrincipalName_Events_Id_Forward: return $"/users/{IdOrUserPrincipalName}/events/{Id}/forward";
                    case ApiPath.Groups_Id_Events_Id_Forward: return $"/groups/{GroupsId}/events/{EventsId}/forward";
                    case ApiPath.Me_Calendar_Events_Id_Forward: return $"/me/calendar/events/{Id}/forward";
                    case ApiPath.Users_IdOrUserPrincipalName_Calendar_Events_Id_Forward: return $"/users/{IdOrUserPrincipalName}/calendar/events/{Id}/forward";
                    case ApiPath.Groups_Id_Calendar_Events_Id_Forward: return $"/groups/{GroupsId}/calendar/events/{EventsId}/forward";
                    case ApiPath.Me_Calendars_Id_Events_Id_Forward: return $"/me/calendars/{CalendarsId}/events/{EventsId}/forward";
                    case ApiPath.Users_IdOrUserPrincipalName_Calendars_Id_Events_Id_Forward: return $"/users/{UsersIdOrUserPrincipalName}/calendars/{CalendarsId}/events/{EventsId}/forward";
                    case ApiPath.Me_Calendargroups_Id_Calendars_Id_Events_Id_Forward: return $"/me/calendargroups/{CalendargroupsId}/calendars/{CalendarsId}/events/{EventsId}/forward";
                    case ApiPath.Users_IdOrUserPrincipalName_Calendargroups_Id_Calendars_Id_Events_Id_Forward: return $"/users/{UsersIdOrUserPrincipalName}/calendargroups/{CalendargroupsId}/calendars/{CalendarsId}/events/{EventsId}/forward";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_Events_Id_Forward,
            Users_IdOrUserPrincipalName_Events_Id_Forward,
            Groups_Id_Events_Id_Forward,
            Me_Calendar_Events_Id_Forward,
            Users_IdOrUserPrincipalName_Calendar_Events_Id_Forward,
            Groups_Id_Calendar_Events_Id_Forward,
            Me_Calendars_Id_Events_Id_Forward,
            Users_IdOrUserPrincipalName_Calendars_Id_Events_Id_Forward,
            Me_Calendargroups_Id_Calendars_Id_Events_Id_Forward,
            Users_IdOrUserPrincipalName_Calendargroups_Id_Calendars_Id_Events_Id_Forward,
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
        public Recipient[]? ToRecipients { get; set; }
    }
    public partial class EventForwardResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/event-forward?view=graph-rest-1.0
        /// </summary>
        public async Task<EventForwardResponse> EventForwardAsync()
        {
            var p = new EventForwardParameter();
            return await this.SendAsync<EventForwardParameter, EventForwardResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/event-forward?view=graph-rest-1.0
        /// </summary>
        public async Task<EventForwardResponse> EventForwardAsync(CancellationToken cancellationToken)
        {
            var p = new EventForwardParameter();
            return await this.SendAsync<EventForwardParameter, EventForwardResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/event-forward?view=graph-rest-1.0
        /// </summary>
        public async Task<EventForwardResponse> EventForwardAsync(EventForwardParameter parameter)
        {
            return await this.SendAsync<EventForwardParameter, EventForwardResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/event-forward?view=graph-rest-1.0
        /// </summary>
        public async Task<EventForwardResponse> EventForwardAsync(EventForwardParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EventForwardParameter, EventForwardResponse>(parameter, cancellationToken);
        }
    }
}
