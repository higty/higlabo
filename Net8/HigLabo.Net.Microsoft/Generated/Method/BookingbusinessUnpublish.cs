using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-unpublish?view=graph-rest-1.0
    /// </summary>
    public partial class BookingBusinessUnpublishParameter : IRestApiParameter
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
    public partial class BookingBusinessUnpublishResponse : RestApiResponse
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
        public async ValueTask<BookingBusinessUnpublishResponse> BookingBusinessUnpublishAsync()
        {
            var p = new BookingBusinessUnpublishParameter();
            return await this.SendAsync<BookingBusinessUnpublishParameter, BookingBusinessUnpublishResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-unpublish?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingBusinessUnpublishResponse> BookingBusinessUnpublishAsync(CancellationToken cancellationToken)
        {
            var p = new BookingBusinessUnpublishParameter();
            return await this.SendAsync<BookingBusinessUnpublishParameter, BookingBusinessUnpublishResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-unpublish?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingBusinessUnpublishResponse> BookingBusinessUnpublishAsync(BookingBusinessUnpublishParameter parameter)
        {
            return await this.SendAsync<BookingBusinessUnpublishParameter, BookingBusinessUnpublishResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-unpublish?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingBusinessUnpublishResponse> BookingBusinessUnpublishAsync(BookingBusinessUnpublishParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingBusinessUnpublishParameter, BookingBusinessUnpublishResponse>(parameter, cancellationToken);
        }
    }
}
