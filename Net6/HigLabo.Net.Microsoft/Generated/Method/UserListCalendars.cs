using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-calendars?view=graph-rest-1.0
    /// </summary>
    public partial class UserListCalendarsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? IdOrUserPrincipalName { get; set; }
            public string? Calendar_group_id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Calendars: return $"/me/calendars";
                    case ApiPath.Users_IdOrUserPrincipalName_Calendars: return $"/users/{IdOrUserPrincipalName}/calendars";
                    case ApiPath.Me_CalendarGroups_Calendar_group_id_Calendars: return $"/me/calendarGroups/{Calendar_group_id}/calendars";
                    case ApiPath.Users_IdOrUserPrincipalName_CalendarGroups_Calendar_group_id_Calendars: return $"/users/{IdOrUserPrincipalName}/calendarGroups/{Calendar_group_id}/calendars";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            AllowedOnlineMeetingProviders,
            CanEdit,
            CanShare,
            CanViewPrivateItems,
            ChangeKey,
            Color,
            DefaultOnlineMeetingProvider,
            HexColor,
            Id,
            IsDefaultCalendar,
            IsRemovable,
            IsTallyingResponses,
            Name,
            Owner,
            CalendarPermissions,
            CalendarView,
            Events,
            MultiValueExtendedProperties,
            SingleValueExtendedProperties,
        }
        public enum ApiPath
        {
            Me_Calendars,
            Users_IdOrUserPrincipalName_Calendars,
            Me_CalendarGroups_Calendar_group_id_Calendars,
            Users_IdOrUserPrincipalName_CalendarGroups_Calendar_group_id_Calendars,
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
    public partial class UserListCalendarsResponse : RestApiResponse
    {
        public Calendar[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-calendars?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-calendars?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListCalendarsResponse> UserListCalendarsAsync()
        {
            var p = new UserListCalendarsParameter();
            return await this.SendAsync<UserListCalendarsParameter, UserListCalendarsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-calendars?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListCalendarsResponse> UserListCalendarsAsync(CancellationToken cancellationToken)
        {
            var p = new UserListCalendarsParameter();
            return await this.SendAsync<UserListCalendarsParameter, UserListCalendarsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-calendars?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListCalendarsResponse> UserListCalendarsAsync(UserListCalendarsParameter parameter)
        {
            return await this.SendAsync<UserListCalendarsParameter, UserListCalendarsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-calendars?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListCalendarsResponse> UserListCalendarsAsync(UserListCalendarsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserListCalendarsParameter, UserListCalendarsResponse>(parameter, cancellationToken);
        }
    }
}
