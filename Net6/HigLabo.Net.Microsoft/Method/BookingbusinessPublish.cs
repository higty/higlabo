using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class BookingbusinessPublishParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Solutions_BookingBusinesses_Id_Publish,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Solutions_BookingBusinesses_Id_Publish: return $"/solutions/bookingBusinesses/{Id}/publish";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Id { get; set; }
    }
    public partial class BookingbusinessPublishResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-publish?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessPublishResponse> BookingbusinessPublishAsync()
        {
            var p = new BookingbusinessPublishParameter();
            return await this.SendAsync<BookingbusinessPublishParameter, BookingbusinessPublishResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-publish?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessPublishResponse> BookingbusinessPublishAsync(CancellationToken cancellationToken)
        {
            var p = new BookingbusinessPublishParameter();
            return await this.SendAsync<BookingbusinessPublishParameter, BookingbusinessPublishResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-publish?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessPublishResponse> BookingbusinessPublishAsync(BookingbusinessPublishParameter parameter)
        {
            return await this.SendAsync<BookingbusinessPublishParameter, BookingbusinessPublishResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-publish?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessPublishResponse> BookingbusinessPublishAsync(BookingbusinessPublishParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingbusinessPublishParameter, BookingbusinessPublishResponse>(parameter, cancellationToken);
        }
    }
}
