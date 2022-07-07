using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneBooksDeviceinstallstateDeleteParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string ManagedEBookId { get; set; }
        public string DeviceInstallStateId { get; set; }
        public string UserInstallStateSummaryId { get; set; }
    }
    public partial class IntuneBooksDeviceinstallstateDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-deviceinstallstate-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksDeviceinstallstateDeleteResponse> IntuneBooksDeviceinstallstateDeleteAsync()
        {
            var p = new IntuneBooksDeviceinstallstateDeleteParameter();
            return await this.SendAsync<IntuneBooksDeviceinstallstateDeleteParameter, IntuneBooksDeviceinstallstateDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-deviceinstallstate-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksDeviceinstallstateDeleteResponse> IntuneBooksDeviceinstallstateDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneBooksDeviceinstallstateDeleteParameter();
            return await this.SendAsync<IntuneBooksDeviceinstallstateDeleteParameter, IntuneBooksDeviceinstallstateDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-deviceinstallstate-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksDeviceinstallstateDeleteResponse> IntuneBooksDeviceinstallstateDeleteAsync(IntuneBooksDeviceinstallstateDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneBooksDeviceinstallstateDeleteParameter, IntuneBooksDeviceinstallstateDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-books-deviceinstallstate-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneBooksDeviceinstallstateDeleteResponse> IntuneBooksDeviceinstallstateDeleteAsync(IntuneBooksDeviceinstallstateDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneBooksDeviceinstallstateDeleteParameter, IntuneBooksDeviceinstallstateDeleteResponse>(parameter, cancellationToken);
        }
    }
}
