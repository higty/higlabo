using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-appointments?view=graph-rest-1.0
    /// </summary>
    public partial class BookingbusinessListAppointmentsParameter : IRestApiParameter, IQueryParameterProperty
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

        public enum Field
        {
            AdditionalInformation,
            AnonymousJoinWebUrl,
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
    public partial class BookingbusinessListAppointmentsResponse : RestApiResponse
    {
        public BookingAppointment[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-appointments?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-appointments?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessListAppointmentsResponse> BookingbusinessListAppointmentsAsync()
        {
            var p = new BookingbusinessListAppointmentsParameter();
            return await this.SendAsync<BookingbusinessListAppointmentsParameter, BookingbusinessListAppointmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-appointments?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessListAppointmentsResponse> BookingbusinessListAppointmentsAsync(CancellationToken cancellationToken)
        {
            var p = new BookingbusinessListAppointmentsParameter();
            return await this.SendAsync<BookingbusinessListAppointmentsParameter, BookingbusinessListAppointmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-appointments?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessListAppointmentsResponse> BookingbusinessListAppointmentsAsync(BookingbusinessListAppointmentsParameter parameter)
        {
            return await this.SendAsync<BookingbusinessListAppointmentsParameter, BookingbusinessListAppointmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-appointments?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessListAppointmentsResponse> BookingbusinessListAppointmentsAsync(BookingbusinessListAppointmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingbusinessListAppointmentsParameter, BookingbusinessListAppointmentsResponse>(parameter, cancellationToken);
        }
    }
}
