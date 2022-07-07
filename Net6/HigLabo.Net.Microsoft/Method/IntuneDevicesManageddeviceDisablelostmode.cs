using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDevicesManageddeviceDisablelostmodeParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Users_UsersId_ManagedDevices_ManagedDeviceId_DisableLostMode,
            DeviceManagement_ManagedDevices_ManagedDeviceId_DisableLostMode,
            DeviceManagement_DetectedApps_DetectedAppId_ManagedDevices_ManagedDeviceId_DisableLostMode,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Users_UsersId_ManagedDevices_ManagedDeviceId_DisableLostMode: return $"/users/{UsersId}/managedDevices/{ManagedDeviceId}/disableLostMode";
                    case ApiPath.DeviceManagement_ManagedDevices_ManagedDeviceId_DisableLostMode: return $"/deviceManagement/managedDevices/{ManagedDeviceId}/disableLostMode";
                    case ApiPath.DeviceManagement_DetectedApps_DetectedAppId_ManagedDevices_ManagedDeviceId_DisableLostMode: return $"/deviceManagement/detectedApps/{DetectedAppId}/managedDevices/{ManagedDeviceId}/disableLostMode";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string UsersId { get; set; }
        public string ManagedDeviceId { get; set; }
        public string DetectedAppId { get; set; }
    }
    public partial class IntuneDevicesManageddeviceDisablelostmodeResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-disablelostmode?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceDisablelostmodeResponse> IntuneDevicesManageddeviceDisablelostmodeAsync()
        {
            var p = new IntuneDevicesManageddeviceDisablelostmodeParameter();
            return await this.SendAsync<IntuneDevicesManageddeviceDisablelostmodeParameter, IntuneDevicesManageddeviceDisablelostmodeResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-disablelostmode?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceDisablelostmodeResponse> IntuneDevicesManageddeviceDisablelostmodeAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDevicesManageddeviceDisablelostmodeParameter();
            return await this.SendAsync<IntuneDevicesManageddeviceDisablelostmodeParameter, IntuneDevicesManageddeviceDisablelostmodeResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-disablelostmode?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceDisablelostmodeResponse> IntuneDevicesManageddeviceDisablelostmodeAsync(IntuneDevicesManageddeviceDisablelostmodeParameter parameter)
        {
            return await this.SendAsync<IntuneDevicesManageddeviceDisablelostmodeParameter, IntuneDevicesManageddeviceDisablelostmodeResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-disablelostmode?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceDisablelostmodeResponse> IntuneDevicesManageddeviceDisablelostmodeAsync(IntuneDevicesManageddeviceDisablelostmodeParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDevicesManageddeviceDisablelostmodeParameter, IntuneDevicesManageddeviceDisablelostmodeResponse>(parameter, cancellationToken);
        }
    }
}
