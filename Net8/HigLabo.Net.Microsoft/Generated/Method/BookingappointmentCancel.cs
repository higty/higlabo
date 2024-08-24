using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingappointment-cancel?view=graph-rest-1.0
    /// </summary>
    public partial class BookingAppointmentCancelParameter : IRestApiParameter
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
                    case ApiPath.Solutions_BookingBusinesses_Id_Appointments_Id_Cancel: return $"/solutions/bookingBusinesses/{BookingBusinessesId}/appointments/{AppointmentsId}/cancel";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Solutions_BookingBusinesses_Id_Appointments_Id_Cancel,
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
        public string? CancellationMessage { get; set; }
    }
    public partial class BookingAppointmentCancelResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingappointment-cancel?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingappointment-cancel?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingAppointmentCancelResponse> BookingAppointmentCancelAsync()
        {
            var p = new BookingAppointmentCancelParameter();
            return await this.SendAsync<BookingAppointmentCancelParameter, BookingAppointmentCancelResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingappointment-cancel?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingAppointmentCancelResponse> BookingAppointmentCancelAsync(CancellationToken cancellationToken)
        {
            var p = new BookingAppointmentCancelParameter();
            return await this.SendAsync<BookingAppointmentCancelParameter, BookingAppointmentCancelResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingappointment-cancel?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingAppointmentCancelResponse> BookingAppointmentCancelAsync(BookingAppointmentCancelParameter parameter)
        {
            return await this.SendAsync<BookingAppointmentCancelParameter, BookingAppointmentCancelResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingappointment-cancel?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingAppointmentCancelResponse> BookingAppointmentCancelAsync(BookingAppointmentCancelParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingAppointmentCancelParameter, BookingAppointmentCancelResponse>(parameter, cancellationToken);
        }
    }
}
