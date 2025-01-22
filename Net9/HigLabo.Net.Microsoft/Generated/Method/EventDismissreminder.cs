using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/event-dismissreminder?view=graph-rest-1.0
/// </summary>
public partial class EventDismissreminderParameter : IRestApiParameter
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
                case ApiPath.Me_Events_Id_DismissReminder: return $"/me/events/{Id}/dismissReminder";
                case ApiPath.Users_IdOrUserPrincipalName_Events_Id_DismissReminder: return $"/users/{IdOrUserPrincipalName}/events/{Id}/dismissReminder";
                case ApiPath.Me_Calendar_Events_Id_DismissReminder: return $"/me/calendar/events/{Id}/dismissReminder";
                case ApiPath.Users_IdOrUserPrincipalName_Calendar_Events_Id_DismissReminder: return $"/users/{IdOrUserPrincipalName}/calendar/events/{Id}/dismissReminder";
                case ApiPath.Me_Calendars_Id_Events_Id_DismissReminder: return $"/me/calendars/{CalendarsId}/events/{EventsId}/dismissReminder";
                case ApiPath.Users_IdOrUserPrincipalName_Calendars_Id_Events_Id_DismissReminder: return $"/users/{UsersIdOrUserPrincipalName}/calendars/{CalendarsId}/events/{EventsId}/dismissReminder";
                case ApiPath.Me_CalendarGroups_Id_Calendars_Id_Events_Id_DismissReminder: return $"/me/calendarGroups/{CalendarGroupsId}/calendars/{CalendarsId}/events/{EventsId}/dismissReminder";
                case ApiPath.Users_IdOrUserPrincipalName_CalendarGroups_Id_Calendars_Id_Events_Id_DismissReminder: return $"/users/{UsersIdOrUserPrincipalName}/calendarGroups/{CalendarGroupsId}/calendars/{CalendarsId}/events/{EventsId}/dismissReminder";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Me_Events_Id_DismissReminder,
        Users_IdOrUserPrincipalName_Events_Id_DismissReminder,
        Me_Calendar_Events_Id_DismissReminder,
        Users_IdOrUserPrincipalName_Calendar_Events_Id_DismissReminder,
        Me_Calendars_Id_Events_Id_DismissReminder,
        Users_IdOrUserPrincipalName_Calendars_Id_Events_Id_DismissReminder,
        Me_CalendarGroups_Id_Calendars_Id_Events_Id_DismissReminder,
        Users_IdOrUserPrincipalName_CalendarGroups_Id_Calendars_Id_Events_Id_DismissReminder,
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
public partial class EventDismissreminderResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/event-dismissreminder?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/event-dismissreminder?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EventDismissreminderResponse> EventDismissreminderAsync()
    {
        var p = new EventDismissreminderParameter();
        return await this.SendAsync<EventDismissreminderParameter, EventDismissreminderResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/event-dismissreminder?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EventDismissreminderResponse> EventDismissreminderAsync(CancellationToken cancellationToken)
    {
        var p = new EventDismissreminderParameter();
        return await this.SendAsync<EventDismissreminderParameter, EventDismissreminderResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/event-dismissreminder?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EventDismissreminderResponse> EventDismissreminderAsync(EventDismissreminderParameter parameter)
    {
        return await this.SendAsync<EventDismissreminderParameter, EventDismissreminderResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/event-dismissreminder?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EventDismissreminderResponse> EventDismissreminderAsync(EventDismissreminderParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<EventDismissreminderParameter, EventDismissreminderResponse>(parameter, cancellationToken);
    }
}
