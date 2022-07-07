using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDevicesManageddeviceCleanwindowsdeviceParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Users_UsersId_ManagedDevices_ManagedDeviceId_CleanWindowsDevice,
            DeviceManagement_ManagedDevices_ManagedDeviceId_CleanWindowsDevice,
            DeviceManagement_DetectedApps_DetectedAppId_ManagedDevices_ManagedDeviceId_CleanWindowsDevice,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Users_UsersId_ManagedDevices_ManagedDeviceId_CleanWindowsDevice: return $"/users/{UsersId}/managedDevices/{ManagedDeviceId}/cleanWindowsDevice";
                    case ApiPath.DeviceManagement_ManagedDevices_ManagedDeviceId_CleanWindowsDevice: return $"/deviceManagement/managedDevices/{ManagedDeviceId}/cleanWindowsDevice";
                    case ApiPath.DeviceManagement_DetectedApps_DetectedAppId_ManagedDevices_ManagedDeviceId_CleanWindowsDevice: return $"/deviceManagement/detectedApps/{DetectedAppId}/managedDevices/{ManagedDeviceId}/cleanWindowsDevice";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public bool? KeepUserData { get; set; }
        public string UsersId { get; set; }
        public string ManagedDeviceId { get; set; }
        public string DetectedAppId { get; set; }
    }
    public partial class IntuneDevicesManageddeviceCleanwindowsdeviceResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-cleanwindowsdevice?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceCleanwindowsdeviceResponse> IntuneDevicesManageddeviceCleanwindowsdeviceAsync()
        {
            var p = new IntuneDevicesManageddeviceCleanwindowsdeviceParameter();
            return await this.SendAsync<IntuneDevicesManageddeviceCleanwindowsdeviceParameter, IntuneDevicesManageddeviceCleanwindowsdeviceResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-cleanwindowsdevice?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceCleanwindowsdeviceResponse> IntuneDevicesManageddeviceCleanwindowsdeviceAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDevicesManageddeviceCleanwindowsdeviceParameter();
            return await this.SendAsync<IntuneDevicesManageddeviceCleanwindowsdeviceParameter, IntuneDevicesManageddeviceCleanwindowsdeviceResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-cleanwindowsdevice?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceCleanwindowsdeviceResponse> IntuneDevicesManageddeviceCleanwindowsdeviceAsync(IntuneDevicesManageddeviceCleanwindowsdeviceParameter parameter)
        {
            return await this.SendAsync<IntuneDevicesManageddeviceCleanwindowsdeviceParameter, IntuneDevicesManageddeviceCleanwindowsdeviceResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-cleanwindowsdevice?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceCleanwindowsdeviceResponse> IntuneDevicesManageddeviceCleanwindowsdeviceAsync(IntuneDevicesManageddeviceCleanwindowsdeviceParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDevicesManageddeviceCleanwindowsdeviceParameter, IntuneDevicesManageddeviceCleanwindowsdeviceResponse>(parameter, cancellationToken);
        }
    }
}
