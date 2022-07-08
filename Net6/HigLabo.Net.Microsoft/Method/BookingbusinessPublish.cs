using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class BookingbusinessPublishParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }

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
    public partial class BookingbusinessPublishResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-publish?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessPublishResponse> BookingbusinessPublishAsync()
        {
            var p = new BookingbusinessPublishParameter();
            return await this.SendAsync<BookingbusinessPublishParameter, BookingbusinessPublishResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-publish?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessPublishResponse> BookingbusinessPublishAsync(CancellationToken cancellationToken)
        {
            var p = new BookingbusinessPublishParameter();
            return await this.SendAsync<BookingbusinessPublishParameter, BookingbusinessPublishResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-publish?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessPublishResponse> BookingbusinessPublishAsync(BookingbusinessPublishParameter parameter)
        {
            return await this.SendAsync<BookingbusinessPublishParameter, BookingbusinessPublishResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-publish?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessPublishResponse> BookingbusinessPublishAsync(BookingbusinessPublishParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingbusinessPublishParameter, BookingbusinessPublishResponse>(parameter, cancellationToken);
        }
    }
}
