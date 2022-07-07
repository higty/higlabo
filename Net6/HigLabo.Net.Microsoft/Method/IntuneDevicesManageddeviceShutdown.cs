using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDevicesManageddeviceShutdownParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Users_UsersId_ManagedDevices_ManagedDeviceId_ShutDown,
            DeviceManagement_ManagedDevices_ManagedDeviceId_ShutDown,
            DeviceManagement_DetectedApps_DetectedAppId_ManagedDevices_ManagedDeviceId_ShutDown,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Users_UsersId_ManagedDevices_ManagedDeviceId_ShutDown: return $"/users/{UsersId}/managedDevices/{ManagedDeviceId}/shutDown";
                    case ApiPath.DeviceManagement_ManagedDevices_ManagedDeviceId_ShutDown: return $"/deviceManagement/managedDevices/{ManagedDeviceId}/shutDown";
                    case ApiPath.DeviceManagement_DetectedApps_DetectedAppId_ManagedDevices_ManagedDeviceId_ShutDown: return $"/deviceManagement/detectedApps/{DetectedAppId}/managedDevices/{ManagedDeviceId}/shutDown";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string UsersId { get; set; }
        public string ManagedDeviceId { get; set; }
        public string DetectedAppId { get; set; }
    }
    public partial class IntuneDevicesManageddeviceShutdownResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-shutdown?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceShutdownResponse> IntuneDevicesManageddeviceShutdownAsync()
        {
            var p = new IntuneDevicesManageddeviceShutdownParameter();
            return await this.SendAsync<IntuneDevicesManageddeviceShutdownParameter, IntuneDevicesManageddeviceShutdownResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-shutdown?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceShutdownResponse> IntuneDevicesManageddeviceShutdownAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDevicesManageddeviceShutdownParameter();
            return await this.SendAsync<IntuneDevicesManageddeviceShutdownParameter, IntuneDevicesManageddeviceShutdownResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-shutdown?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceShutdownResponse> IntuneDevicesManageddeviceShutdownAsync(IntuneDevicesManageddeviceShutdownParameter parameter)
        {
            return await this.SendAsync<IntuneDevicesManageddeviceShutdownParameter, IntuneDevicesManageddeviceShutdownResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-shutdown?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceShutdownResponse> IntuneDevicesManageddeviceShutdownAsync(IntuneDevicesManageddeviceShutdownParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDevicesManageddeviceShutdownParameter, IntuneDevicesManageddeviceShutdownResponse>(parameter, cancellationToken);
        }
    }
}
