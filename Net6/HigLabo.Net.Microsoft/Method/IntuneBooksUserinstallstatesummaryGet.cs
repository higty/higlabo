using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneBooksUserinstallstatesummaryGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string ManagedEBookId { get; set; }
        public string UserInstallStateSummaryId { get; set; }
    }
    public partial class IntuneBooksUserinstallstatesummaryGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? UserName { get; set; }
        public Int32? InstalledDeviceCount { get; set; }
        public Int32? FailedDeviceCount { get; set; }
        public Int32? NotInstalledDeviceCount { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-userinstallstatesummary-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksUserinstallstatesummaryGetResponse> IntuneBooksUserinstallstatesummaryGetAsync()
        {
            var p = new IntuneBooksUserinstallstatesummaryGetParameter();
            return await this.SendAsync<IntuneBooksUserinstallstatesummaryGetParameter, IntuneBooksUserinstallstatesummaryGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-userinstallstatesummary-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksUserinstallstatesummaryGetResponse> IntuneBooksUserinstallstatesummaryGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneBooksUserinstallstatesummaryGetParameter();
            return await this.SendAsync<IntuneBooksUserinstallstatesummaryGetParameter, IntuneBooksUserinstallstatesummaryGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-userinstallstatesummary-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksUserinstallstatesummaryGetResponse> IntuneBooksUserinstallstatesummaryGetAsync(IntuneBooksUserinstallstatesummaryGetParameter parameter)
        {
            return await this.SendAsync<IntuneBooksUserinstallstatesummaryGetParameter, IntuneBooksUserinstallstatesummaryGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-userinstallstatesummary-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksUserinstallstatesummaryGetResponse> IntuneBooksUserinstallstatesummaryGetAsync(IntuneBooksUserinstallstatesummaryGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneBooksUserinstallstatesummaryGetParameter, IntuneBooksUserinstallstatesummaryGetResponse>(parameter, cancellationToken);
        }
    }
}
