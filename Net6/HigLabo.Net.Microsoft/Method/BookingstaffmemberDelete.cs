using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class BookingstaffmemberDeleteParameter : IRestApiParameter
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
