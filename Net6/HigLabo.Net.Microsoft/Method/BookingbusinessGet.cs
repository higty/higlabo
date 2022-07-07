using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class BookingbusinessGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string Id { get; set; }
    }
    public partial class BookingbusinessGetResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-get?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessGetResponse> BookingbusinessGetAsync()
        {
            var p = new BookingbusinessGetParameter();
            return await this.SendAsync<BookingbusinessGetParameter, BookingbusinessGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-get?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessGetResponse> BookingbusinessGetAsync(CancellationToken cancellationToken)
        {
            var p = new BookingbusinessGetParameter();
            return await this.SendAsync<BookingbusinessGetParameter, BookingbusinessGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-get?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessGetResponse> BookingbusinessGetAsync(BookingbusinessGetParameter parameter)
        {
            return await this.SendAsync<BookingbusinessGetParameter, BookingbusinessGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-get?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessGetResponse> BookingbusinessGetAsync(BookingbusinessGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingbusinessGetParameter, BookingbusinessGetResponse>(parameter, cancellationToken);
        }
    }
}
