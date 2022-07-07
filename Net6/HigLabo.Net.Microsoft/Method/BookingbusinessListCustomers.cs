using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class BookingbusinessListCustomersParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Solutions_BookingBusinesses_Id_Customers,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Solutions_BookingBusinesses_Id_Customers: return $"/solutions/bookingBusinesses/{Id}/customers";
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
        public string Id { get; set; }
    }
    public partial class BookingbusinessListCustomersResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/bookingcustomer?view=graph-rest-1.0
        /// </summary>
        public partial class BookingCustomer
        {
            public string? DisplayName { get; set; }
            public string? EmailAddress { get; set; }
            public string? Id { get; set; }
            public PhysicalAddress[]? Addresses { get; set; }
            public Phone[]? Phones { get; set; }
        }

        public BookingCustomer[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-list-customers?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessListCustomersResponse> BookingbusinessListCustomersAsync()
        {
            var p = new BookingbusinessListCustomersParameter();
            return await this.SendAsync<BookingbusinessListCustomersParameter, BookingbusinessListCustomersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-list-customers?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessListCustomersResponse> BookingbusinessListCustomersAsync(CancellationToken cancellationToken)
        {
            var p = new BookingbusinessListCustomersParameter();
            return await this.SendAsync<BookingbusinessListCustomersParameter, BookingbusinessListCustomersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-list-customers?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessListCustomersResponse> BookingbusinessListCustomersAsync(BookingbusinessListCustomersParameter parameter)
        {
            return await this.SendAsync<BookingbusinessListCustomersParameter, BookingbusinessListCustomersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-list-customers?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessListCustomersResponse> BookingbusinessListCustomersAsync(BookingbusinessListCustomersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingbusinessListCustomersParameter, BookingbusinessListCustomersResponse>(parameter, cancellationToken);
        }
    }
}
