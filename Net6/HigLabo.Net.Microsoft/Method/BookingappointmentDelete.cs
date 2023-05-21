using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingappointment-delete?view=graph-rest-1.0
    /// </summary>
    public partial class BookingappointmentDeleteParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class BookingappointmentDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingappointment-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingappointment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingappointmentDeleteResponse> BookingappointmentDeleteAsync()
        {
            var p = new BookingappointmentDeleteParameter();
            return await this.SendAsync<BookingappointmentDeleteParameter, BookingappointmentDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingappointment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingappointmentDeleteResponse> BookingappointmentDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new BookingappointmentDeleteParameter();
            return await this.SendAsync<BookingappointmentDeleteParameter, BookingappointmentDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingappointment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingappointmentDeleteResponse> BookingappointmentDeleteAsync(BookingappointmentDeleteParameter parameter)
        {
            return await this.SendAsync<BookingappointmentDeleteParameter, BookingappointmentDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingappointment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingappointmentDeleteResponse> BookingappointmentDeleteAsync(BookingappointmentDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingappointmentDeleteParameter, BookingappointmentDeleteResponse>(parameter, cancellationToken);
        }
    }
}
