using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-publish?view=graph-rest-1.0
    /// </summary>
    public partial class BookingBusinessPublishParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Solutions_BookingBusinesses_Id_Publish: return $"/solutions/bookingBusinesses/{Id}/publish";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Solutions_BookingBusinesses_Id_Publish,
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
    public partial class BookingBusinessPublishResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-publish?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-publish?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingBusinessPublishResponse> BookingBusinessPublishAsync()
        {
            var p = new BookingBusinessPublishParameter();
            return await this.SendAsync<BookingBusinessPublishParameter, BookingBusinessPublishResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-publish?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingBusinessPublishResponse> BookingBusinessPublishAsync(CancellationToken cancellationToken)
        {
            var p = new BookingBusinessPublishParameter();
            return await this.SendAsync<BookingBusinessPublishParameter, BookingBusinessPublishResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-publish?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingBusinessPublishResponse> BookingBusinessPublishAsync(BookingBusinessPublishParameter parameter)
        {
            return await this.SendAsync<BookingBusinessPublishParameter, BookingBusinessPublishResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-publish?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingBusinessPublishResponse> BookingBusinessPublishAsync(BookingBusinessPublishParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingBusinessPublishParameter, BookingBusinessPublishResponse>(parameter, cancellationToken);
        }
    }
}
