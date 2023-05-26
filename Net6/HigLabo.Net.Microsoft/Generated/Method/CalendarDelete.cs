using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/calendar-delete?view=graph-rest-1.0
    /// </summary>
    public partial class CalendarDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }
            public string? IdOrUserPrincipalName { get; set; }
            public string? CalendarGroupsId { get; set; }
            public string? CalendarsId { get; set; }
            public string? UsersIdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Calendars_Id: return $"/me/calendars/{Id}";
                    case ApiPath.Users_IdOrUserPrincipalName_Calendars_Id: return $"/users/{IdOrUserPrincipalName}/calendars/{Id}";
                    case ApiPath.Me_CalendarGroups_Id_Calendars_Id: return $"/me/calendarGroups/{CalendarGroupsId}/calendars/{CalendarsId}";
                    case ApiPath.Users_IdOrUserPrincipalName_CalendarGroups_Id_Calendars_Id: return $"/users/{UsersIdOrUserPrincipalName}/calendarGroups/{CalendarGroupsId}/calendars/{CalendarsId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_Calendars_Id,
            Users_IdOrUserPrincipalName_Calendars_Id,
            Me_CalendarGroups_Id_Calendars_Id,
            Users_IdOrUserPrincipalName_CalendarGroups_Id_Calendars_Id,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class CalendarDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/calendar-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/calendar-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<CalendarDeleteResponse> CalendarDeleteAsync()
        {
            var p = new CalendarDeleteParameter();
            return await this.SendAsync<CalendarDeleteParameter, CalendarDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/calendar-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<CalendarDeleteResponse> CalendarDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new CalendarDeleteParameter();
            return await this.SendAsync<CalendarDeleteParameter, CalendarDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/calendar-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<CalendarDeleteResponse> CalendarDeleteAsync(CalendarDeleteParameter parameter)
        {
            return await this.SendAsync<CalendarDeleteParameter, CalendarDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/calendar-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<CalendarDeleteResponse> CalendarDeleteAsync(CalendarDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CalendarDeleteParameter, CalendarDeleteResponse>(parameter, cancellationToken);
        }
    }
}
