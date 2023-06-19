using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingappointment-get?view=graph-rest-1.0
    /// </summary>
    public partial class BookingappointmentGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? BookingBusinessesId { get; set; }
            public string? AppointmentsId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Solutions_BookingBusinesses_Id_Appointments_Id: return $"/solutions/bookingBusinesses/{BookingBusinessesId}/appointments/{AppointmentsId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Solutions_BookingBusinesses_Id_Appointments_Id,
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
    public partial class BookingappointmentGetResponse : RestApiResponse
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
        public string? AnonymousJoinWebUrl { get; set; }
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
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingappointment-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingappointment-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingappointmentGetResponse> BookingappointmentGetAsync()
        {
            var p = new BookingappointmentGetParameter();
            return await this.SendAsync<BookingappointmentGetParameter, BookingappointmentGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingappointment-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingappointmentGetResponse> BookingappointmentGetAsync(CancellationToken cancellationToken)
        {
            var p = new BookingappointmentGetParameter();
            return await this.SendAsync<BookingappointmentGetParameter, BookingappointmentGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingappointment-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingappointmentGetResponse> BookingappointmentGetAsync(BookingappointmentGetParameter parameter)
        {
            return await this.SendAsync<BookingappointmentGetParameter, BookingappointmentGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingappointment-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingappointmentGetResponse> BookingappointmentGetAsync(BookingappointmentGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingappointmentGetParameter, BookingappointmentGetResponse>(parameter, cancellationToken);
        }
    }
}
