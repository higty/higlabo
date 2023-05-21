using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list?view=graph-rest-1.0
    /// </summary>
    public partial class BookingbusinessListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Solutions_BookingBusinesses: return $"/solutions/bookingBusinesses";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Address,
            BusinessHours,
            BusinessType,
            DefaultCurrencyIso,
            DisplayName,
            Email,
            Id,
            IsPublished,
            LanguageTag,
            Phone,
            PublicUrl,
            SchedulingPolicy,
            WebSiteUrl,
            Appointments,
            CalendarView,
            Customers,
            CustomQuestions,
            Services,
            StaffMembers,
        }
        public enum ApiPath
        {
            Solutions_BookingBusinesses,
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
    public partial class BookingbusinessListResponse : RestApiResponse
    {
        public BookingBusiness[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessListResponse> BookingbusinessListAsync()
        {
            var p = new BookingbusinessListParameter();
            return await this.SendAsync<BookingbusinessListParameter, BookingbusinessListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessListResponse> BookingbusinessListAsync(CancellationToken cancellationToken)
        {
            var p = new BookingbusinessListParameter();
            return await this.SendAsync<BookingbusinessListParameter, BookingbusinessListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessListResponse> BookingbusinessListAsync(BookingbusinessListParameter parameter)
        {
            return await this.SendAsync<BookingbusinessListParameter, BookingbusinessListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessListResponse> BookingbusinessListAsync(BookingbusinessListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingbusinessListParameter, BookingbusinessListResponse>(parameter, cancellationToken);
        }
    }
}
