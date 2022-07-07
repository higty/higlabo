using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class CalendarGetParameter : IRestApiParameter, IQueryParameterProperty
    {
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
        }
        public enum ApiPath
        {
            Me_Calendar,
            Users_IdOrUserPrincipalName_Calendar,
            Groups_Id_Calendar,
            Me_Calendars_Id,
            Users_IdOrUserPrincipalName_Calendars_Id,
            Me_CalendarGroups_Id_Calendars_Id,
            Users_IdOrUserPrincipalName_CalendarGroups_Id_Calendars_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Calendar: return $"/me/calendar";
                    case ApiPath.Users_IdOrUserPrincipalName_Calendar: return $"/users/{IdOrUserPrincipalName}/calendar";
                    case ApiPath.Groups_Id_Calendar: return $"/groups/{Id}/calendar";
                    case ApiPath.Me_Calendars_Id: return $"/me/calendars/{Id}";
                    case ApiPath.Users_IdOrUserPrincipalName_Calendars_Id: return $"/users/{IdOrUserPrincipalName}/calendars/{Id}";
                    case ApiPath.Me_CalendarGroups_Id_Calendars_Id: return $"/me/calendarGroups/{CalendarGroupsId}/calendars/{CalendarsId}";
                    case ApiPath.Users_IdOrUserPrincipalName_CalendarGroups_Id_Calendars_Id: return $"/users/{UsersIdOrUserPrincipalName}/calendarGroups/{CalendarGroupsId}/calendars/{CalendarsId}";
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
        public string CalendarGroupsId { get; set; }
        public string CalendarsId { get; set; }
        public string UsersIdOrUserPrincipalName { get; set; }
    }
    public partial class CalendarGetResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/calendar-get?view=graph-rest-1.0
        /// </summary>
        public async Task<CalendarGetResponse> CalendarGetAsync()
        {
            var p = new CalendarGetParameter();
            return await this.SendAsync<CalendarGetParameter, CalendarGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/calendar-get?view=graph-rest-1.0
        /// </summary>
        public async Task<CalendarGetResponse> CalendarGetAsync(CancellationToken cancellationToken)
        {
            var p = new CalendarGetParameter();
            return await this.SendAsync<CalendarGetParameter, CalendarGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/calendar-get?view=graph-rest-1.0
        /// </summary>
        public async Task<CalendarGetResponse> CalendarGetAsync(CalendarGetParameter parameter)
        {
            return await this.SendAsync<CalendarGetParameter, CalendarGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/calendar-get?view=graph-rest-1.0
        /// </summary>
        public async Task<CalendarGetResponse> CalendarGetAsync(CalendarGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CalendarGetParameter, CalendarGetResponse>(parameter, cancellationToken);
        }
    }
}
