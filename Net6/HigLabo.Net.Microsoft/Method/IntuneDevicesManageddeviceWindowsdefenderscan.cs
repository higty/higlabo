using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDevicesManageddeviceWindowsdefenderscanParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Users_UsersId_ManagedDevices_ManagedDeviceId_WindowsDefenderScan,
            DeviceManagement_ManagedDevices_ManagedDeviceId_WindowsDefenderScan,
            DeviceManagement_DetectedApps_DetectedAppId_ManagedDevices_ManagedDeviceId_WindowsDefenderScan,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Users_UsersId_ManagedDevices_ManagedDeviceId_WindowsDefenderScan: return $"/users/{UsersId}/managedDevices/{ManagedDeviceId}/windowsDefenderScan";
                    case ApiPath.DeviceManagement_ManagedDevices_ManagedDeviceId_WindowsDefenderScan: return $"/deviceManagement/managedDevices/{ManagedDeviceId}/windowsDefenderScan";
                    case ApiPath.DeviceManagement_DetectedApps_DetectedAppId_ManagedDevices_ManagedDeviceId_WindowsDefenderScan: return $"/deviceManagement/detectedApps/{DetectedAppId}/managedDevices/{ManagedDeviceId}/windowsDefenderScan";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public bool? QuickScan { get; set; }
        public string UsersId { get; set; }
        public string ManagedDeviceId { get; set; }
        public string DetectedAppId { get; set; }
    }
    public partial class IntuneDevicesManageddeviceWindowsdefenderscanResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-windowsdefenderscan?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceWindowsdefenderscanResponse> IntuneDevicesManageddeviceWindowsdefenderscanAsync()
        {
            var p = new IntuneDevicesManageddeviceWindowsdefenderscanParameter();
            return await this.SendAsync<IntuneDevicesManageddeviceWindowsdefenderscanParameter, IntuneDevicesManageddeviceWindowsdefenderscanResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-windowsdefenderscan?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceWindowsdefenderscanResponse> IntuneDevicesManageddeviceWindowsdefenderscanAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDevicesManageddeviceWindowsdefenderscanParameter();
            return await this.SendAsync<IntuneDevicesManageddeviceWindowsdefenderscanParameter, IntuneDevicesManageddeviceWindowsdefenderscanResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-windowsdefenderscan?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceWindowsdefenderscanResponse> IntuneDevicesManageddeviceWindowsdefenderscanAsync(IntuneDevicesManageddeviceWindowsdefenderscanParameter parameter)
        {
            return await this.SendAsync<IntuneDevicesManageddeviceWindowsdefenderscanParameter, IntuneDevicesManageddeviceWindowsdefenderscanResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-windowsdefenderscan?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceWindowsdefenderscanResponse> IntuneDevicesManageddeviceWindowsdefenderscanAsync(IntuneDevicesManageddeviceWindowsdefenderscanParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDevicesManageddeviceWindowsdefenderscanParameter, IntuneDevicesManageddeviceWindowsdefenderscanResponse>(parameter, cancellationToken);
        }
    }
}
