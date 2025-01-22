using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/bookingcurrency-list?view=graph-rest-1.0
/// </summary>
public partial class BookingCurrencyListParameter : IRestApiParameter, IQueryParameterProperty
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
public partial class BookingCurrencyListResponse : RestApiResponse<BookingCurrency>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/bookingcurrency-list?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingcurrency-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BookingCurrencyListResponse> BookingCurrencyListAsync()
    {
        var p = new BookingCurrencyListParameter();
        return await this.SendAsync<BookingCurrencyListParameter, BookingCurrencyListResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingcurrency-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BookingCurrencyListResponse> BookingCurrencyListAsync(CancellationToken cancellationToken)
    {
        var p = new BookingCurrencyListParameter();
        return await this.SendAsync<BookingCurrencyListParameter, BookingCurrencyListResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingcurrency-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BookingCurrencyListResponse> BookingCurrencyListAsync(BookingCurrencyListParameter parameter)
    {
        return await this.SendAsync<BookingCurrencyListParameter, BookingCurrencyListResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingcurrency-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BookingCurrencyListResponse> BookingCurrencyListAsync(BookingCurrencyListParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<BookingCurrencyListParameter, BookingCurrencyListResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingcurrency-list?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<BookingCurrency> BookingCurrencyListEnumerateAsync(BookingCurrencyListParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<BookingCurrencyListParameter, BookingCurrencyListResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<BookingCurrency>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
