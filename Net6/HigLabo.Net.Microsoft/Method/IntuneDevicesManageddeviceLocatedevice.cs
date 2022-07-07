using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDevicesManageddeviceLocatedeviceParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Users_UsersId_ManagedDevices_ManagedDeviceId_LocateDevice,
            DeviceManagement_ManagedDevices_ManagedDeviceId_LocateDevice,
            DeviceManagement_DetectedApps_DetectedAppId_ManagedDevices_ManagedDeviceId_LocateDevice,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Users_UsersId_ManagedDevices_ManagedDeviceId_LocateDevice: return $"/users/{UsersId}/managedDevices/{ManagedDeviceId}/locateDevice";
                    case ApiPath.DeviceManagement_ManagedDevices_ManagedDeviceId_LocateDevice: return $"/deviceManagement/managedDevices/{ManagedDeviceId}/locateDevice";
                    case ApiPath.DeviceManagement_DetectedApps_DetectedAppId_ManagedDevices_ManagedDeviceId_LocateDevice: return $"/deviceManagement/detectedApps/{DetectedAppId}/managedDevices/{ManagedDeviceId}/locateDevice";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string UsersId { get; set; }
        public string ManagedDeviceId { get; set; }
        public string DetectedAppId { get; set; }
    }
    public partial class IntuneDevicesManageddeviceLocatedeviceResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-locatedevice?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceLocatedeviceResponse> IntuneDevicesManageddeviceLocatedeviceAsync()
        {
            var p = new IntuneDevicesManageddeviceLocatedeviceParameter();
            return await this.SendAsync<IntuneDevicesManageddeviceLocatedeviceParameter, IntuneDevicesManageddeviceLocatedeviceResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-locatedevice?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceLocatedeviceResponse> IntuneDevicesManageddeviceLocatedeviceAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDevicesManageddeviceLocatedeviceParameter();
            return await this.SendAsync<IntuneDevicesManageddeviceLocatedeviceParameter, IntuneDevicesManageddeviceLocatedeviceResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-locatedevice?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceLocatedeviceResponse> IntuneDevicesManageddeviceLocatedeviceAsync(IntuneDevicesManageddeviceLocatedeviceParameter parameter)
        {
            return await this.SendAsync<IntuneDevicesManageddeviceLocatedeviceParameter, IntuneDevicesManageddeviceLocatedeviceResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-locatedevice?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceLocatedeviceResponse> IntuneDevicesManageddeviceLocatedeviceAsync(IntuneDevicesManageddeviceLocatedeviceParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDevicesManageddeviceLocatedeviceParameter, IntuneDevicesManageddeviceLocatedeviceResponse>(parameter, cancellationToken);
        }
    }
}
