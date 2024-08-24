using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-customers?view=graph-rest-1.0
    /// </summary>
    public partial class BookingBusinessListCustomersParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class BookingBusinessListCustomersResponse : RestApiResponse<BookingCustomer>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-customers?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-customers?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingBusinessListCustomersResponse> BookingBusinessListCustomersAsync()
        {
            var p = new BookingBusinessListCustomersParameter();
            return await this.SendAsync<BookingBusinessListCustomersParameter, BookingBusinessListCustomersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-customers?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingBusinessListCustomersResponse> BookingBusinessListCustomersAsync(CancellationToken cancellationToken)
        {
            var p = new BookingBusinessListCustomersParameter();
            return await this.SendAsync<BookingBusinessListCustomersParameter, BookingBusinessListCustomersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-customers?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingBusinessListCustomersResponse> BookingBusinessListCustomersAsync(BookingBusinessListCustomersParameter parameter)
        {
            return await this.SendAsync<BookingBusinessListCustomersParameter, BookingBusinessListCustomersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-customers?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingBusinessListCustomersResponse> BookingBusinessListCustomersAsync(BookingBusinessListCustomersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingBusinessListCustomersParameter, BookingBusinessListCustomersResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-customers?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<BookingCustomer> BookingBusinessListCustomersEnumerateAsync(BookingBusinessListCustomersParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<BookingBusinessListCustomersParameter, BookingBusinessListCustomersResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<BookingCustomer>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
