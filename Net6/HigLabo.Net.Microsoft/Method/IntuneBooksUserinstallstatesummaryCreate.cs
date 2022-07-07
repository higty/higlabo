using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneBooksUserinstallstatesummaryCreateParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public string? UserName { get; set; }
        public Int32? InstalledDeviceCount { get; set; }
        public Int32? FailedDeviceCount { get; set; }
        public Int32? NotInstalledDeviceCount { get; set; }
        public string ManagedEBookId { get; set; }
    }
    public partial class IntuneBooksUserinstallstatesummaryCreateResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-userinstallstatesummary-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksUserinstallstatesummaryCreateResponse> IntuneBooksUserinstallstatesummaryCreateAsync()
        {
            var p = new IntuneBooksUserinstallstatesummaryCreateParameter();
            return await this.SendAsync<IntuneBooksUserinstallstatesummaryCreateParameter, IntuneBooksUserinstallstatesummaryCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-userinstallstatesummary-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksUserinstallstatesummaryCreateResponse> IntuneBooksUserinstallstatesummaryCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneBooksUserinstallstatesummaryCreateParameter();
            return await this.SendAsync<IntuneBooksUserinstallstatesummaryCreateParameter, IntuneBooksUserinstallstatesummaryCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-userinstallstatesummary-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksUserinstallstatesummaryCreateResponse> IntuneBooksUserinstallstatesummaryCreateAsync(IntuneBooksUserinstallstatesummaryCreateParameter parameter)
        {
            return await this.SendAsync<IntuneBooksUserinstallstatesummaryCreateParameter, IntuneBooksUserinstallstatesummaryCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-userinstallstatesummary-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksUserinstallstatesummaryCreateResponse> IntuneBooksUserinstallstatesummaryCreateAsync(IntuneBooksUserinstallstatesummaryCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneBooksUserinstallstatesummaryCreateParameter, IntuneBooksUserinstallstatesummaryCreateResponse>(parameter, cancellationToken);
        }
    }
}
