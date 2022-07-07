using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class BookingbusinessListAppointmentsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Solutions_BookingBusinesses_Id_Appointments,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Solutions_BookingBusinesses_Id_Appointments: return $"/solutions/bookingBusinesses/{Id}/appointments";
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
        public string Id { get; set; }
    }
    public partial class BookingbusinessListAppointmentsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/bookingappointment?view=graph-rest-1.0
        /// </summary>
        public partial class BookingAppointment
        {
            public enum BookingAppointmentBookingPriceType
            {
                Undefined,
                FixedPrice,
                StartingAt,
                Hourly,
                Free,
                PriceVaries,
                CallUs,
                NotSet,
                UnknownFutureValue,
            }

            public string? AdditionalInformation { get; set; }
            public BookingCustomerInformation[]? Customers { get; set; }
            public string? CustomerTimeZone { get; set; }
            public string? Duration { get; set; }
            public DateTimeTimeZone? EndDateTime { get; set; }
            public Int32? FilledAttendeesCount { get; set; }
            public string? Id { get; set; }
            public bool? IsLocationOnline { get; set; }
            public string? JoinWebUrl { get; set; }
            public Int32? MaximumAttendeesCount { get; set; }
            public bool? OptOutOfCustomerEmail { get; set; }
            public string? PostBuffer { get; set; }
            public string? PreBuffer { get; set; }
            public Double? Price { get; set; }
            public BookingAppointmentBookingPriceType PriceType { get; set; }
            public BookingReminder[]? Reminders { get; set; }
            public string? SelfServiceAppointmentId { get; set; }
            public string? ServiceId { get; set; }
            public Location? ServiceLocation { get; set; }
            public string? ServiceName { get; set; }
            public string? ServiceNotes { get; set; }
            public bool? SmsNotificationsEnabled { get; set; }
            public String[]? StaffMemberIds { get; set; }
            public DateTimeTimeZone? StartDateTime { get; set; }
        }

        public BookingAppointment[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-list-appointments?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessListAppointmentsResponse> BookingbusinessListAppointmentsAsync()
        {
            var p = new BookingbusinessListAppointmentsParameter();
            return await this.SendAsync<BookingbusinessListAppointmentsParameter, BookingbusinessListAppointmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-list-appointments?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessListAppointmentsResponse> BookingbusinessListAppointmentsAsync(CancellationToken cancellationToken)
        {
            var p = new BookingbusinessListAppointmentsParameter();
            return await this.SendAsync<BookingbusinessListAppointmentsParameter, BookingbusinessListAppointmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-list-appointments?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessListAppointmentsResponse> BookingbusinessListAppointmentsAsync(BookingbusinessListAppointmentsParameter parameter)
        {
            return await this.SendAsync<BookingbusinessListAppointmentsParameter, BookingbusinessListAppointmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-list-appointments?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessListAppointmentsResponse> BookingbusinessListAppointmentsAsync(BookingbusinessListAppointmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingbusinessListAppointmentsParameter, BookingbusinessListAppointmentsResponse>(parameter, cancellationToken);
        }
    }
}
