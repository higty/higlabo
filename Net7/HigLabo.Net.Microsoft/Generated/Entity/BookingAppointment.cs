using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/bookingappointment?view=graph-rest-1.0
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
}
