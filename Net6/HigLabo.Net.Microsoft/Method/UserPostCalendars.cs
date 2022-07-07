using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserPostCalendarsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Me_Calendars,
            Users_IdOrUserPrincipalName_Calendars,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Calendars: return $"/me/calendars";
                    case ApiPath.Users_IdOrUserPrincipalName_Calendars: return $"/users/{IdOrUserPrincipalName}/calendars";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string IdOrUserPrincipalName { get; set; }
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
