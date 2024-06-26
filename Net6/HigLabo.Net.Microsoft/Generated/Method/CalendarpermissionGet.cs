﻿using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/calendarpermission-get?view=graph-rest-1.0
    /// </summary>
    public partial class CalendarpermissionGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? UsersId { get; set; }
            public string? CalendarPermissionsId { get; set; }
            public string? GroupsId { get; set; }
            public string? EventsId { get; set; }

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

        public enum Field
        {
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
    }
    public partial class CalendarpermissionGetResponse : RestApiResponse
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
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/calendarpermission-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/calendarpermission-get?view=graph-rest-1.0
        /// </summary>
        public async Task<CalendarpermissionGetResponse> CalendarpermissionGetAsync()
        {
            var p = new CalendarpermissionGetParameter();
            return await this.SendAsync<CalendarpermissionGetParameter, CalendarpermissionGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/calendarpermission-get?view=graph-rest-1.0
        /// </summary>
        public async Task<CalendarpermissionGetResponse> CalendarpermissionGetAsync(CancellationToken cancellationToken)
        {
            var p = new CalendarpermissionGetParameter();
            return await this.SendAsync<CalendarpermissionGetParameter, CalendarpermissionGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/calendarpermission-get?view=graph-rest-1.0
        /// </summary>
        public async Task<CalendarpermissionGetResponse> CalendarpermissionGetAsync(CalendarpermissionGetParameter parameter)
        {
            return await this.SendAsync<CalendarpermissionGetParameter, CalendarpermissionGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/calendarpermission-get?view=graph-rest-1.0
        /// </summary>
        public async Task<CalendarpermissionGetResponse> CalendarpermissionGetAsync(CalendarpermissionGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CalendarpermissionGetParameter, CalendarpermissionGetResponse>(parameter, cancellationToken);
        }
    }
}
