using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-unpublish?view=graph-rest-1.0
    /// </summary>
    public partial class BookingbusinessUnpublishParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Solutions_BookingBusinesses_Id_Unpublish: return $"/solutions/bookingBusinesses/{Id}/unpublish";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Solutions_BookingBusinesses_Id_Unpublish,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
    }
    public partial class BookingbusinessUnpublishResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-unpublish?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-unpublish?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingbusinessUnpublishResponse> BookingbusinessUnpublishAsync()
        {
            var p = new BookingbusinessUnpublishParameter();
            return await this.SendAsync<BookingbusinessUnpublishParameter, BookingbusinessUnpublishResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-unpublish?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingbusinessUnpublishResponse> BookingbusinessUnpublishAsync(CancellationToken cancellationToken)
        {
            var p = new BookingbusinessUnpublishParameter();
            return await this.SendAsync<BookingbusinessUnpublishParameter, BookingbusinessUnpublishResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-unpublish?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingbusinessUnpublishResponse> BookingbusinessUnpublishAsync(BookingbusinessUnpublishParameter parameter)
        {
            return await this.SendAsync<BookingbusinessUnpublishParameter, BookingbusinessUnpublishResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-unpublish?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingbusinessUnpublishResponse> BookingbusinessUnpublishAsync(BookingbusinessUnpublishParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingbusinessUnpublishParameter, BookingbusinessUnpublishResponse>(parameter, cancellationToken);
        }
    }
}
