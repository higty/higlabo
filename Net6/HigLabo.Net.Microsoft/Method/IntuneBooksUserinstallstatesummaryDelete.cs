using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneBooksUserinstallstatesummaryDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceAppManagement_ManagedEBooks_ManagedEBookId_UserStateSummary_UserInstallStateSummaryId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_ManagedEBooks_ManagedEBookId_UserStateSummary_UserInstallStateSummaryId: return $"/deviceAppManagement/managedEBooks/{ManagedEBookId}/userStateSummary/{UserInstallStateSummaryId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string ManagedEBookId { get; set; }
        public string UserInstallStateSummaryId { get; set; }
    }
    public partial class IntuneBooksUserinstallstatesummaryDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-userinstallstatesummary-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksUserinstallstatesummaryDeleteResponse> IntuneBooksUserinstallstatesummaryDeleteAsync()
        {
            var p = new IntuneBooksUserinstallstatesummaryDeleteParameter();
            return await this.SendAsync<IntuneBooksUserinstallstatesummaryDeleteParameter, IntuneBooksUserinstallstatesummaryDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-userinstallstatesummary-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksUserinstallstatesummaryDeleteResponse> IntuneBooksUserinstallstatesummaryDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneBooksUserinstallstatesummaryDeleteParameter();
            return await this.SendAsync<IntuneBooksUserinstallstatesummaryDeleteParameter, IntuneBooksUserinstallstatesummaryDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-userinstallstatesummary-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksUserinstallstatesummaryDeleteResponse> IntuneBooksUserinstallstatesummaryDeleteAsync(IntuneBooksUserinstallstatesummaryDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneBooksUserinstallstatesummaryDeleteParameter, IntuneBooksUserinstallstatesummaryDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-userinstallstatesummary-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksUserinstallstatesummaryDeleteResponse> IntuneBooksUserinstallstatesummaryDeleteAsync(IntuneBooksUserinstallstatesummaryDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneBooksUserinstallstatesummaryDeleteParameter, IntuneBooksUserinstallstatesummaryDeleteResponse>(parameter, cancellationToken);
        }
    }
}
