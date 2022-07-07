using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneBooksDeviceinstallstateCreateParameter : IRestApiParameter
    {
        public enum IntuneBooksDeviceinstallstateCreateParameterInstallState
        {
            NotApplicable,
            Installed,
            Failed,
            NotInstalled,
            UninstallFailed,
            Unknown,
        }
        public enum ApiPath
        {
            DeviceAppManagement_ManagedEBooks_ManagedEBookId_DeviceStates,
            DeviceAppManagement_ManagedEBooks_ManagedEBookId_UserStateSummary_UserInstallStateSummaryId_DeviceStates,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_ManagedEBooks_ManagedEBookId_DeviceStates: return $"/deviceAppManagement/managedEBooks/{ManagedEBookId}/deviceStates";
                    case ApiPath.DeviceAppManagement_ManagedEBooks_ManagedEBookId_UserStateSummary_UserInstallStateSummaryId_DeviceStates: return $"/deviceAppManagement/managedEBooks/{ManagedEBookId}/userStateSummary/{UserInstallStateSummaryId}/deviceStates";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public string? DeviceName { get; set; }
        public string? DeviceId { get; set; }
        public DateTimeOffset? LastSyncDateTime { get; set; }
        public IntuneBooksDeviceinstallstateCreateParameterInstallState InstallState { get; set; }
        public string? ErrorCode { get; set; }
        public string? OsVersion { get; set; }
        public string? OsDescription { get; set; }
        public string? UserName { get; set; }
        public string ManagedEBookId { get; set; }
        public string UserInstallStateSummaryId { get; set; }
    }
    public partial class IntuneBooksDeviceinstallstateCreateResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-deviceinstallstate-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksDeviceinstallstateCreateResponse> IntuneBooksDeviceinstallstateCreateAsync()
        {
            var p = new IntuneBooksDeviceinstallstateCreateParameter();
            return await this.SendAsync<IntuneBooksDeviceinstallstateCreateParameter, IntuneBooksDeviceinstallstateCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-deviceinstallstate-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksDeviceinstallstateCreateResponse> IntuneBooksDeviceinstallstateCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneBooksDeviceinstallstateCreateParameter();
            return await this.SendAsync<IntuneBooksDeviceinstallstateCreateParameter, IntuneBooksDeviceinstallstateCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-deviceinstallstate-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksDeviceinstallstateCreateResponse> IntuneBooksDeviceinstallstateCreateAsync(IntuneBooksDeviceinstallstateCreateParameter parameter)
        {
            return await this.SendAsync<IntuneBooksDeviceinstallstateCreateParameter, IntuneBooksDeviceinstallstateCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-deviceinstallstate-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksDeviceinstallstateCreateResponse> IntuneBooksDeviceinstallstateCreateAsync(IntuneBooksDeviceinstallstateCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneBooksDeviceinstallstateCreateParameter, IntuneBooksDeviceinstallstateCreateResponse>(parameter, cancellationToken);
        }
    }
}
