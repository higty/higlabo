using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-post-customers?view=graph-rest-1.0
    /// </summary>
    public partial class BookingbusinessPostCustomersParameter : IRestApiParameter
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
    public partial class BookingbusinessPostCustomersResponse : RestApiResponse
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
        public async Task<BookingbusinessPostCustomersResponse> BookingbusinessPostCustomersAsync()
        {
            var p = new BookingbusinessPostCustomersParameter();
            return await this.SendAsync<BookingbusinessPostCustomersParameter, BookingbusinessPostCustomersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-post-customers?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessPostCustomersResponse> BookingbusinessPostCustomersAsync(CancellationToken cancellationToken)
        {
            var p = new BookingbusinessPostCustomersParameter();
            return await this.SendAsync<BookingbusinessPostCustomersParameter, BookingbusinessPostCustomersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-post-customers?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessPostCustomersResponse> BookingbusinessPostCustomersAsync(BookingbusinessPostCustomersParameter parameter)
        {
            return await this.SendAsync<BookingbusinessPostCustomersParameter, BookingbusinessPostCustomersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-post-customers?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessPostCustomersResponse> BookingbusinessPostCustomersAsync(BookingbusinessPostCustomersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingbusinessPostCustomersParameter, BookingbusinessPostCustomersResponse>(parameter, cancellationToken);
        }
    }
}
