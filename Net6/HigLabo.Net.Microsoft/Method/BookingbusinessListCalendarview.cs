using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class BookingbusinessListCalendarviewParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Solutions_BookingBusinesses_Id_CalendarView: return $"/solutions/bookingBusinesses/{Id}/calendarView";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            AdditionalInformation,
            Customers,
            CustomerTimeZone,
            Duration,
            EndDateTime,
            FilledAttendeesCount,
            Id,
            IsLocationOnline,
            JoinWebUrl,
            MaximumAttendeesCount,
            OptOutOfCustomerEmail,
            PostBuffer,
            PreBuffer,
            Price,
            PriceType,
            Reminders,
            SelfServiceAppointmentId,
            ServiceId,
            ServiceLocation,
            ServiceName,
            ServiceNotes,
            SmsNotificationsEnabled,
            StaffMemberIds,
            StartDateTime,
        }
        public enum ApiPath
        {
            Solutions_BookingBusinesses_Id_CalendarView,
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
    public partial class BookingbusinessListCalendarviewResponse : RestApiResponse
    {
        public BookingAppointment[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-list-calendarview?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessListCalendarviewResponse> BookingbusinessListCalendarviewAsync()
        {
            var p = new BookingbusinessListCalendarviewParameter();
            return await this.SendAsync<BookingbusinessListCalendarviewParameter, BookingbusinessListCalendarviewResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-list-calendarview?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessListCalendarviewResponse> BookingbusinessListCalendarviewAsync(CancellationToken cancellationToken)
        {
            var p = new BookingbusinessListCalendarviewParameter();
            return await this.SendAsync<BookingbusinessListCalendarviewParameter, BookingbusinessListCalendarviewResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-list-calendarview?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessListCalendarviewResponse> BookingbusinessListCalendarviewAsync(BookingbusinessListCalendarviewParameter parameter)
        {
            return await this.SendAsync<BookingbusinessListCalendarviewParameter, BookingbusinessListCalendarviewResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-list-calendarview?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessListCalendarviewResponse> BookingbusinessListCalendarviewAsync(BookingbusinessListCalendarviewParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingbusinessListCalendarviewParameter, BookingbusinessListCalendarviewResponse>(parameter, cancellationToken);
        }
    }
}
