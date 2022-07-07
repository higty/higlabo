using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class BookingbusinessPostBookingbusinessesParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Solutions_BookingBusinesses,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Solutions_BookingBusinesses: return $"/solutions/bookingBusinesses";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
    }
    public partial class BookingbusinessPostBookingbusinessesResponse : RestApiResponse
    {
        public PhysicalAddress? Address { get; set; }
        public BookingWorkHours[]? BusinessHours { get; set; }
        public string? BusinessType { get; set; }
        public string? DefaultCurrencyIso { get; set; }
        public string? DisplayName { get; set; }
        public string? Email { get; set; }
        public string? Id { get; set; }
        public bool? IsPublished { get; set; }
        public string? Phone { get; set; }
        public string? PublicUrl { get; set; }
        public BookingSchedulingPolicy? SchedulingPolicy { get; set; }
        public string? WebSiteUrl { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-post-bookingbusinesses?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessPostBookingbusinessesResponse> BookingbusinessPostBookingbusinessesAsync()
        {
            var p = new BookingbusinessPostBookingbusinessesParameter();
            return await this.SendAsync<BookingbusinessPostBookingbusinessesParameter, BookingbusinessPostBookingbusinessesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-post-bookingbusinesses?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessPostBookingbusinessesResponse> BookingbusinessPostBookingbusinessesAsync(CancellationToken cancellationToken)
        {
            var p = new BookingbusinessPostBookingbusinessesParameter();
            return await this.SendAsync<BookingbusinessPostBookingbusinessesParameter, BookingbusinessPostBookingbusinessesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-post-bookingbusinesses?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessPostBookingbusinessesResponse> BookingbusinessPostBookingbusinessesAsync(BookingbusinessPostBookingbusinessesParameter parameter)
        {
            return await this.SendAsync<BookingbusinessPostBookingbusinessesParameter, BookingbusinessPostBookingbusinessesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-post-bookingbusinesses?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessPostBookingbusinessesResponse> BookingbusinessPostBookingbusinessesAsync(BookingbusinessPostBookingbusinessesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingbusinessPostBookingbusinessesParameter, BookingbusinessPostBookingbusinessesResponse>(parameter, cancellationToken);
        }
    }
}
