using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class BookingserviceDeleteParameter : IRestApiParameter
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
    public partial class BookingserviceDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingservice-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingserviceDeleteResponse> BookingserviceDeleteAsync()
        {
            var p = new BookingserviceDeleteParameter();
            return await this.SendAsync<BookingserviceDeleteParameter, BookingserviceDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingservice-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingserviceDeleteResponse> BookingserviceDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new BookingserviceDeleteParameter();
            return await this.SendAsync<BookingserviceDeleteParameter, BookingserviceDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingservice-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingserviceDeleteResponse> BookingserviceDeleteAsync(BookingserviceDeleteParameter parameter)
        {
            return await this.SendAsync<BookingserviceDeleteParameter, BookingserviceDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingservice-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingserviceDeleteResponse> BookingserviceDeleteAsync(BookingserviceDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingserviceDeleteParameter, BookingserviceDeleteResponse>(parameter, cancellationToken);
        }
    }
}
