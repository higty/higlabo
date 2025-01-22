using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list?view=graph-rest-1.0
/// </summary>
public partial class BookingBusinessListParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Solutions_BookingBusinesses: return $"/solutions/bookingBusinesses";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Solutions_BookingBusinesses,
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
public partial class BookingBusinessListResponse : RestApiResponse<BookingBusiness>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BookingBusinessListResponse> BookingBusinessListAsync()
    {
        var p = new BookingBusinessListParameter();
        return await this.SendAsync<BookingBusinessListParameter, BookingBusinessListResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BookingBusinessListResponse> BookingBusinessListAsync(CancellationToken cancellationToken)
    {
        var p = new BookingBusinessListParameter();
        return await this.SendAsync<BookingBusinessListParameter, BookingBusinessListResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BookingBusinessListResponse> BookingBusinessListAsync(BookingBusinessListParameter parameter)
    {
        return await this.SendAsync<BookingBusinessListParameter, BookingBusinessListResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BookingBusinessListResponse> BookingBusinessListAsync(BookingBusinessListParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<BookingBusinessListParameter, BookingBusinessListResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<BookingBusiness> BookingBusinessListEnumerateAsync(BookingBusinessListParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<BookingBusinessListParameter, BookingBusinessListResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<BookingBusiness>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
