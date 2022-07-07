using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneBooksDeviceinstallstateGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceAppManagement_ManagedEBooks_ManagedEBookId_DeviceStates_DeviceInstallStateId,
            DeviceAppManagement_ManagedEBooks_ManagedEBookId_UserStateSummary_UserInstallStateSummaryId_DeviceStates_DeviceInstallStateId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_ManagedEBooks_ManagedEBookId_DeviceStates_DeviceInstallStateId: return $"/deviceAppManagement/managedEBooks/{ManagedEBookId}/deviceStates/{DeviceInstallStateId}";
                    case ApiPath.DeviceAppManagement_ManagedEBooks_ManagedEBookId_UserStateSummary_UserInstallStateSummaryId_DeviceStates_DeviceInstallStateId: return $"/deviceAppManagement/managedEBooks/{ManagedEBookId}/userStateSummary/{UserInstallStateSummaryId}/deviceStates/{DeviceInstallStateId}";
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
        public string DeviceInstallStateId { get; set; }
        public string UserInstallStateSummaryId { get; set; }
    }
    public partial class IntuneBooksDeviceinstallstateGetResponse : RestApiResponse
    {
        public enum DeviceInstallStateInstallState
        {
            NotApplicable,
            Installed,
            Failed,
            NotInstalled,
            UninstallFailed,
            Unknown,
        }

        public string? Id { get; set; }
        public string? DeviceName { get; set; }
        public string? DeviceId { get; set; }
        public DateTimeOffset? LastSyncDateTime { get; set; }
        public InstallState? InstallState { get; set; }
        public string? ErrorCode { get; set; }
        public string? OsVersion { get; set; }
        public string? OsDescription { get; set; }
        public string? UserName { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-deviceinstallstate-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksDeviceinstallstateGetResponse> IntuneBooksDeviceinstallstateGetAsync()
        {
            var p = new IntuneBooksDeviceinstallstateGetParameter();
            return await this.SendAsync<IntuneBooksDeviceinstallstateGetParameter, IntuneBooksDeviceinstallstateGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-deviceinstallstate-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksDeviceinstallstateGetResponse> IntuneBooksDeviceinstallstateGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneBooksDeviceinstallstateGetParameter();
            return await this.SendAsync<IntuneBooksDeviceinstallstateGetParameter, IntuneBooksDeviceinstallstateGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-deviceinstallstate-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksDeviceinstallstateGetResponse> IntuneBooksDeviceinstallstateGetAsync(IntuneBooksDeviceinstallstateGetParameter parameter)
        {
            return await this.SendAsync<IntuneBooksDeviceinstallstateGetParameter, IntuneBooksDeviceinstallstateGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-deviceinstallstate-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksDeviceinstallstateGetResponse> IntuneBooksDeviceinstallstateGetAsync(IntuneBooksDeviceinstallstateGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneBooksDeviceinstallstateGetParameter, IntuneBooksDeviceinstallstateGetResponse>(parameter, cancellationToken);
        }
    }
}
