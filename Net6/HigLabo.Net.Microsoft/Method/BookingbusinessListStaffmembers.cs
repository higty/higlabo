using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class BookingbusinessListStaffmembersParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Solutions_BookingBusinesses_Id_StaffMembers,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Solutions_BookingBusinesses_Id_StaffMembers: return $"/solutions/bookingBusinesses/{Id}/staffMembers";
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
    public partial class BookingbusinessListStaffmembersResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/bookingstaffmember?view=graph-rest-1.0
        /// </summary>
        public partial class BookingStaffMember
        {
            public enum BookingStaffMemberBookingStaffRole
            {
                Guest,
                Administrator,
                Viewer,
                ExternalGuest,
                UnknownFutureValue,
            }

            public bool? AvailabilityIsAffectedByPersonalCalendar { get; set; }
            public string? DisplayName { get; set; }
            public string? EmailAddress { get; set; }
            public string? Id { get; set; }
            public BookingStaffMemberBookingStaffRole Role { get; set; }
            public string? TimeZone { get; set; }
            public bool? UseBusinessHours { get; set; }
            public BookingWorkHours[]? WorkingHours { get; set; }
        }

        public BookingStaffMember[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-list-staffmembers?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessListStaffmembersResponse> BookingbusinessListStaffmembersAsync()
        {
            var p = new BookingbusinessListStaffmembersParameter();
            return await this.SendAsync<BookingbusinessListStaffmembersParameter, BookingbusinessListStaffmembersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-list-staffmembers?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessListStaffmembersResponse> BookingbusinessListStaffmembersAsync(CancellationToken cancellationToken)
        {
            var p = new BookingbusinessListStaffmembersParameter();
            return await this.SendAsync<BookingbusinessListStaffmembersParameter, BookingbusinessListStaffmembersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-list-staffmembers?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessListStaffmembersResponse> BookingbusinessListStaffmembersAsync(BookingbusinessListStaffmembersParameter parameter)
        {
            return await this.SendAsync<BookingbusinessListStaffmembersParameter, BookingbusinessListStaffmembersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-list-staffmembers?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessListStaffmembersResponse> BookingbusinessListStaffmembersAsync(BookingbusinessListStaffmembersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingbusinessListStaffmembersParameter, BookingbusinessListStaffmembersResponse>(parameter, cancellationToken);
        }
    }
}
