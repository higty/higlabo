using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class BookingbusinessPostStaffmembersParameter : IRestApiParameter
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
        public BookingStaffMemberBookingStaffRole Role { get; set; }
        public string? TimeZone { get; set; }
        public bool? UseBusinessHours { get; set; }
        public BookingWorkHours[]? WorkingHours { get; set; }
    }
    public partial class BookingbusinessPostStaffmembersResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-post-staffmembers?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessPostStaffmembersResponse> BookingbusinessPostStaffmembersAsync()
        {
            var p = new BookingbusinessPostStaffmembersParameter();
            return await this.SendAsync<BookingbusinessPostStaffmembersParameter, BookingbusinessPostStaffmembersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-post-staffmembers?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessPostStaffmembersResponse> BookingbusinessPostStaffmembersAsync(CancellationToken cancellationToken)
        {
            var p = new BookingbusinessPostStaffmembersParameter();
            return await this.SendAsync<BookingbusinessPostStaffmembersParameter, BookingbusinessPostStaffmembersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-post-staffmembers?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessPostStaffmembersResponse> BookingbusinessPostStaffmembersAsync(BookingbusinessPostStaffmembersParameter parameter)
        {
            return await this.SendAsync<BookingbusinessPostStaffmembersParameter, BookingbusinessPostStaffmembersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-post-staffmembers?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessPostStaffmembersResponse> BookingbusinessPostStaffmembersAsync(BookingbusinessPostStaffmembersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingbusinessPostStaffmembersParameter, BookingbusinessPostStaffmembersResponse>(parameter, cancellationToken);
        }
    }
}
