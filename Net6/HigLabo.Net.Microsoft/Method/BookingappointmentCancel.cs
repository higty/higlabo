using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class BookingappointmentCancelParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Solutions_BookingBusinesses_Id_Appointments_Id_Cancel,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Solutions_BookingBusinesses_Id_Appointments_Id_Cancel: return $"/solutions/bookingBusinesses/{BookingBusinessesId}/appointments/{AppointmentsId}/cancel";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? CancellationMessage { get; set; }
        public string BookingBusinessesId { get; set; }
        public string AppointmentsId { get; set; }
    }
    public partial class BookingappointmentCancelResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingappointment-cancel?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingappointmentCancelResponse> BookingappointmentCancelAsync()
        {
            var p = new BookingappointmentCancelParameter();
            return await this.SendAsync<BookingappointmentCancelParameter, BookingappointmentCancelResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingappointment-cancel?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingappointmentCancelResponse> BookingappointmentCancelAsync(CancellationToken cancellationToken)
        {
            var p = new BookingappointmentCancelParameter();
            return await this.SendAsync<BookingappointmentCancelParameter, BookingappointmentCancelResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingappointment-cancel?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingappointmentCancelResponse> BookingappointmentCancelAsync(BookingappointmentCancelParameter parameter)
        {
            return await this.SendAsync<BookingappointmentCancelParameter, BookingappointmentCancelResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingappointment-cancel?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingappointmentCancelResponse> BookingappointmentCancelAsync(BookingappointmentCancelParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingappointmentCancelParameter, BookingappointmentCancelResponse>(parameter, cancellationToken);
        }
    }
}
