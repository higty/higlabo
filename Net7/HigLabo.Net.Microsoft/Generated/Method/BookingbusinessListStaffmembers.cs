using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-staffmembers?view=graph-rest-1.0
    /// </summary>
    public partial class BookingbusinessListStaffmembersParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Solutions_BookingBusinesses_Id_StaffMembers: return $"/solutions/bookingBusinesses/{Id}/staffMembers";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            AvailabilityIsAffectedByPersonalCalendar,
            DisplayName,
            EmailAddress,
            Id,
            IsEmailNotificationEnabled,
            Role,
            TimeZone,
            UseBusinessHours,
            WorkingHours,
        }
        public enum ApiPath
        {
            Solutions_BookingBusinesses_Id_StaffMembers,
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
    public partial class BookingbusinessListStaffmembersResponse : RestApiResponse
    {
        public BookingStaffMember[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-staffmembers?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-staffmembers?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingbusinessListStaffmembersResponse> BookingbusinessListStaffmembersAsync()
        {
            var p = new BookingbusinessListStaffmembersParameter();
            return await this.SendAsync<BookingbusinessListStaffmembersParameter, BookingbusinessListStaffmembersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-staffmembers?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingbusinessListStaffmembersResponse> BookingbusinessListStaffmembersAsync(CancellationToken cancellationToken)
        {
            var p = new BookingbusinessListStaffmembersParameter();
            return await this.SendAsync<BookingbusinessListStaffmembersParameter, BookingbusinessListStaffmembersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-staffmembers?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingbusinessListStaffmembersResponse> BookingbusinessListStaffmembersAsync(BookingbusinessListStaffmembersParameter parameter)
        {
            return await this.SendAsync<BookingbusinessListStaffmembersParameter, BookingbusinessListStaffmembersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-staffmembers?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingbusinessListStaffmembersResponse> BookingbusinessListStaffmembersAsync(BookingbusinessListStaffmembersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingbusinessListStaffmembersParameter, BookingbusinessListStaffmembersResponse>(parameter, cancellationToken);
        }
    }
}
