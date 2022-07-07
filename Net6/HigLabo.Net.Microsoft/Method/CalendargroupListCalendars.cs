using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class CalendargroupListCalendarsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Calendars,
            Users_IdOrUserPrincipalName_Calendars,
            Me_CalendarGroups_Id_Calendars,
            Users_IdOrUserPrincipalName_CalendarGroups_Id_Calendars,
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
                    case ApiPath.Me_CalendarGroups_Id_Calendars: return $"/me/calendarGroups/{Id}/calendars";
                    case ApiPath.Users_IdOrUserPrincipalName_CalendarGroups_Id_Calendars: return $"/users/{IdOrUserPrincipalName}/calendarGroups/{Id}/calendars";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
        public string IdOrUserPrincipalName { get; set; }
        public string Id { get; set; }
    }
    public partial class CalendargroupListCalendarsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/calendar?view=graph-rest-1.0
        /// </summary>
        public partial class Calendar
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

        public Calendar[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/calendargroup-list-calendars?view=graph-rest-1.0
        /// </summary>
        public async Task<CalendargroupListCalendarsResponse> CalendargroupListCalendarsAsync()
        {
            var p = new CalendargroupListCalendarsParameter();
            return await this.SendAsync<CalendargroupListCalendarsParameter, CalendargroupListCalendarsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/calendargroup-list-calendars?view=graph-rest-1.0
        /// </summary>
        public async Task<CalendargroupListCalendarsResponse> CalendargroupListCalendarsAsync(CancellationToken cancellationToken)
        {
            var p = new CalendargroupListCalendarsParameter();
            return await this.SendAsync<CalendargroupListCalendarsParameter, CalendargroupListCalendarsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/calendargroup-list-calendars?view=graph-rest-1.0
        /// </summary>
        public async Task<CalendargroupListCalendarsResponse> CalendargroupListCalendarsAsync(CalendargroupListCalendarsParameter parameter)
        {
            return await this.SendAsync<CalendargroupListCalendarsParameter, CalendargroupListCalendarsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/calendargroup-list-calendars?view=graph-rest-1.0
        /// </summary>
        public async Task<CalendargroupListCalendarsResponse> CalendargroupListCalendarsAsync(CalendargroupListCalendarsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CalendargroupListCalendarsParameter, CalendargroupListCalendarsResponse>(parameter, cancellationToken);
        }
    }
}
