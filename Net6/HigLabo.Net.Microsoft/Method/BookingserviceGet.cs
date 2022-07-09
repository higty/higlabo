using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class BookingserviceGetParameter : IRestApiParameter, IQueryParameterProperty
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

        public enum Field
        {
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
    }
    public partial class BookingserviceGetResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingservice-get?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingserviceGetResponse> BookingserviceGetAsync()
        {
            var p = new BookingserviceGetParameter();
            return await this.SendAsync<BookingserviceGetParameter, BookingserviceGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingservice-get?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingserviceGetResponse> BookingserviceGetAsync(CancellationToken cancellationToken)
        {
            var p = new BookingserviceGetParameter();
            return await this.SendAsync<BookingserviceGetParameter, BookingserviceGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingservice-get?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingserviceGetResponse> BookingserviceGetAsync(BookingserviceGetParameter parameter)
        {
            return await this.SendAsync<BookingserviceGetParameter, BookingserviceGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingservice-get?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingserviceGetResponse> BookingserviceGetAsync(BookingserviceGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingserviceGetParameter, BookingserviceGetResponse>(parameter, cancellationToken);
        }
    }
}
