using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingcurrency-get?view=graph-rest-1.0
    /// </summary>
    public partial class BookingCurrencyGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Solutions_BookingCurrencies_Id: return $"/solutions/bookingCurrencies/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Solutions_BookingCurrencies_Id,
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
    public partial class BookingCurrencyGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? Symbol { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingcurrency-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingcurrency-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingCurrencyGetResponse> BookingCurrencyGetAsync()
        {
            var p = new BookingCurrencyGetParameter();
            return await this.SendAsync<BookingCurrencyGetParameter, BookingCurrencyGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingcurrency-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingCurrencyGetResponse> BookingCurrencyGetAsync(CancellationToken cancellationToken)
        {
            var p = new BookingCurrencyGetParameter();
            return await this.SendAsync<BookingCurrencyGetParameter, BookingCurrencyGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingcurrency-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingCurrencyGetResponse> BookingCurrencyGetAsync(BookingCurrencyGetParameter parameter)
        {
            return await this.SendAsync<BookingCurrencyGetParameter, BookingCurrencyGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingcurrency-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingCurrencyGetResponse> BookingCurrencyGetAsync(BookingCurrencyGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingCurrencyGetParameter, BookingCurrencyGetResponse>(parameter, cancellationToken);
        }
    }
}
