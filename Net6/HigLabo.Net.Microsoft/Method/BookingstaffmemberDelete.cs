using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class BookingstaffmemberDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Solutions_BookingBusinesses_Id_StaffMembers_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Solutions_BookingBusinesses_Id_StaffMembers_Id: return $"/solutions/bookingBusinesses/{BookingBusinessesId}/staffMembers/{StaffMembersId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string BookingBusinessesId { get; set; }
        public string StaffMembersId { get; set; }
    }
    public partial class BookingstaffmemberDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingstaffmember-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingstaffmemberDeleteResponse> BookingstaffmemberDeleteAsync()
        {
            var p = new BookingstaffmemberDeleteParameter();
            return await this.SendAsync<BookingstaffmemberDeleteParameter, BookingstaffmemberDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingstaffmember-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingstaffmemberDeleteResponse> BookingstaffmemberDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new BookingstaffmemberDeleteParameter();
            return await this.SendAsync<BookingstaffmemberDeleteParameter, BookingstaffmemberDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingstaffmember-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingstaffmemberDeleteResponse> BookingstaffmemberDeleteAsync(BookingstaffmemberDeleteParameter parameter)
        {
            return await this.SendAsync<BookingstaffmemberDeleteParameter, BookingstaffmemberDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingstaffmember-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingstaffmemberDeleteResponse> BookingstaffmemberDeleteAsync(BookingstaffmemberDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingstaffmemberDeleteParameter, BookingstaffmemberDeleteResponse>(parameter, cancellationToken);
        }
    }
}
