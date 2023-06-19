using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/calendargroup-post-calendars?view=graph-rest-1.0
    /// </summary>
    public partial class CalendarGroupPostCalendarsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? IdOrUserPrincipalName { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Calendars: return $"/me/calendars";
                    case ApiPath.Users_IdOrUserPrincipalName_Calendars: return $"/users/{IdOrUserPrincipalName}/calendars";
                    case ApiPath.Me_CalendarGroups_Id_Calendars: return $"/me/calendarGroups/{Id}/calendars";
                    case ApiPath.Users_IdOrUserPrincipalName_CalendarGroups_Id_Calendars: return $"/users/{IdOrUserPrincipalName}/calendarGroups/{Id}/calendars";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum CalendarOnlineMeetingProviderType
        {
            Unknown,
            SkypeForBusiness,
            SkypeForConsumer,
            TeamsForBusiness,
        }
        public enum CalendarCalendarColor
        {
            Auto,
            LightBlue,
            LightGreen,
            LightOrange,
            LightGray,
            LightYellow,
            LightTeal,
            LightPink,
            LightBrown,
            LightRed,
            MaxColor,
        }
        public enum ApiPath
        {
            Me_Calendars,
            Users_IdOrUserPrincipalName_Calendars,
            Me_CalendarGroups_Id_Calendars,
            Users_IdOrUserPrincipalName_CalendarGroups_Id_Calendars,
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
        public CalendarOnlineMeetingProviderType AllowedOnlineMeetingProviders { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanShare { get; set; }
        public bool? CanViewPrivateItems { get; set; }
        public string? ChangeKey { get; set; }
        public CalendarCalendarColor Color { get; set; }
        public CalendarOnlineMeetingProviderType DefaultOnlineMeetingProvider { get; set; }
        public string? HexColor { get; set; }
        public string? Id { get; set; }
        public bool? IsDefaultCalendar { get; set; }
        public bool? IsRemovable { get; set; }
        public bool? IsTallyingResponses { get; set; }
        public string? Name { get; set; }
        public EmailAddress? Owner { get; set; }
        public CalendarPermission[]? CalendarPermissions { get; set; }
        public Event[]? CalendarView { get; set; }
        public Event[]? Events { get; set; }
        public MultiValueLegacyExtendedProperty[]? MultiValueExtendedProperties { get; set; }
        public SingleValueLegacyExtendedProperty[]? SingleValueExtendedProperties { get; set; }
    }
    public partial class CalendarGroupPostCalendarsResponse : RestApiResponse
    {
        public enum CalendarOnlineMeetingProviderType
        {
            Unknown,
            SkypeForBusiness,
            SkypeForConsumer,
            TeamsForBusiness,
        }
        public enum CalendarCalendarColor
        {
            Auto,
            LightBlue,
            LightGreen,
            LightOrange,
            LightGray,
            LightYellow,
            LightTeal,
            LightPink,
            LightBrown,
            LightRed,
            MaxColor,
        }

        public CalendarOnlineMeetingProviderType AllowedOnlineMeetingProviders { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanShare { get; set; }
        public bool? CanViewPrivateItems { get; set; }
        public string? ChangeKey { get; set; }
        public CalendarCalendarColor Color { get; set; }
        public CalendarOnlineMeetingProviderType DefaultOnlineMeetingProvider { get; set; }
        public string? HexColor { get; set; }
        public string? Id { get; set; }
        public bool? IsDefaultCalendar { get; set; }
        public bool? IsRemovable { get; set; }
        public bool? IsTallyingResponses { get; set; }
        public string? Name { get; set; }
        public EmailAddress? Owner { get; set; }
        public CalendarPermission[]? CalendarPermissions { get; set; }
        public Event[]? CalendarView { get; set; }
        public Event[]? Events { get; set; }
        public MultiValueLegacyExtendedProperty[]? MultiValueExtendedProperties { get; set; }
        public SingleValueLegacyExtendedProperty[]? SingleValueExtendedProperties { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/calendargroup-post-calendars?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/calendargroup-post-calendars?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<CalendarGroupPostCalendarsResponse> CalendarGroupPostCalendarsAsync()
        {
            var p = new CalendarGroupPostCalendarsParameter();
            return await this.SendAsync<CalendarGroupPostCalendarsParameter, CalendarGroupPostCalendarsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/calendargroup-post-calendars?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<CalendarGroupPostCalendarsResponse> CalendarGroupPostCalendarsAsync(CancellationToken cancellationToken)
        {
            var p = new CalendarGroupPostCalendarsParameter();
            return await this.SendAsync<CalendarGroupPostCalendarsParameter, CalendarGroupPostCalendarsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/calendargroup-post-calendars?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<CalendarGroupPostCalendarsResponse> CalendarGroupPostCalendarsAsync(CalendarGroupPostCalendarsParameter parameter)
        {
            return await this.SendAsync<CalendarGroupPostCalendarsParameter, CalendarGroupPostCalendarsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/calendargroup-post-calendars?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<CalendarGroupPostCalendarsResponse> CalendarGroupPostCalendarsAsync(CalendarGroupPostCalendarsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CalendarGroupPostCalendarsParameter, CalendarGroupPostCalendarsResponse>(parameter, cancellationToken);
        }
    }
}
