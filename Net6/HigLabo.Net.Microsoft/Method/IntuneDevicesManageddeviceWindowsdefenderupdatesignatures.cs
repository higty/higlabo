using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDevicesManageddeviceWindowsdefenderupdatesignaturesParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Users_UsersId_ManagedDevices_ManagedDeviceId_WindowsDefenderUpdateSignatures,
            DeviceManagement_ManagedDevices_ManagedDeviceId_WindowsDefenderUpdateSignatures,
            DeviceManagement_DetectedApps_DetectedAppId_ManagedDevices_ManagedDeviceId_WindowsDefenderUpdateSignatures,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Users_UsersId_ManagedDevices_ManagedDeviceId_WindowsDefenderUpdateSignatures: return $"/users/{UsersId}/managedDevices/{ManagedDeviceId}/windowsDefenderUpdateSignatures";
                    case ApiPath.DeviceManagement_ManagedDevices_ManagedDeviceId_WindowsDefenderUpdateSignatures: return $"/deviceManagement/managedDevices/{ManagedDeviceId}/windowsDefenderUpdateSignatures";
                    case ApiPath.DeviceManagement_DetectedApps_DetectedAppId_ManagedDevices_ManagedDeviceId_WindowsDefenderUpdateSignatures: return $"/deviceManagement/detectedApps/{DetectedAppId}/managedDevices/{ManagedDeviceId}/windowsDefenderUpdateSignatures";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string UsersId { get; set; }
        public string ManagedDeviceId { get; set; }
        public string DetectedAppId { get; set; }
    }
    public partial class IntuneDevicesManageddeviceWindowsdefenderupdatesignaturesResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-windowsdefenderupdatesignatures?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceWindowsdefenderupdatesignaturesResponse> IntuneDevicesManageddeviceWindowsdefenderupdatesignaturesAsync()
        {
            var p = new IntuneDevicesManageddeviceWindowsdefenderupdatesignaturesParameter();
            return await this.SendAsync<IntuneDevicesManageddeviceWindowsdefenderupdatesignaturesParameter, IntuneDevicesManageddeviceWindowsdefenderupdatesignaturesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-windowsdefenderupdatesignatures?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceWindowsdefenderupdatesignaturesResponse> IntuneDevicesManageddeviceWindowsdefenderupdatesignaturesAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDevicesManageddeviceWindowsdefenderupdatesignaturesParameter();
            return await this.SendAsync<IntuneDevicesManageddeviceWindowsdefenderupdatesignaturesParameter, IntuneDevicesManageddeviceWindowsdefenderupdatesignaturesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-windowsdefenderupdatesignatures?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceWindowsdefenderupdatesignaturesResponse> IntuneDevicesManageddeviceWindowsdefenderupdatesignaturesAsync(IntuneDevicesManageddeviceWindowsdefenderupdatesignaturesParameter parameter)
        {
            return await this.SendAsync<IntuneDevicesManageddeviceWindowsdefenderupdatesignaturesParameter, IntuneDevicesManageddeviceWindowsdefenderupdatesignaturesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-windowsdefenderupdatesignatures?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceWindowsdefenderupdatesignaturesResponse> IntuneDevicesManageddeviceWindowsdefenderupdatesignaturesAsync(IntuneDevicesManageddeviceWindowsdefenderupdatesignaturesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDevicesManageddeviceWindowsdefenderupdatesignaturesParameter, IntuneDevicesManageddeviceWindowsdefenderupdatesignaturesResponse>(parameter, cancellationToken);
        }
    }
}
