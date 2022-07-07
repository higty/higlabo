using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class BookingcustomerGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Solutions_BookingBusinesses_Id_Customers_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Solutions_BookingBusinesses_Id_Customers_Id: return $"/solutions/bookingBusinesses/{BookingBusinessesId}/customers/{CustomersId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
        public string BookingBusinessesId { get; set; }
        public string CustomersId { get; set; }
    }
    public partial class BookingcustomerGetResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/bookingcustomer-get?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingcustomerGetResponse> BookingcustomerGetAsync()
        {
            var p = new BookingcustomerGetParameter();
            return await this.SendAsync<BookingcustomerGetParameter, BookingcustomerGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingcustomer-get?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingcustomerGetResponse> BookingcustomerGetAsync(CancellationToken cancellationToken)
        {
            var p = new BookingcustomerGetParameter();
            return await this.SendAsync<BookingcustomerGetParameter, BookingcustomerGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingcustomer-get?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingcustomerGetResponse> BookingcustomerGetAsync(BookingcustomerGetParameter parameter)
        {
            return await this.SendAsync<BookingcustomerGetParameter, BookingcustomerGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingcustomer-get?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingcustomerGetResponse> BookingcustomerGetAsync(BookingcustomerGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingcustomerGetParameter, BookingcustomerGetResponse>(parameter, cancellationToken);
        }
    }
}
