using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDevicesManageddeviceRetireParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Users_UsersId_ManagedDevices_ManagedDeviceId_Retire,
            DeviceManagement_ManagedDevices_ManagedDeviceId_Retire,
            DeviceManagement_DetectedApps_DetectedAppId_ManagedDevices_ManagedDeviceId_Retire,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Users_UsersId_ManagedDevices_ManagedDeviceId_Retire: return $"/users/{UsersId}/managedDevices/{ManagedDeviceId}/retire";
                    case ApiPath.DeviceManagement_ManagedDevices_ManagedDeviceId_Retire: return $"/deviceManagement/managedDevices/{ManagedDeviceId}/retire";
                    case ApiPath.DeviceManagement_DetectedApps_DetectedAppId_ManagedDevices_ManagedDeviceId_Retire: return $"/deviceManagement/detectedApps/{DetectedAppId}/managedDevices/{ManagedDeviceId}/retire";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string UsersId { get; set; }
        public string ManagedDeviceId { get; set; }
        public string DetectedAppId { get; set; }
    }
    public partial class IntuneDevicesManageddeviceRetireResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-retire?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceRetireResponse> IntuneDevicesManageddeviceRetireAsync()
        {
            var p = new IntuneDevicesManageddeviceRetireParameter();
            return await this.SendAsync<IntuneDevicesManageddeviceRetireParameter, IntuneDevicesManageddeviceRetireResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-retire?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceRetireResponse> IntuneDevicesManageddeviceRetireAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDevicesManageddeviceRetireParameter();
            return await this.SendAsync<IntuneDevicesManageddeviceRetireParameter, IntuneDevicesManageddeviceRetireResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-retire?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceRetireResponse> IntuneDevicesManageddeviceRetireAsync(IntuneDevicesManageddeviceRetireParameter parameter)
        {
            return await this.SendAsync<IntuneDevicesManageddeviceRetireParameter, IntuneDevicesManageddeviceRetireResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-retire?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceRetireResponse> IntuneDevicesManageddeviceRetireAsync(IntuneDevicesManageddeviceRetireParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDevicesManageddeviceRetireParameter, IntuneDevicesManageddeviceRetireResponse>(parameter, cancellationToken);
        }
    }
}
