using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class BookingstaffmemberUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string BookingBusinessesId { get; set; }
            public string StaffMembersId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Solutions_BookingBusinesses_Id_StaffMembers_Id: return $"/solutions/bookingBusinesses/{BookingBusinessesId}/staffMembers/{StaffMembersId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum BookingstaffmemberUpdateParameterstring
        {
            Guest,
            Administrator,
            Viewer,
            ExternalGuest,
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
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public bool? AvailabilityIsAffectedByPersonalCalendar { get; set; }
        public string? DisplayName { get; set; }
        public string? EmailAddress { get; set; }
        public BookingstaffmemberUpdateParameterstring Role { get; set; }
        public string? TimeZone { get; set; }
        public bool? UseBusinessHours { get; set; }
        public BookingWorkHours[]? WorkingHours { get; set; }
    }
    public partial class BookingstaffmemberUpdateResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingstaffmember-update?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingstaffmemberUpdateResponse> BookingstaffmemberUpdateAsync()
        {
            var p = new BookingstaffmemberUpdateParameter();
            return await this.SendAsync<BookingstaffmemberUpdateParameter, BookingstaffmemberUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingstaffmember-update?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingstaffmemberUpdateResponse> BookingstaffmemberUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new BookingstaffmemberUpdateParameter();
            return await this.SendAsync<BookingstaffmemberUpdateParameter, BookingstaffmemberUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingstaffmember-update?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingstaffmemberUpdateResponse> BookingstaffmemberUpdateAsync(BookingstaffmemberUpdateParameter parameter)
        {
            return await this.SendAsync<BookingstaffmemberUpdateParameter, BookingstaffmemberUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingstaffmember-update?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingstaffmemberUpdateResponse> BookingstaffmemberUpdateAsync(BookingstaffmemberUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingstaffmemberUpdateParameter, BookingstaffmemberUpdateResponse>(parameter, cancellationToken);
        }
    }
}
