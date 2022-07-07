using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneBooksUserinstallstatesummaryListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceAppManagement_ManagedEBooks_ManagedEBookId_UserStateSummary,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_ManagedEBooks_ManagedEBookId_UserStateSummary: return $"/deviceAppManagement/managedEBooks/{ManagedEBookId}/userStateSummary";
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
    }
    public partial class IntuneBooksUserinstallstatesummaryListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-books-userinstallstatesummary?view=graph-rest-1.0
        /// </summary>
        public partial class UserInstallStateSummary
        {
            public string? Id { get; set; }
            public string? UserName { get; set; }
            public Int32? InstalledDeviceCount { get; set; }
            public Int32? FailedDeviceCount { get; set; }
            public Int32? NotInstalledDeviceCount { get; set; }
        }

        public UserInstallStateSummary[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-userinstallstatesummary-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksUserinstallstatesummaryListResponse> IntuneBooksUserinstallstatesummaryListAsync()
        {
            var p = new IntuneBooksUserinstallstatesummaryListParameter();
            return await this.SendAsync<IntuneBooksUserinstallstatesummaryListParameter, IntuneBooksUserinstallstatesummaryListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-userinstallstatesummary-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksUserinstallstatesummaryListResponse> IntuneBooksUserinstallstatesummaryListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneBooksUserinstallstatesummaryListParameter();
            return await this.SendAsync<IntuneBooksUserinstallstatesummaryListParameter, IntuneBooksUserinstallstatesummaryListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-userinstallstatesummary-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksUserinstallstatesummaryListResponse> IntuneBooksUserinstallstatesummaryListAsync(IntuneBooksUserinstallstatesummaryListParameter parameter)
        {
            return await this.SendAsync<IntuneBooksUserinstallstatesummaryListParameter, IntuneBooksUserinstallstatesummaryListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-userinstallstatesummary-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksUserinstallstatesummaryListResponse> IntuneBooksUserinstallstatesummaryListAsync(IntuneBooksUserinstallstatesummaryListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneBooksUserinstallstatesummaryListParameter, IntuneBooksUserinstallstatesummaryListResponse>(parameter, cancellationToken);
        }
    }
}
