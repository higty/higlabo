using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-post-appointments?view=graph-rest-1.0
    /// </summary>
    public partial class BookingbusinessPostAppointmentsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Solutions_BookingBusinesses_Id_Appointments: return $"/solutions/bookingBusinesses/{Id}/appointments";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

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
        public enum ApiPath
        {
            Solutions_BookingBusinesses_Id_Appointments,
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
    public partial class BookingbusinessPostAppointmentsResponse : RestApiResponse
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
    /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-post-appointments?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-post-appointments?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessPostAppointmentsResponse> BookingbusinessPostAppointmentsAsync()
        {
            var p = new BookingbusinessPostAppointmentsParameter();
            return await this.SendAsync<BookingbusinessPostAppointmentsParameter, BookingbusinessPostAppointmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-post-appointments?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessPostAppointmentsResponse> BookingbusinessPostAppointmentsAsync(CancellationToken cancellationToken)
        {
            var p = new BookingbusinessPostAppointmentsParameter();
            return await this.SendAsync<BookingbusinessPostAppointmentsParameter, BookingbusinessPostAppointmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-post-appointments?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessPostAppointmentsResponse> BookingbusinessPostAppointmentsAsync(BookingbusinessPostAppointmentsParameter parameter)
        {
            return await this.SendAsync<BookingbusinessPostAppointmentsParameter, BookingbusinessPostAppointmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-post-appointments?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessPostAppointmentsResponse> BookingbusinessPostAppointmentsAsync(BookingbusinessPostAppointmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingbusinessPostAppointmentsParameter, BookingbusinessPostAppointmentsResponse>(parameter, cancellationToken);
        }
    }
}
