using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDevicesManageddeviceRebootnowParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Users_UsersId_ManagedDevices_ManagedDeviceId_RebootNow,
            DeviceManagement_ManagedDevices_ManagedDeviceId_RebootNow,
            DeviceManagement_DetectedApps_DetectedAppId_ManagedDevices_ManagedDeviceId_RebootNow,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Users_UsersId_ManagedDevices_ManagedDeviceId_RebootNow: return $"/users/{UsersId}/managedDevices/{ManagedDeviceId}/rebootNow";
                    case ApiPath.DeviceManagement_ManagedDevices_ManagedDeviceId_RebootNow: return $"/deviceManagement/managedDevices/{ManagedDeviceId}/rebootNow";
                    case ApiPath.DeviceManagement_DetectedApps_DetectedAppId_ManagedDevices_ManagedDeviceId_RebootNow: return $"/deviceManagement/detectedApps/{DetectedAppId}/managedDevices/{ManagedDeviceId}/rebootNow";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string UsersId { get; set; }
        public string ManagedDeviceId { get; set; }
        public string DetectedAppId { get; set; }
    }
    public partial class IntuneDevicesManageddeviceRebootnowResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-rebootnow?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceRebootnowResponse> IntuneDevicesManageddeviceRebootnowAsync()
        {
            var p = new IntuneDevicesManageddeviceRebootnowParameter();
            return await this.SendAsync<IntuneDevicesManageddeviceRebootnowParameter, IntuneDevicesManageddeviceRebootnowResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-rebootnow?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceRebootnowResponse> IntuneDevicesManageddeviceRebootnowAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDevicesManageddeviceRebootnowParameter();
            return await this.SendAsync<IntuneDevicesManageddeviceRebootnowParameter, IntuneDevicesManageddeviceRebootnowResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-rebootnow?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceRebootnowResponse> IntuneDevicesManageddeviceRebootnowAsync(IntuneDevicesManageddeviceRebootnowParameter parameter)
        {
            return await this.SendAsync<IntuneDevicesManageddeviceRebootnowParameter, IntuneDevicesManageddeviceRebootnowResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-rebootnow?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceRebootnowResponse> IntuneDevicesManageddeviceRebootnowAsync(IntuneDevicesManageddeviceRebootnowParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDevicesManageddeviceRebootnowParameter, IntuneDevicesManageddeviceRebootnowResponse>(parameter, cancellationToken);
        }
    }
}
