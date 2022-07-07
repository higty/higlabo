using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class BookingappointmentDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Solutions_BookingBusinesses_Id_Appointments_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Solutions_BookingBusinesses_Id_Appointments_Id: return $"/solutions/bookingBusinesses/{BookingBusinessesId}/appointments/{AppointmentsId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string BookingBusinessesId { get; set; }
        public string AppointmentsId { get; set; }
    }
    public partial class BookingappointmentDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingappointment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingappointmentDeleteResponse> BookingappointmentDeleteAsync()
        {
            var p = new BookingappointmentDeleteParameter();
            return await this.SendAsync<BookingappointmentDeleteParameter, BookingappointmentDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingappointment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingappointmentDeleteResponse> BookingappointmentDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new BookingappointmentDeleteParameter();
            return await this.SendAsync<BookingappointmentDeleteParameter, BookingappointmentDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingappointment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingappointmentDeleteResponse> BookingappointmentDeleteAsync(BookingappointmentDeleteParameter parameter)
        {
            return await this.SendAsync<BookingappointmentDeleteParameter, BookingappointmentDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingappointment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingappointmentDeleteResponse> BookingappointmentDeleteAsync(BookingappointmentDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingappointmentDeleteParameter, BookingappointmentDeleteResponse>(parameter, cancellationToken);
        }
    }
}
