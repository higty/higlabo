using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class BookingcustomerUpdateParameter : IRestApiParameter
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
    public partial class BookingcustomerUpdateResponse : RestApiResponse
    {
        public string? DisplayName { get; set; }
        public string? EmailAddress { get; set; }
        public string? Id { get; set; }
        public PhysicalAddress[]? Addresses { get; set; }
        public Phone[]? Phones { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingcustomer-update?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingcustomerUpdateResponse> BookingcustomerUpdateAsync()
        {
            var p = new BookingcustomerUpdateParameter();
            return await this.SendAsync<BookingcustomerUpdateParameter, BookingcustomerUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingcustomer-update?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingcustomerUpdateResponse> BookingcustomerUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new BookingcustomerUpdateParameter();
            return await this.SendAsync<BookingcustomerUpdateParameter, BookingcustomerUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingcustomer-update?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingcustomerUpdateResponse> BookingcustomerUpdateAsync(BookingcustomerUpdateParameter parameter)
        {
            return await this.SendAsync<BookingcustomerUpdateParameter, BookingcustomerUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingcustomer-update?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingcustomerUpdateResponse> BookingcustomerUpdateAsync(BookingcustomerUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingcustomerUpdateParameter, BookingcustomerUpdateResponse>(parameter, cancellationToken);
        }
    }
}
