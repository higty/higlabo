using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class BookingcustomerDeleteParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class BookingcustomerDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingcustomer-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingcustomerDeleteResponse> BookingcustomerDeleteAsync()
        {
            var p = new BookingcustomerDeleteParameter();
            return await this.SendAsync<BookingcustomerDeleteParameter, BookingcustomerDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingcustomer-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingcustomerDeleteResponse> BookingcustomerDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new BookingcustomerDeleteParameter();
            return await this.SendAsync<BookingcustomerDeleteParameter, BookingcustomerDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingcustomer-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingcustomerDeleteResponse> BookingcustomerDeleteAsync(BookingcustomerDeleteParameter parameter)
        {
            return await this.SendAsync<BookingcustomerDeleteParameter, BookingcustomerDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingcustomer-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingcustomerDeleteResponse> BookingcustomerDeleteAsync(BookingcustomerDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingcustomerDeleteParameter, BookingcustomerDeleteResponse>(parameter, cancellationToken);
        }
    }
}
