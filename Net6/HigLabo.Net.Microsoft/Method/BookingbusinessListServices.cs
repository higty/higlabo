using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class BookingbusinessListServicesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Solutions_BookingBusinesses_Id_Services,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Solutions_BookingBusinesses_Id_Services: return $"/solutions/bookingBusinesses/{Id}/services";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string Id { get; set; }
    }
    public partial class BookingbusinessListServicesResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/bookingservice?view=graph-rest-1.0
        /// </summary>
        public partial class BookingService
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
            public bool? IsHiddenFromCustomers { get; set; }
            public bool? IsLocationOnline { get; set; }
            public Int32? MaximumAttendeesCount { get; set; }
            public string? Notes { get; set; }
            public string? PostBuffer { get; set; }
            public string? PreBuffer { get; set; }
            public BookingSchedulingPolicy? SchedulingPolicy { get; set; }
            public bool? SmsNotificationsEnabled { get; set; }
            public String[]? StaffMemberIds { get; set; }
            public string? WebUrl { get; set; }
        }

        public BookingService[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-list-services?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessListServicesResponse> BookingbusinessListServicesAsync()
        {
            var p = new BookingbusinessListServicesParameter();
            return await this.SendAsync<BookingbusinessListServicesParameter, BookingbusinessListServicesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-list-services?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessListServicesResponse> BookingbusinessListServicesAsync(CancellationToken cancellationToken)
        {
            var p = new BookingbusinessListServicesParameter();
            return await this.SendAsync<BookingbusinessListServicesParameter, BookingbusinessListServicesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-list-services?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessListServicesResponse> BookingbusinessListServicesAsync(BookingbusinessListServicesParameter parameter)
        {
            return await this.SendAsync<BookingbusinessListServicesParameter, BookingbusinessListServicesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-list-services?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessListServicesResponse> BookingbusinessListServicesAsync(BookingbusinessListServicesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingbusinessListServicesParameter, BookingbusinessListServicesResponse>(parameter, cancellationToken);
        }
    }
}
