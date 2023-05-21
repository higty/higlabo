using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-delete?view=graph-rest-1.0
    /// </summary>
    public partial class BookingbusinessDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Solutions_BookingBusinesses_Id: return $"/solutions/bookingBusinesses/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Solutions_BookingBusinesses_Id,
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
    public partial class BookingbusinessDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessDeleteResponse> BookingbusinessDeleteAsync()
        {
            var p = new BookingbusinessDeleteParameter();
            return await this.SendAsync<BookingbusinessDeleteParameter, BookingbusinessDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessDeleteResponse> BookingbusinessDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new BookingbusinessDeleteParameter();
            return await this.SendAsync<BookingbusinessDeleteParameter, BookingbusinessDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessDeleteResponse> BookingbusinessDeleteAsync(BookingbusinessDeleteParameter parameter)
        {
            return await this.SendAsync<BookingbusinessDeleteParameter, BookingbusinessDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessDeleteResponse> BookingbusinessDeleteAsync(BookingbusinessDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingbusinessDeleteParameter, BookingbusinessDeleteResponse>(parameter, cancellationToken);
        }
    }
}
