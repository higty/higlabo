using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-services?view=graph-rest-1.0
    /// </summary>
    public partial class BookingbusinessListServicesParameter : IRestApiParameter, IQueryParameterProperty
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

        public enum Field
        {
            AdditionalInformation,
            CustomQuestions,
            DefaultDuration,
            DefaultLocation,
            DefaultPrice,
            DefaultPriceType,
            DefaultReminders,
            Description,
            DisplayName,
            Id,
            IsAnonymousJoinEnabled,
            IsHiddenFromCustomers,
            IsLocationOnline,
            LanguageTag,
            MaximumAttendeesCount,
            Notes,
            PostBuffer,
            PreBuffer,
            SchedulingPolicy,
            SmsNotificationsEnabled,
            StaffMemberIds,
            WebUrl,
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
    public partial class BookingbusinessListServicesResponse : RestApiResponse
    {
        public BookingService[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-services?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-services?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingbusinessListServicesResponse> BookingbusinessListServicesAsync()
        {
            var p = new BookingbusinessListServicesParameter();
            return await this.SendAsync<BookingbusinessListServicesParameter, BookingbusinessListServicesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-services?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingbusinessListServicesResponse> BookingbusinessListServicesAsync(CancellationToken cancellationToken)
        {
            var p = new BookingbusinessListServicesParameter();
            return await this.SendAsync<BookingbusinessListServicesParameter, BookingbusinessListServicesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-services?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingbusinessListServicesResponse> BookingbusinessListServicesAsync(BookingbusinessListServicesParameter parameter)
        {
            return await this.SendAsync<BookingbusinessListServicesParameter, BookingbusinessListServicesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-services?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingbusinessListServicesResponse> BookingbusinessListServicesAsync(BookingbusinessListServicesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingbusinessListServicesParameter, BookingbusinessListServicesResponse>(parameter, cancellationToken);
        }
    }
}
