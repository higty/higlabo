using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-customers?view=graph-rest-1.0
    /// </summary>
    public partial class BookingbusinessListCustomersParameter : IRestApiParameter, IQueryParameterProperty
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

        public enum Field
        {
            Addresses,
            DisplayName,
            EmailAddress,
            Id,
            Phones,
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
    public partial class BookingbusinessListCustomersResponse : RestApiResponse
    {
        public BookingCustomer[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-customers?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-customers?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingbusinessListCustomersResponse> BookingbusinessListCustomersAsync()
        {
            var p = new BookingbusinessListCustomersParameter();
            return await this.SendAsync<BookingbusinessListCustomersParameter, BookingbusinessListCustomersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-customers?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingbusinessListCustomersResponse> BookingbusinessListCustomersAsync(CancellationToken cancellationToken)
        {
            var p = new BookingbusinessListCustomersParameter();
            return await this.SendAsync<BookingbusinessListCustomersParameter, BookingbusinessListCustomersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-customers?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingbusinessListCustomersResponse> BookingbusinessListCustomersAsync(BookingbusinessListCustomersParameter parameter)
        {
            return await this.SendAsync<BookingbusinessListCustomersParameter, BookingbusinessListCustomersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-customers?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingbusinessListCustomersResponse> BookingbusinessListCustomersAsync(BookingbusinessListCustomersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingbusinessListCustomersParameter, BookingbusinessListCustomersResponse>(parameter, cancellationToken);
        }
    }
}
