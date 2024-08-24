using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-post-staffmembers?view=graph-rest-1.0
    /// </summary>
    public partial class BookingBusinessPostStaffMembersParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
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
    public partial class BookingBusinessPostStaffMembersResponse : RestApiResponse
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
    /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-post-staffmembers?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-post-staffmembers?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingBusinessPostStaffMembersResponse> BookingBusinessPostStaffMembersAsync()
        {
            var p = new BookingBusinessPostStaffMembersParameter();
            return await this.SendAsync<BookingBusinessPostStaffMembersParameter, BookingBusinessPostStaffMembersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-post-staffmembers?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingBusinessPostStaffMembersResponse> BookingBusinessPostStaffMembersAsync(CancellationToken cancellationToken)
        {
            var p = new BookingBusinessPostStaffMembersParameter();
            return await this.SendAsync<BookingBusinessPostStaffMembersParameter, BookingBusinessPostStaffMembersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-post-staffmembers?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingBusinessPostStaffMembersResponse> BookingBusinessPostStaffMembersAsync(BookingBusinessPostStaffMembersParameter parameter)
        {
            return await this.SendAsync<BookingBusinessPostStaffMembersParameter, BookingBusinessPostStaffMembersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-post-staffmembers?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingBusinessPostStaffMembersResponse> BookingBusinessPostStaffMembersAsync(BookingBusinessPostStaffMembersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingBusinessPostStaffMembersParameter, BookingBusinessPostStaffMembersResponse>(parameter, cancellationToken);
        }
    }
}
