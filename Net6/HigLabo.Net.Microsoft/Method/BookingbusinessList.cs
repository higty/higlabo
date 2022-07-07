using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class BookingbusinessListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
    }
    public partial class BookingbusinessListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/bookingbusiness?view=graph-rest-1.0
        /// </summary>
        public partial class BookingBusiness
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

        public BookingBusiness[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-list?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessListResponse> BookingbusinessListAsync()
        {
            var p = new BookingbusinessListParameter();
            return await this.SendAsync<BookingbusinessListParameter, BookingbusinessListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-list?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessListResponse> BookingbusinessListAsync(CancellationToken cancellationToken)
        {
            var p = new BookingbusinessListParameter();
            return await this.SendAsync<BookingbusinessListParameter, BookingbusinessListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-list?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessListResponse> BookingbusinessListAsync(BookingbusinessListParameter parameter)
        {
            return await this.SendAsync<BookingbusinessListParameter, BookingbusinessListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-list?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessListResponse> BookingbusinessListAsync(BookingbusinessListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingbusinessListParameter, BookingbusinessListResponse>(parameter, cancellationToken);
        }
    }
}
