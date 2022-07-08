using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class CalendarpermissionUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string UsersId { get; set; }
            public string CalendarPermissionsId { get; set; }
            public string GroupsId { get; set; }
            public string EventsId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Users_Id_Calendar_CalendarPermissions_Id: return $"/users/{UsersId}/calendar/calendarPermissions/{CalendarPermissionsId}";
                    case ApiPath.Groups_Id_Calendar_CalendarPermissions_Id: return $"/groups/{GroupsId}/calendar/calendarPermissions/{CalendarPermissionsId}";
                    case ApiPath.Users_Id_Events_Id_Calendar_CalendarPermissions_Id: return $"/users/{UsersId}/events/{EventsId}/calendar/calendarPermissions/{CalendarPermissionsId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Users_Id_Calendar_CalendarPermissions_Id,
            Groups_Id_Calendar_CalendarPermissions_Id,
            Users_Id_Events_Id_Calendar_CalendarPermissions_Id,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public CalendarPermission? Role { get; set; }
    }
    public partial class CalendarpermissionUpdateResponse : RestApiResponse
    {
        public enum CalendarPermissionCalendarRoleType
        {
            None,
            FreeBusyRead,
            LimitedRead,
            Read,
            Write,
            DelegateWithoutPrivateEventAccess,
            DelegateWithPrivateEventAccess,
            Custom,
        }

        public CalendarPermissionCalendarRoleType AllowedRoles { get; set; }
        public EmailAddress? EmailAddress { get; set; }
        public string? Id { get; set; }
        public bool? IsInsideOrganization { get; set; }
        public bool? IsRemovable { get; set; }
        public CalendarRoleType? Role { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/calendarpermission-update?view=graph-rest-1.0
        /// </summary>
        public async Task<CalendarpermissionUpdateResponse> CalendarpermissionUpdateAsync()
        {
            var p = new CalendarpermissionUpdateParameter();
            return await this.SendAsync<CalendarpermissionUpdateParameter, CalendarpermissionUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/calendarpermission-update?view=graph-rest-1.0
        /// </summary>
        public async Task<CalendarpermissionUpdateResponse> CalendarpermissionUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new CalendarpermissionUpdateParameter();
            return await this.SendAsync<CalendarpermissionUpdateParameter, CalendarpermissionUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/calendarpermission-update?view=graph-rest-1.0
        /// </summary>
        public async Task<CalendarpermissionUpdateResponse> CalendarpermissionUpdateAsync(CalendarpermissionUpdateParameter parameter)
        {
            return await this.SendAsync<CalendarpermissionUpdateParameter, CalendarpermissionUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/calendarpermission-update?view=graph-rest-1.0
        /// </summary>
        public async Task<CalendarpermissionUpdateResponse> CalendarpermissionUpdateAsync(CalendarpermissionUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CalendarpermissionUpdateParameter, CalendarpermissionUpdateResponse>(parameter, cancellationToken);
        }
    }
}
