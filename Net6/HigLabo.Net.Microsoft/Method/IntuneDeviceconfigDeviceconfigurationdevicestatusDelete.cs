using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigDeviceconfigurationdevicestatusDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_DeviceConfigurations_DeviceConfigurationId_DeviceStatuses_DeviceConfigurationDeviceStatusId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceConfigurations_DeviceConfigurationId_DeviceStatuses_DeviceConfigurationDeviceStatusId: return $"/deviceManagement/deviceConfigurations/{DeviceConfigurationId}/deviceStatuses/{DeviceConfigurationDeviceStatusId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string DeviceConfigurationId { get; set; }
        public string DeviceConfigurationDeviceStatusId { get; set; }
    }
    public partial class IntuneDeviceconfigDeviceconfigurationdevicestatusDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationdevicestatus-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationdevicestatusDeleteResponse> IntuneDeviceconfigDeviceconfigurationdevicestatusDeleteAsync()
        {
            var p = new IntuneDeviceconfigDeviceconfigurationdevicestatusDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationdevicestatusDeleteParameter, IntuneDeviceconfigDeviceconfigurationdevicestatusDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationdevicestatus-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationdevicestatusDeleteResponse> IntuneDeviceconfigDeviceconfigurationdevicestatusDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigDeviceconfigurationdevicestatusDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationdevicestatusDeleteParameter, IntuneDeviceconfigDeviceconfigurationdevicestatusDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationdevicestatus-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationdevicestatusDeleteResponse> IntuneDeviceconfigDeviceconfigurationdevicestatusDeleteAsync(IntuneDeviceconfigDeviceconfigurationdevicestatusDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationdevicestatusDeleteParameter, IntuneDeviceconfigDeviceconfigurationdevicestatusDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationdevicestatus-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationdevicestatusDeleteResponse> IntuneDeviceconfigDeviceconfigurationdevicestatusDeleteAsync(IntuneDeviceconfigDeviceconfigurationdevicestatusDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationdevicestatusDeleteParameter, IntuneDeviceconfigDeviceconfigurationdevicestatusDeleteResponse>(parameter, cancellationToken);
        }
    }
}
