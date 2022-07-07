using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneBooksEbookinstallsummaryGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceAppManagement_ManagedEBooks_ManagedEBookId_InstallSummary,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_ManagedEBooks_ManagedEBookId_InstallSummary: return $"/deviceAppManagement/managedEBooks/{ManagedEBookId}/installSummary";
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
    public partial class IntuneBooksEbookinstallsummaryGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public Int32? InstalledDeviceCount { get; set; }
        public Int32? FailedDeviceCount { get; set; }
        public Int32? NotInstalledDeviceCount { get; set; }
        public Int32? InstalledUserCount { get; set; }
        public Int32? FailedUserCount { get; set; }
        public Int32? NotInstalledUserCount { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-ebookinstallsummary-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksEbookinstallsummaryGetResponse> IntuneBooksEbookinstallsummaryGetAsync()
        {
            var p = new IntuneBooksEbookinstallsummaryGetParameter();
            return await this.SendAsync<IntuneBooksEbookinstallsummaryGetParameter, IntuneBooksEbookinstallsummaryGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-ebookinstallsummary-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksEbookinstallsummaryGetResponse> IntuneBooksEbookinstallsummaryGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneBooksEbookinstallsummaryGetParameter();
            return await this.SendAsync<IntuneBooksEbookinstallsummaryGetParameter, IntuneBooksEbookinstallsummaryGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-ebookinstallsummary-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksEbookinstallsummaryGetResponse> IntuneBooksEbookinstallsummaryGetAsync(IntuneBooksEbookinstallsummaryGetParameter parameter)
        {
            return await this.SendAsync<IntuneBooksEbookinstallsummaryGetParameter, IntuneBooksEbookinstallsummaryGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-ebookinstallsummary-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksEbookinstallsummaryGetResponse> IntuneBooksEbookinstallsummaryGetAsync(IntuneBooksEbookinstallsummaryGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneBooksEbookinstallsummaryGetParameter, IntuneBooksEbookinstallsummaryGetResponse>(parameter, cancellationToken);
        }
    }
}
