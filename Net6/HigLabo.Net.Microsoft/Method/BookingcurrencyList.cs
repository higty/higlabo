using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class BookingcurrencyListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Solutions_BookingCurrencies,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Solutions_BookingCurrencies: return $"/solutions/bookingCurrencies";
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
    public partial class BookingcurrencyListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/bookingcurrency?view=graph-rest-1.0
        /// </summary>
        public partial class BookingCurrency
        {
            public string? Id { get; set; }
            public string? Symbol { get; set; }
        }

        public BookingCurrency[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingcurrency-list?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingcurrencyListResponse> BookingcurrencyListAsync()
        {
            var p = new BookingcurrencyListParameter();
            return await this.SendAsync<BookingcurrencyListParameter, BookingcurrencyListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingcurrency-list?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingcurrencyListResponse> BookingcurrencyListAsync(CancellationToken cancellationToken)
        {
            var p = new BookingcurrencyListParameter();
            return await this.SendAsync<BookingcurrencyListParameter, BookingcurrencyListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingcurrency-list?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingcurrencyListResponse> BookingcurrencyListAsync(BookingcurrencyListParameter parameter)
        {
            return await this.SendAsync<BookingcurrencyListParameter, BookingcurrencyListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingcurrency-list?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingcurrencyListResponse> BookingcurrencyListAsync(BookingcurrencyListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingcurrencyListParameter, BookingcurrencyListResponse>(parameter, cancellationToken);
        }
    }
}
