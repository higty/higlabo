using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class BookingbusinessUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }

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
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public PhysicalAddress? Address { get; set; }
        public BookingWorkHours[]? BusinessHours { get; set; }
        public string? BusinessType { get; set; }
        public string? DefaultCurrencyIso { get; set; }
        public string? DisplayName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public BookingSchedulingPolicy? SchedulingPolicy { get; set; }
        public string? WebSiteUrl { get; set; }
    }
    public partial class BookingbusinessUpdateResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-update?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessUpdateResponse> BookingbusinessUpdateAsync()
        {
            var p = new BookingbusinessUpdateParameter();
            return await this.SendAsync<BookingbusinessUpdateParameter, BookingbusinessUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-update?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessUpdateResponse> BookingbusinessUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new BookingbusinessUpdateParameter();
            return await this.SendAsync<BookingbusinessUpdateParameter, BookingbusinessUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-update?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessUpdateResponse> BookingbusinessUpdateAsync(BookingbusinessUpdateParameter parameter)
        {
            return await this.SendAsync<BookingbusinessUpdateParameter, BookingbusinessUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-update?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessUpdateResponse> BookingbusinessUpdateAsync(BookingbusinessUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingbusinessUpdateParameter, BookingbusinessUpdateResponse>(parameter, cancellationToken);
        }
    }
}
