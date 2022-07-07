using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDevicesManageddeviceRemotelockParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Users_UsersId_ManagedDevices_ManagedDeviceId_RemoteLock,
            DeviceManagement_ManagedDevices_ManagedDeviceId_RemoteLock,
            DeviceManagement_DetectedApps_DetectedAppId_ManagedDevices_ManagedDeviceId_RemoteLock,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Users_UsersId_ManagedDevices_ManagedDeviceId_RemoteLock: return $"/users/{UsersId}/managedDevices/{ManagedDeviceId}/remoteLock";
                    case ApiPath.DeviceManagement_ManagedDevices_ManagedDeviceId_RemoteLock: return $"/deviceManagement/managedDevices/{ManagedDeviceId}/remoteLock";
                    case ApiPath.DeviceManagement_DetectedApps_DetectedAppId_ManagedDevices_ManagedDeviceId_RemoteLock: return $"/deviceManagement/detectedApps/{DetectedAppId}/managedDevices/{ManagedDeviceId}/remoteLock";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string UsersId { get; set; }
        public string ManagedDeviceId { get; set; }
        public string DetectedAppId { get; set; }
    }
    public partial class IntuneDevicesManageddeviceRemotelockResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-remotelock?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceRemotelockResponse> IntuneDevicesManageddeviceRemotelockAsync()
        {
            var p = new IntuneDevicesManageddeviceRemotelockParameter();
            return await this.SendAsync<IntuneDevicesManageddeviceRemotelockParameter, IntuneDevicesManageddeviceRemotelockResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-remotelock?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceRemotelockResponse> IntuneDevicesManageddeviceRemotelockAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDevicesManageddeviceRemotelockParameter();
            return await this.SendAsync<IntuneDevicesManageddeviceRemotelockParameter, IntuneDevicesManageddeviceRemotelockResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-remotelock?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceRemotelockResponse> IntuneDevicesManageddeviceRemotelockAsync(IntuneDevicesManageddeviceRemotelockParameter parameter)
        {
            return await this.SendAsync<IntuneDevicesManageddeviceRemotelockParameter, IntuneDevicesManageddeviceRemotelockResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-remotelock?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceRemotelockResponse> IntuneDevicesManageddeviceRemotelockAsync(IntuneDevicesManageddeviceRemotelockParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDevicesManageddeviceRemotelockParameter, IntuneDevicesManageddeviceRemotelockResponse>(parameter, cancellationToken);
        }
    }
}
