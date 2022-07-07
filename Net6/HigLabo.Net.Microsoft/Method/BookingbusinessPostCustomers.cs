using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class BookingbusinessPostCustomersParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Solutions_BookingBusinesses_Id_Customers,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Solutions_BookingBusinesses_Id_Customers: return $"/solutions/bookingBusinesses/{Id}/customers";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Id { get; set; }
    }
    public partial class BookingbusinessPostCustomersResponse : RestApiResponse
    {
        public string? DisplayName { get; set; }
        public string? EmailAddress { get; set; }
        public string? Id { get; set; }
        public PhysicalAddress[]? Addresses { get; set; }
        public Phone[]? Phones { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-post-customers?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessPostCustomersResponse> BookingbusinessPostCustomersAsync()
        {
            var p = new BookingbusinessPostCustomersParameter();
            return await this.SendAsync<BookingbusinessPostCustomersParameter, BookingbusinessPostCustomersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-post-customers?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessPostCustomersResponse> BookingbusinessPostCustomersAsync(CancellationToken cancellationToken)
        {
            var p = new BookingbusinessPostCustomersParameter();
            return await this.SendAsync<BookingbusinessPostCustomersParameter, BookingbusinessPostCustomersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-post-customers?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessPostCustomersResponse> BookingbusinessPostCustomersAsync(BookingbusinessPostCustomersParameter parameter)
        {
            return await this.SendAsync<BookingbusinessPostCustomersParameter, BookingbusinessPostCustomersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-post-customers?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessPostCustomersResponse> BookingbusinessPostCustomersAsync(BookingbusinessPostCustomersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingbusinessPostCustomersParameter, BookingbusinessPostCustomersResponse>(parameter, cancellationToken);
        }
    }
}
