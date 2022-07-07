using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDevicesManageddeviceDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Users_UsersId_ManagedDevices_ManagedDeviceId,
            DeviceManagement_ManagedDevices_ManagedDeviceId,
            DeviceManagement_DetectedApps_DetectedAppId_ManagedDevices_ManagedDeviceId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Users_UsersId_ManagedDevices_ManagedDeviceId: return $"/users/{UsersId}/managedDevices/{ManagedDeviceId}";
                    case ApiPath.DeviceManagement_ManagedDevices_ManagedDeviceId: return $"/deviceManagement/managedDevices/{ManagedDeviceId}";
                    case ApiPath.DeviceManagement_DetectedApps_DetectedAppId_ManagedDevices_ManagedDeviceId: return $"/deviceManagement/detectedApps/{DetectedAppId}/managedDevices/{ManagedDeviceId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string UsersId { get; set; }
        public string ManagedDeviceId { get; set; }
        public string DetectedAppId { get; set; }
    }
    public partial class IntuneDevicesManageddeviceDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceDeleteResponse> IntuneDevicesManageddeviceDeleteAsync()
        {
            var p = new IntuneDevicesManageddeviceDeleteParameter();
            return await this.SendAsync<IntuneDevicesManageddeviceDeleteParameter, IntuneDevicesManageddeviceDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceDeleteResponse> IntuneDevicesManageddeviceDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDevicesManageddeviceDeleteParameter();
            return await this.SendAsync<IntuneDevicesManageddeviceDeleteParameter, IntuneDevicesManageddeviceDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceDeleteResponse> IntuneDevicesManageddeviceDeleteAsync(IntuneDevicesManageddeviceDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneDevicesManageddeviceDeleteParameter, IntuneDevicesManageddeviceDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceDeleteResponse> IntuneDevicesManageddeviceDeleteAsync(IntuneDevicesManageddeviceDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDevicesManageddeviceDeleteParameter, IntuneDevicesManageddeviceDeleteResponse>(parameter, cancellationToken);
        }
    }
}
