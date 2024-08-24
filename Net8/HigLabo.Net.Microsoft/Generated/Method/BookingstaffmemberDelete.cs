using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingstaffmember-delete?view=graph-rest-1.0
    /// </summary>
    public partial class BookingStaffMemberDeleteParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class BookingStaffMemberDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingstaffmember-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingstaffmember-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingStaffMemberDeleteResponse> BookingStaffMemberDeleteAsync()
        {
            var p = new BookingStaffMemberDeleteParameter();
            return await this.SendAsync<BookingStaffMemberDeleteParameter, BookingStaffMemberDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingstaffmember-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingStaffMemberDeleteResponse> BookingStaffMemberDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new BookingStaffMemberDeleteParameter();
            return await this.SendAsync<BookingStaffMemberDeleteParameter, BookingStaffMemberDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingstaffmember-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingStaffMemberDeleteResponse> BookingStaffMemberDeleteAsync(BookingStaffMemberDeleteParameter parameter)
        {
            return await this.SendAsync<BookingStaffMemberDeleteParameter, BookingStaffMemberDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingstaffmember-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingStaffMemberDeleteResponse> BookingStaffMemberDeleteAsync(BookingStaffMemberDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingStaffMemberDeleteParameter, BookingStaffMemberDeleteResponse>(parameter, cancellationToken);
        }
    }
}
