using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-services?view=graph-rest-1.0
    /// </summary>
    public partial class BookingBusinessListServicesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Solutions_BookingBusinesses_Id_Services: return $"/solutions/bookingBusinesses/{Id}/services";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Solutions_BookingBusinesses_Id_Services,
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
    public partial class BookingBusinessListServicesResponse : RestApiResponse<BookingService>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-services?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-services?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingBusinessListServicesResponse> BookingBusinessListServicesAsync()
        {
            var p = new BookingBusinessListServicesParameter();
            return await this.SendAsync<BookingBusinessListServicesParameter, BookingBusinessListServicesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-services?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingBusinessListServicesResponse> BookingBusinessListServicesAsync(CancellationToken cancellationToken)
        {
            var p = new BookingBusinessListServicesParameter();
            return await this.SendAsync<BookingBusinessListServicesParameter, BookingBusinessListServicesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-services?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingBusinessListServicesResponse> BookingBusinessListServicesAsync(BookingBusinessListServicesParameter parameter)
        {
            return await this.SendAsync<BookingBusinessListServicesParameter, BookingBusinessListServicesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-services?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingBusinessListServicesResponse> BookingBusinessListServicesAsync(BookingBusinessListServicesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingBusinessListServicesParameter, BookingBusinessListServicesResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-services?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<BookingService> BookingBusinessListServicesEnumerateAsync(BookingBusinessListServicesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<BookingBusinessListServicesParameter, BookingBusinessListServicesResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<BookingService>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
