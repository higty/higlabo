using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDevicesManageddeviceSyncdeviceParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Users_UsersId_ManagedDevices_ManagedDeviceId_SyncDevice,
            DeviceManagement_ManagedDevices_ManagedDeviceId_SyncDevice,
            DeviceManagement_DetectedApps_DetectedAppId_ManagedDevices_ManagedDeviceId_SyncDevice,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Users_UsersId_ManagedDevices_ManagedDeviceId_SyncDevice: return $"/users/{UsersId}/managedDevices/{ManagedDeviceId}/syncDevice";
                    case ApiPath.DeviceManagement_ManagedDevices_ManagedDeviceId_SyncDevice: return $"/deviceManagement/managedDevices/{ManagedDeviceId}/syncDevice";
                    case ApiPath.DeviceManagement_DetectedApps_DetectedAppId_ManagedDevices_ManagedDeviceId_SyncDevice: return $"/deviceManagement/detectedApps/{DetectedAppId}/managedDevices/{ManagedDeviceId}/syncDevice";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string UsersId { get; set; }
        public string ManagedDeviceId { get; set; }
        public string DetectedAppId { get; set; }
    }
    public partial class IntuneDevicesManageddeviceSyncdeviceResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-syncdevice?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceSyncdeviceResponse> IntuneDevicesManageddeviceSyncdeviceAsync()
        {
            var p = new IntuneDevicesManageddeviceSyncdeviceParameter();
            return await this.SendAsync<IntuneDevicesManageddeviceSyncdeviceParameter, IntuneDevicesManageddeviceSyncdeviceResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-syncdevice?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceSyncdeviceResponse> IntuneDevicesManageddeviceSyncdeviceAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDevicesManageddeviceSyncdeviceParameter();
            return await this.SendAsync<IntuneDevicesManageddeviceSyncdeviceParameter, IntuneDevicesManageddeviceSyncdeviceResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-syncdevice?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceSyncdeviceResponse> IntuneDevicesManageddeviceSyncdeviceAsync(IntuneDevicesManageddeviceSyncdeviceParameter parameter)
        {
            return await this.SendAsync<IntuneDevicesManageddeviceSyncdeviceParameter, IntuneDevicesManageddeviceSyncdeviceResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-syncdevice?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceSyncdeviceResponse> IntuneDevicesManageddeviceSyncdeviceAsync(IntuneDevicesManageddeviceSyncdeviceParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDevicesManageddeviceSyncdeviceParameter, IntuneDevicesManageddeviceSyncdeviceResponse>(parameter, cancellationToken);
        }
    }
}
