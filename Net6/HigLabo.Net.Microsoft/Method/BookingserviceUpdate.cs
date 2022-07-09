using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class BookingserviceUpdateParameter : IRestApiParameter
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

        public enum BookingserviceUpdateParameterBookingPriceType
        {
            Undefined,
            FixedPrice,
            StartingAt,
            Hourly,
            Free,
            PriceVaries,
            CallUs,
            NotSet,
            UnknownFutureValue,
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
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public BookingQuestionAssignment[]? CustomQuestions { get; set; }
        public string? DefaultDuration { get; set; }
        public Location? DefaultLocation { get; set; }
        public Double? DefaultPrice { get; set; }
        public BookingserviceUpdateParameterBookingPriceType DefaultPriceType { get; set; }
        public BookingReminder[]? DefaultReminders { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public bool? IsHiddenFromCustomers { get; set; }
        public bool? IsLocationOnline { get; set; }
        public Int32? MaximumAttendeesCount { get; set; }
        public string? Notes { get; set; }
        public string? PostBuffer { get; set; }
        public string? PreBuffer { get; set; }
        public BookingSchedulingPolicy? SchedulingPolicy { get; set; }
        public bool? SmsNotificationsEnabled { get; set; }
        public String[]? StaffMemberIds { get; set; }
    }
    public partial class BookingserviceUpdateResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingservice-update?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingserviceUpdateResponse> BookingserviceUpdateAsync()
        {
            var p = new BookingserviceUpdateParameter();
            return await this.SendAsync<BookingserviceUpdateParameter, BookingserviceUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingservice-update?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingserviceUpdateResponse> BookingserviceUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new BookingserviceUpdateParameter();
            return await this.SendAsync<BookingserviceUpdateParameter, BookingserviceUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingservice-update?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingserviceUpdateResponse> BookingserviceUpdateAsync(BookingserviceUpdateParameter parameter)
        {
            return await this.SendAsync<BookingserviceUpdateParameter, BookingserviceUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingservice-update?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingserviceUpdateResponse> BookingserviceUpdateAsync(BookingserviceUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingserviceUpdateParameter, BookingserviceUpdateResponse>(parameter, cancellationToken);
        }
    }
}
