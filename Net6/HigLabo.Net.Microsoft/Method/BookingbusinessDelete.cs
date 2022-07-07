using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class BookingbusinessDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Solutions_BookingBusinesses_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Solutions_BookingBusinesses_Id: return $"/solutions/bookingBusinesses/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string Id { get; set; }
    }
    public partial class BookingbusinessDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessDeleteResponse> BookingbusinessDeleteAsync()
        {
            var p = new BookingbusinessDeleteParameter();
            return await this.SendAsync<BookingbusinessDeleteParameter, BookingbusinessDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessDeleteResponse> BookingbusinessDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new BookingbusinessDeleteParameter();
            return await this.SendAsync<BookingbusinessDeleteParameter, BookingbusinessDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessDeleteResponse> BookingbusinessDeleteAsync(BookingbusinessDeleteParameter parameter)
        {
            return await this.SendAsync<BookingbusinessDeleteParameter, BookingbusinessDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessDeleteResponse> BookingbusinessDeleteAsync(BookingbusinessDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingbusinessDeleteParameter, BookingbusinessDeleteResponse>(parameter, cancellationToken);
        }
    }
}
