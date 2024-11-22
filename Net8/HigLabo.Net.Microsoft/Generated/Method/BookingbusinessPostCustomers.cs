using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-post-customers?view=graph-rest-1.0
/// </summary>
public partial class BookingBusinessPostCustomersParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Solutions_BookingBusinesses_Id_Customers: return $"/solutions/bookingBusinesses/{Id}/customers";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Solutions_BookingBusinesses_Id_Customers,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "POST";
    public PhysicalAddress[]? Addresses { get; set; }
    public string? DisplayName { get; set; }
    public string? EmailAddress { get; set; }
    public string? Id { get; set; }
    public Phone[]? Phones { get; set; }
}
public partial class BookingBusinessPostCustomersResponse : RestApiResponse
{
    public PhysicalAddress[]? Addresses { get; set; }
    public string? DisplayName { get; set; }
    public string? EmailAddress { get; set; }
    public string? Id { get; set; }
    public Phone[]? Phones { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-post-customers?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-post-customers?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BookingBusinessPostCustomersResponse> BookingBusinessPostCustomersAsync()
    {
        var p = new BookingBusinessPostCustomersParameter();
        return await this.SendAsync<BookingBusinessPostCustomersParameter, BookingBusinessPostCustomersResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-post-customers?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BookingBusinessPostCustomersResponse> BookingBusinessPostCustomersAsync(CancellationToken cancellationToken)
    {
        var p = new BookingBusinessPostCustomersParameter();
        return await this.SendAsync<BookingBusinessPostCustomersParameter, BookingBusinessPostCustomersResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-post-customers?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BookingBusinessPostCustomersResponse> BookingBusinessPostCustomersAsync(BookingBusinessPostCustomersParameter parameter)
    {
        return await this.SendAsync<BookingBusinessPostCustomersParameter, BookingBusinessPostCustomersResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-post-customers?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BookingBusinessPostCustomersResponse> BookingBusinessPostCustomersAsync(BookingBusinessPostCustomersParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<BookingBusinessPostCustomersParameter, BookingBusinessPostCustomersResponse>(parameter, cancellationToken);
    }
}
