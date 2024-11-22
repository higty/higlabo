using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/bookingcustomer-update?view=graph-rest-1.0
/// </summary>
public partial class BookingCustomerUpdateParameter : IRestApiParameter
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
    string IRestApiParameter.HttpMethod { get; } = "PATCH";
    public PhysicalAddress[]? Addresses { get; set; }
    public string? DisplayName { get; set; }
    public string? EmailAddress { get; set; }
    public Phone[]? Phones { get; set; }
}
public partial class BookingCustomerUpdateResponse : RestApiResponse
{
    public PhysicalAddress[]? Addresses { get; set; }
    public string? DisplayName { get; set; }
    public string? EmailAddress { get; set; }
    public string? Id { get; set; }
    public Phone[]? Phones { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/bookingcustomer-update?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingcustomer-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BookingCustomerUpdateResponse> BookingCustomerUpdateAsync()
    {
        var p = new BookingCustomerUpdateParameter();
        return await this.SendAsync<BookingCustomerUpdateParameter, BookingCustomerUpdateResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingcustomer-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BookingCustomerUpdateResponse> BookingCustomerUpdateAsync(CancellationToken cancellationToken)
    {
        var p = new BookingCustomerUpdateParameter();
        return await this.SendAsync<BookingCustomerUpdateParameter, BookingCustomerUpdateResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingcustomer-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BookingCustomerUpdateResponse> BookingCustomerUpdateAsync(BookingCustomerUpdateParameter parameter)
    {
        return await this.SendAsync<BookingCustomerUpdateParameter, BookingCustomerUpdateResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingcustomer-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BookingCustomerUpdateResponse> BookingCustomerUpdateAsync(BookingCustomerUpdateParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<BookingCustomerUpdateParameter, BookingCustomerUpdateResponse>(parameter, cancellationToken);
    }
}
