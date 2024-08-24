using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingservice-delete?view=graph-rest-1.0
    /// </summary>
    public partial class BookingServiceDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? BookingBusinessesId { get; set; }
            public string? ServicesId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Solutions_BookingBusinesses_Id_Services_Id: return $"/solutions/bookingBusinesses/{BookingBusinessesId}/services/{ServicesId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Solutions_BookingBusinesses_Id_Services_Id,
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
    public partial class BookingServiceDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingservice-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingservice-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingServiceDeleteResponse> BookingServiceDeleteAsync()
        {
            var p = new BookingServiceDeleteParameter();
            return await this.SendAsync<BookingServiceDeleteParameter, BookingServiceDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingservice-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingServiceDeleteResponse> BookingServiceDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new BookingServiceDeleteParameter();
            return await this.SendAsync<BookingServiceDeleteParameter, BookingServiceDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingservice-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingServiceDeleteResponse> BookingServiceDeleteAsync(BookingServiceDeleteParameter parameter)
        {
            return await this.SendAsync<BookingServiceDeleteParameter, BookingServiceDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingservice-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingServiceDeleteResponse> BookingServiceDeleteAsync(BookingServiceDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingServiceDeleteParameter, BookingServiceDeleteResponse>(parameter, cancellationToken);
        }
    }
}
