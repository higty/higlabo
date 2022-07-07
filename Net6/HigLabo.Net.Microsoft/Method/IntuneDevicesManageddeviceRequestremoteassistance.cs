using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDevicesManageddeviceRequestremoteassistanceParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Users_UsersId_ManagedDevices_ManagedDeviceId_RequestRemoteAssistance,
            DeviceManagement_ManagedDevices_ManagedDeviceId_RequestRemoteAssistance,
            DeviceManagement_DetectedApps_DetectedAppId_ManagedDevices_ManagedDeviceId_RequestRemoteAssistance,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Users_UsersId_ManagedDevices_ManagedDeviceId_RequestRemoteAssistance: return $"/users/{UsersId}/managedDevices/{ManagedDeviceId}/requestRemoteAssistance";
                    case ApiPath.DeviceManagement_ManagedDevices_ManagedDeviceId_RequestRemoteAssistance: return $"/deviceManagement/managedDevices/{ManagedDeviceId}/requestRemoteAssistance";
                    case ApiPath.DeviceManagement_DetectedApps_DetectedAppId_ManagedDevices_ManagedDeviceId_RequestRemoteAssistance: return $"/deviceManagement/detectedApps/{DetectedAppId}/managedDevices/{ManagedDeviceId}/requestRemoteAssistance";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string UsersId { get; set; }
        public string ManagedDeviceId { get; set; }
        public string DetectedAppId { get; set; }
    }
    public partial class IntuneDevicesManageddeviceRequestremoteassistanceResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-requestremoteassistance?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceRequestremoteassistanceResponse> IntuneDevicesManageddeviceRequestremoteassistanceAsync()
        {
            var p = new IntuneDevicesManageddeviceRequestremoteassistanceParameter();
            return await this.SendAsync<IntuneDevicesManageddeviceRequestremoteassistanceParameter, IntuneDevicesManageddeviceRequestremoteassistanceResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-requestremoteassistance?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceRequestremoteassistanceResponse> IntuneDevicesManageddeviceRequestremoteassistanceAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDevicesManageddeviceRequestremoteassistanceParameter();
            return await this.SendAsync<IntuneDevicesManageddeviceRequestremoteassistanceParameter, IntuneDevicesManageddeviceRequestremoteassistanceResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-requestremoteassistance?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceRequestremoteassistanceResponse> IntuneDevicesManageddeviceRequestremoteassistanceAsync(IntuneDevicesManageddeviceRequestremoteassistanceParameter parameter)
        {
            return await this.SendAsync<IntuneDevicesManageddeviceRequestremoteassistanceParameter, IntuneDevicesManageddeviceRequestremoteassistanceResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-requestremoteassistance?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceRequestremoteassistanceResponse> IntuneDevicesManageddeviceRequestremoteassistanceAsync(IntuneDevicesManageddeviceRequestremoteassistanceParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDevicesManageddeviceRequestremoteassistanceParameter, IntuneDevicesManageddeviceRequestremoteassistanceResponse>(parameter, cancellationToken);
        }
    }
}
