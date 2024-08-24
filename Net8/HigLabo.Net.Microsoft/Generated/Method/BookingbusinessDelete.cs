using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-delete?view=graph-rest-1.0
    /// </summary>
    public partial class BookingBusinessDeleteParameter : IRestApiParameter
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
    public partial class BookingBusinessDeleteResponse : RestApiResponse
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
        public async ValueTask<BookingBusinessDeleteResponse> BookingBusinessDeleteAsync()
        {
            var p = new BookingBusinessDeleteParameter();
            return await this.SendAsync<BookingBusinessDeleteParameter, BookingBusinessDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingBusinessDeleteResponse> BookingBusinessDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new BookingBusinessDeleteParameter();
            return await this.SendAsync<BookingBusinessDeleteParameter, BookingBusinessDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingBusinessDeleteResponse> BookingBusinessDeleteAsync(BookingBusinessDeleteParameter parameter)
        {
            return await this.SendAsync<BookingBusinessDeleteParameter, BookingBusinessDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingBusinessDeleteResponse> BookingBusinessDeleteAsync(BookingBusinessDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingBusinessDeleteParameter, BookingBusinessDeleteResponse>(parameter, cancellationToken);
        }
    }
}
