using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-calendarview?view=graph-rest-1.0
/// </summary>
public partial class BookingBusinessListCalendarviewParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Solutions_BookingBusinesses_Id_CalendarView: return $"/solutions/bookingBusinesses/{Id}/calendarView";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Solutions_BookingBusinesses_Id_CalendarView,
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
public partial class BookingBusinessListCalendarviewResponse : RestApiResponse<BookingAppointment>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-calendarview?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-calendarview?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BookingBusinessListCalendarviewResponse> BookingBusinessListCalendarviewAsync()
    {
        var p = new BookingBusinessListCalendarviewParameter();
        return await this.SendAsync<BookingBusinessListCalendarviewParameter, BookingBusinessListCalendarviewResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-calendarview?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BookingBusinessListCalendarviewResponse> BookingBusinessListCalendarviewAsync(CancellationToken cancellationToken)
    {
        var p = new BookingBusinessListCalendarviewParameter();
        return await this.SendAsync<BookingBusinessListCalendarviewParameter, BookingBusinessListCalendarviewResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-calendarview?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BookingBusinessListCalendarviewResponse> BookingBusinessListCalendarviewAsync(BookingBusinessListCalendarviewParameter parameter)
    {
        return await this.SendAsync<BookingBusinessListCalendarviewParameter, BookingBusinessListCalendarviewResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-calendarview?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BookingBusinessListCalendarviewResponse> BookingBusinessListCalendarviewAsync(BookingBusinessListCalendarviewParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<BookingBusinessListCalendarviewParameter, BookingBusinessListCalendarviewResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-calendarview?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<BookingAppointment> BookingBusinessListCalendarviewEnumerateAsync(BookingBusinessListCalendarviewParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<BookingBusinessListCalendarviewParameter, BookingBusinessListCalendarviewResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<BookingAppointment>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
