using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserPostCalendarsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Calendars: return $"/me/calendars";
                    case ApiPath.Users_IdOrUserPrincipalName_Calendars: return $"/users/{IdOrUserPrincipalName}/calendars";
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
    public partial class UserPostCalendarsResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-post-calendars?view=graph-rest-1.0
        /// </summary>
        public async Task<UserPostCalendarsResponse> UserPostCalendarsAsync()
        {
            var p = new UserPostCalendarsParameter();
            return await this.SendAsync<UserPostCalendarsParameter, UserPostCalendarsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-post-calendars?view=graph-rest-1.0
        /// </summary>
        public async Task<UserPostCalendarsResponse> UserPostCalendarsAsync(CancellationToken cancellationToken)
        {
            var p = new UserPostCalendarsParameter();
            return await this.SendAsync<UserPostCalendarsParameter, UserPostCalendarsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-post-calendars?view=graph-rest-1.0
        /// </summary>
        public async Task<UserPostCalendarsResponse> UserPostCalendarsAsync(UserPostCalendarsParameter parameter)
        {
            return await this.SendAsync<UserPostCalendarsParameter, UserPostCalendarsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-post-calendars?view=graph-rest-1.0
        /// </summary>
        public async Task<UserPostCalendarsResponse> UserPostCalendarsAsync(UserPostCalendarsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserPostCalendarsParameter, UserPostCalendarsResponse>(parameter, cancellationToken);
        }
    }
}
