using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingstaffmember-get?view=graph-rest-1.0
    /// </summary>
    public partial class BookingstaffmemberGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? BookingBusinessesId { get; set; }
            public string? StaffMembersId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Solutions_BookingBusinesses_Id_StaffMembers_Id: return $"/solutions/bookingBusinesses/{BookingBusinessesId}/staffMembers/{StaffMembersId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Solutions_BookingBusinesses_Id_StaffMembers_Id,
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
    public partial class BookingstaffmemberGetResponse : RestApiResponse
    {
        public enum BookingStaffMemberBookingStaffRole
        {
            Guest,
            Administrator,
            Viewer,
            ExternalGuest,
            UnknownFutureValue,
            Scheduler,
            TeamMember,
        }

        public bool? AvailabilityIsAffectedByPersonalCalendar { get; set; }
        public string? DisplayName { get; set; }
        public string? EmailAddress { get; set; }
        public string? Id { get; set; }
        public bool? IsEmailNotificationEnabled { get; set; }
        public BookingStaffMemberBookingStaffRole Role { get; set; }
        public string? TimeZone { get; set; }
        public bool? UseBusinessHours { get; set; }
        public BookingWorkHours[]? WorkingHours { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingstaffmember-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingstaffmember-get?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingstaffmemberGetResponse> BookingstaffmemberGetAsync()
        {
            var p = new BookingstaffmemberGetParameter();
            return await this.SendAsync<BookingstaffmemberGetParameter, BookingstaffmemberGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingstaffmember-get?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingstaffmemberGetResponse> BookingstaffmemberGetAsync(CancellationToken cancellationToken)
        {
            var p = new BookingstaffmemberGetParameter();
            return await this.SendAsync<BookingstaffmemberGetParameter, BookingstaffmemberGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingstaffmember-get?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingstaffmemberGetResponse> BookingstaffmemberGetAsync(BookingstaffmemberGetParameter parameter)
        {
            return await this.SendAsync<BookingstaffmemberGetParameter, BookingstaffmemberGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingstaffmember-get?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingstaffmemberGetResponse> BookingstaffmemberGetAsync(BookingstaffmemberGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingstaffmemberGetParameter, BookingstaffmemberGetResponse>(parameter, cancellationToken);
        }
    }
}
