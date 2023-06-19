using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingcustomer-get?view=graph-rest-1.0
    /// </summary>
    public partial class BookingcustomerGetParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class BookingcustomerGetResponse : RestApiResponse
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
        public async ValueTask<BookingcustomerGetResponse> BookingcustomerGetAsync()
        {
            var p = new BookingcustomerGetParameter();
            return await this.SendAsync<BookingcustomerGetParameter, BookingcustomerGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingcustomer-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingcustomerGetResponse> BookingcustomerGetAsync(CancellationToken cancellationToken)
        {
            var p = new BookingcustomerGetParameter();
            return await this.SendAsync<BookingcustomerGetParameter, BookingcustomerGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingcustomer-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingcustomerGetResponse> BookingcustomerGetAsync(BookingcustomerGetParameter parameter)
        {
            return await this.SendAsync<BookingcustomerGetParameter, BookingcustomerGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingcustomer-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingcustomerGetResponse> BookingcustomerGetAsync(BookingcustomerGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingcustomerGetParameter, BookingcustomerGetResponse>(parameter, cancellationToken);
        }
    }
}
