using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDevicesManageddeviceUpdatewindowsdeviceaccountParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Users_UsersId_ManagedDevices_ManagedDeviceId_UpdateWindowsDeviceAccount,
            DeviceManagement_ManagedDevices_ManagedDeviceId_UpdateWindowsDeviceAccount,
            DeviceManagement_DetectedApps_DetectedAppId_ManagedDevices_ManagedDeviceId_UpdateWindowsDeviceAccount,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Users_UsersId_ManagedDevices_ManagedDeviceId_UpdateWindowsDeviceAccount: return $"/users/{UsersId}/managedDevices/{ManagedDeviceId}/updateWindowsDeviceAccount";
                    case ApiPath.DeviceManagement_ManagedDevices_ManagedDeviceId_UpdateWindowsDeviceAccount: return $"/deviceManagement/managedDevices/{ManagedDeviceId}/updateWindowsDeviceAccount";
                    case ApiPath.DeviceManagement_DetectedApps_DetectedAppId_ManagedDevices_ManagedDeviceId_UpdateWindowsDeviceAccount: return $"/deviceManagement/detectedApps/{DetectedAppId}/managedDevices/{ManagedDeviceId}/updateWindowsDeviceAccount";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public UpdateWindowsDeviceAccountActionParameter? UpdateWindowsDeviceAccountActionParameter { get; set; }
        public string UsersId { get; set; }
        public string ManagedDeviceId { get; set; }
        public string DetectedAppId { get; set; }
    }
    public partial class IntuneDevicesManageddeviceUpdatewindowsdeviceaccountResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-updatewindowsdeviceaccount?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceUpdatewindowsdeviceaccountResponse> IntuneDevicesManageddeviceUpdatewindowsdeviceaccountAsync()
        {
            var p = new IntuneDevicesManageddeviceUpdatewindowsdeviceaccountParameter();
            return await this.SendAsync<IntuneDevicesManageddeviceUpdatewindowsdeviceaccountParameter, IntuneDevicesManageddeviceUpdatewindowsdeviceaccountResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-updatewindowsdeviceaccount?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceUpdatewindowsdeviceaccountResponse> IntuneDevicesManageddeviceUpdatewindowsdeviceaccountAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDevicesManageddeviceUpdatewindowsdeviceaccountParameter();
            return await this.SendAsync<IntuneDevicesManageddeviceUpdatewindowsdeviceaccountParameter, IntuneDevicesManageddeviceUpdatewindowsdeviceaccountResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-updatewindowsdeviceaccount?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceUpdatewindowsdeviceaccountResponse> IntuneDevicesManageddeviceUpdatewindowsdeviceaccountAsync(IntuneDevicesManageddeviceUpdatewindowsdeviceaccountParameter parameter)
        {
            return await this.SendAsync<IntuneDevicesManageddeviceUpdatewindowsdeviceaccountParameter, IntuneDevicesManageddeviceUpdatewindowsdeviceaccountResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-updatewindowsdeviceaccount?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceUpdatewindowsdeviceaccountResponse> IntuneDevicesManageddeviceUpdatewindowsdeviceaccountAsync(IntuneDevicesManageddeviceUpdatewindowsdeviceaccountParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDevicesManageddeviceUpdatewindowsdeviceaccountParameter, IntuneDevicesManageddeviceUpdatewindowsdeviceaccountResponse>(parameter, cancellationToken);
        }
    }
}
