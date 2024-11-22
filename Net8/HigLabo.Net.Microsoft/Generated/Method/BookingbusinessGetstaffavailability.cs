using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-getstaffavailability?view=graph-rest-1.0
/// </summary>
public partial class BookingbusinessGetstaffavailabilityParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Solutions_BookingBusinesses_Id_GetStaffAvailability: return $"/solutions/bookingBusinesses/{Id}/getStaffAvailability";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Solutions_BookingBusinesses_Id_GetStaffAvailability,
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
}
public partial class BookingbusinessGetstaffavailabilityResponse : RestApiResponse
{
    public StaffAvailabilityItem[]? Value { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-getstaffavailability?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-getstaffavailability?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BookingbusinessGetstaffavailabilityResponse> BookingbusinessGetstaffavailabilityAsync()
    {
        var p = new BookingbusinessGetstaffavailabilityParameter();
        return await this.SendAsync<BookingbusinessGetstaffavailabilityParameter, BookingbusinessGetstaffavailabilityResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-getstaffavailability?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BookingbusinessGetstaffavailabilityResponse> BookingbusinessGetstaffavailabilityAsync(CancellationToken cancellationToken)
    {
        var p = new BookingbusinessGetstaffavailabilityParameter();
        return await this.SendAsync<BookingbusinessGetstaffavailabilityParameter, BookingbusinessGetstaffavailabilityResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-getstaffavailability?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BookingbusinessGetstaffavailabilityResponse> BookingbusinessGetstaffavailabilityAsync(BookingbusinessGetstaffavailabilityParameter parameter)
    {
        return await this.SendAsync<BookingbusinessGetstaffavailabilityParameter, BookingbusinessGetstaffavailabilityResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-getstaffavailability?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BookingbusinessGetstaffavailabilityResponse> BookingbusinessGetstaffavailabilityAsync(BookingbusinessGetstaffavailabilityParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<BookingbusinessGetstaffavailabilityParameter, BookingbusinessGetstaffavailabilityResponse>(parameter, cancellationToken);
    }
}
