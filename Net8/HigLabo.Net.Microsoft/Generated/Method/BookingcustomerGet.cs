using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/bookingcustomer-get?view=graph-rest-1.0
/// </summary>
public partial class BookingCustomerGetParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? BookingBusinessesId { get; set; }
        public string? CustomersId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Solutions_BookingBusinesses_Id_Customers_Id: return $"/solutions/bookingBusinesses/{BookingBusinessesId}/customers/{CustomersId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Solutions_BookingBusinesses_Id_Customers_Id,
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
public partial class BookingCustomerGetResponse : RestApiResponse
{
    public PhysicalAddress[]? Addresses { get; set; }
    public string? DisplayName { get; set; }
    public string? EmailAddress { get; set; }
    public string? Id { get; set; }
    public Phone[]? Phones { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/bookingcustomer-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingcustomer-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BookingCustomerGetResponse> BookingCustomerGetAsync()
    {
        var p = new BookingCustomerGetParameter();
        return await this.SendAsync<BookingCustomerGetParameter, BookingCustomerGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingcustomer-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BookingCustomerGetResponse> BookingCustomerGetAsync(CancellationToken cancellationToken)
    {
        var p = new BookingCustomerGetParameter();
        return await this.SendAsync<BookingCustomerGetParameter, BookingCustomerGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingcustomer-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BookingCustomerGetResponse> BookingCustomerGetAsync(BookingCustomerGetParameter parameter)
    {
        return await this.SendAsync<BookingCustomerGetParameter, BookingCustomerGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingcustomer-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BookingCustomerGetResponse> BookingCustomerGetAsync(BookingCustomerGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<BookingCustomerGetParameter, BookingCustomerGetResponse>(parameter, cancellationToken);
    }
}
