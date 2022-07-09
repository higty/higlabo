using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class BookingcurrencyListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Solutions_BookingCurrencies: return $"/solutions/bookingCurrencies";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Id,
            Symbol,
        }
        public enum ApiPath
        {
            Solutions_BookingCurrencies,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
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
        public BookingCurrency[]? Value { get; set; }
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
