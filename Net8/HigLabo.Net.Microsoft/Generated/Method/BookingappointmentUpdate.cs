using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingappointment-update?view=graph-rest-1.0
    /// </summary>
    public partial class BookingAppointmentUpdateParameter : IRestApiParameter
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

        public enum BookingAppointmentUpdateParameterBookingPriceType
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
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public BookingCustomerInformation[]? Customers { get; set; }
        public string? CustomerTimeZone { get; set; }
        public string? Duration { get; set; }
        public DateTimeTimeZone? EndDateTime { get; set; }
        public Int32? FilledAttendeesCount { get; set; }
        public bool? IsLocationOnline { get; set; }
        public Int32? MaximumAttendeesCount { get; set; }
        public bool? OptOutOfCustomerEmail { get; set; }
        public string? PostBuffer { get; set; }
        public string? PreBuffer { get; set; }
        public Double? Price { get; set; }
        public BookingAppointmentUpdateParameterBookingPriceType PriceType { get; set; }
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
    public partial class BookingAppointmentUpdateResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingappointment-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingappointment-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingAppointmentUpdateResponse> BookingAppointmentUpdateAsync()
        {
            var p = new BookingAppointmentUpdateParameter();
            return await this.SendAsync<BookingAppointmentUpdateParameter, BookingAppointmentUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingappointment-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingAppointmentUpdateResponse> BookingAppointmentUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new BookingAppointmentUpdateParameter();
            return await this.SendAsync<BookingAppointmentUpdateParameter, BookingAppointmentUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingappointment-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingAppointmentUpdateResponse> BookingAppointmentUpdateAsync(BookingAppointmentUpdateParameter parameter)
        {
            return await this.SendAsync<BookingAppointmentUpdateParameter, BookingAppointmentUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingappointment-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingAppointmentUpdateResponse> BookingAppointmentUpdateAsync(BookingAppointmentUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingAppointmentUpdateParameter, BookingAppointmentUpdateResponse>(parameter, cancellationToken);
        }
    }
}
