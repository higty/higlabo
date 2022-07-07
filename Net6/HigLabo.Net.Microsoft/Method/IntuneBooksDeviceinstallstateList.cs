using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneBooksDeviceinstallstateListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
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
    public partial class IntuneBooksDeviceinstallstateListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-books-deviceinstallstate?view=graph-rest-1.0
        /// </summary>
        public partial class DeviceInstallState
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

        public DeviceInstallState[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-deviceinstallstate-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksDeviceinstallstateListResponse> IntuneBooksDeviceinstallstateListAsync()
        {
            var p = new IntuneBooksDeviceinstallstateListParameter();
            return await this.SendAsync<IntuneBooksDeviceinstallstateListParameter, IntuneBooksDeviceinstallstateListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-deviceinstallstate-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksDeviceinstallstateListResponse> IntuneBooksDeviceinstallstateListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneBooksDeviceinstallstateListParameter();
            return await this.SendAsync<IntuneBooksDeviceinstallstateListParameter, IntuneBooksDeviceinstallstateListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-deviceinstallstate-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksDeviceinstallstateListResponse> IntuneBooksDeviceinstallstateListAsync(IntuneBooksDeviceinstallstateListParameter parameter)
        {
            return await this.SendAsync<IntuneBooksDeviceinstallstateListParameter, IntuneBooksDeviceinstallstateListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-deviceinstallstate-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksDeviceinstallstateListResponse> IntuneBooksDeviceinstallstateListAsync(IntuneBooksDeviceinstallstateListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneBooksDeviceinstallstateListParameter, IntuneBooksDeviceinstallstateListResponse>(parameter, cancellationToken);
        }
    }
}
