using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-post-services?view=graph-rest-1.0
    /// </summary>
    public partial class BookingbusinessPostServicesParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Solutions_BookingBusinesses_Id_Services: return $"/solutions/bookingBusinesses/{Id}/services";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum BookingServiceBookingPriceType
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
            Solutions_BookingBusinesses_Id_Services,
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
        public string? AdditionalInformation { get; set; }
        public BookingQuestionAssignment[]? CustomQuestions { get; set; }
        public string? DefaultDuration { get; set; }
        public Location? DefaultLocation { get; set; }
        public Double? DefaultPrice { get; set; }
        public BookingServiceBookingPriceType DefaultPriceType { get; set; }
        public BookingReminder[]? DefaultReminders { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public bool? IsAnonymousJoinEnabled { get; set; }
        public bool? IsHiddenFromCustomers { get; set; }
        public bool? IsLocationOnline { get; set; }
        public string? LanguageTag { get; set; }
        public Int32? MaximumAttendeesCount { get; set; }
        public string? Notes { get; set; }
        public string? PostBuffer { get; set; }
        public string? PreBuffer { get; set; }
        public BookingSchedulingPolicy? SchedulingPolicy { get; set; }
        public bool? SmsNotificationsEnabled { get; set; }
        public String[]? StaffMemberIds { get; set; }
        public string? WebUrl { get; set; }
    }
    public partial class BookingbusinessPostServicesResponse : RestApiResponse
    {
        public enum BookingServiceBookingPriceType
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

        public string? AdditionalInformation { get; set; }
        public BookingQuestionAssignment[]? CustomQuestions { get; set; }
        public string? DefaultDuration { get; set; }
        public Location? DefaultLocation { get; set; }
        public Double? DefaultPrice { get; set; }
        public BookingServiceBookingPriceType DefaultPriceType { get; set; }
        public BookingReminder[]? DefaultReminders { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public bool? IsAnonymousJoinEnabled { get; set; }
        public bool? IsHiddenFromCustomers { get; set; }
        public bool? IsLocationOnline { get; set; }
        public string? LanguageTag { get; set; }
        public Int32? MaximumAttendeesCount { get; set; }
        public string? Notes { get; set; }
        public string? PostBuffer { get; set; }
        public string? PreBuffer { get; set; }
        public BookingSchedulingPolicy? SchedulingPolicy { get; set; }
        public bool? SmsNotificationsEnabled { get; set; }
        public String[]? StaffMemberIds { get; set; }
        public string? WebUrl { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-post-services?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-post-services?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessPostServicesResponse> BookingbusinessPostServicesAsync()
        {
            var p = new BookingbusinessPostServicesParameter();
            return await this.SendAsync<BookingbusinessPostServicesParameter, BookingbusinessPostServicesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-post-services?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessPostServicesResponse> BookingbusinessPostServicesAsync(CancellationToken cancellationToken)
        {
            var p = new BookingbusinessPostServicesParameter();
            return await this.SendAsync<BookingbusinessPostServicesParameter, BookingbusinessPostServicesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-post-services?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessPostServicesResponse> BookingbusinessPostServicesAsync(BookingbusinessPostServicesParameter parameter)
        {
            return await this.SendAsync<BookingbusinessPostServicesParameter, BookingbusinessPostServicesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-post-services?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessPostServicesResponse> BookingbusinessPostServicesAsync(BookingbusinessPostServicesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingbusinessPostServicesParameter, BookingbusinessPostServicesResponse>(parameter, cancellationToken);
        }
    }
}
