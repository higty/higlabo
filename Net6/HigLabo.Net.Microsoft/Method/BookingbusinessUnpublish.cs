using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class BookingbusinessUnpublishParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Solutions_BookingBusinesses_Id_Unpublish,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Solutions_BookingBusinesses_Id_Unpublish: return $"/solutions/bookingBusinesses/{Id}/unpublish";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Id { get; set; }
    }
    public partial class BookingbusinessUnpublishResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-unpublish?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessUnpublishResponse> BookingbusinessUnpublishAsync()
        {
            var p = new BookingbusinessUnpublishParameter();
            return await this.SendAsync<BookingbusinessUnpublishParameter, BookingbusinessUnpublishResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-unpublish?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessUnpublishResponse> BookingbusinessUnpublishAsync(CancellationToken cancellationToken)
        {
            var p = new BookingbusinessUnpublishParameter();
            return await this.SendAsync<BookingbusinessUnpublishParameter, BookingbusinessUnpublishResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-unpublish?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessUnpublishResponse> BookingbusinessUnpublishAsync(BookingbusinessUnpublishParameter parameter)
        {
            return await this.SendAsync<BookingbusinessUnpublishParameter, BookingbusinessUnpublishResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-unpublish?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessUnpublishResponse> BookingbusinessUnpublishAsync(BookingbusinessUnpublishParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingbusinessUnpublishParameter, BookingbusinessUnpublishResponse>(parameter, cancellationToken);
        }
    }
}
