using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigMacosdevicefeaturesconfigurationDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_DeviceConfigurations_DeviceConfigurationId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceConfigurations_DeviceConfigurationId: return $"/deviceManagement/deviceConfigurations/{DeviceConfigurationId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string DeviceConfigurationId { get; set; }
    }
    public partial class IntuneDeviceconfigMacosdevicefeaturesconfigurationDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-macosdevicefeaturesconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigMacosdevicefeaturesconfigurationDeleteResponse> IntuneDeviceconfigMacosdevicefeaturesconfigurationDeleteAsync()
        {
            var p = new IntuneDeviceconfigMacosdevicefeaturesconfigurationDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigMacosdevicefeaturesconfigurationDeleteParameter, IntuneDeviceconfigMacosdevicefeaturesconfigurationDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-macosdevicefeaturesconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigMacosdevicefeaturesconfigurationDeleteResponse> IntuneDeviceconfigMacosdevicefeaturesconfigurationDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigMacosdevicefeaturesconfigurationDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigMacosdevicefeaturesconfigurationDeleteParameter, IntuneDeviceconfigMacosdevicefeaturesconfigurationDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-macosdevicefeaturesconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigMacosdevicefeaturesconfigurationDeleteResponse> IntuneDeviceconfigMacosdevicefeaturesconfigurationDeleteAsync(IntuneDeviceconfigMacosdevicefeaturesconfigurationDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigMacosdevicefeaturesconfigurationDeleteParameter, IntuneDeviceconfigMacosdevicefeaturesconfigurationDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-macosdevicefeaturesconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigMacosdevicefeaturesconfigurationDeleteResponse> IntuneDeviceconfigMacosdevicefeaturesconfigurationDeleteAsync(IntuneDeviceconfigMacosdevicefeaturesconfigurationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigMacosdevicefeaturesconfigurationDeleteParameter, IntuneDeviceconfigMacosdevicefeaturesconfigurationDeleteResponse>(parameter, cancellationToken);
        }
    }
}
