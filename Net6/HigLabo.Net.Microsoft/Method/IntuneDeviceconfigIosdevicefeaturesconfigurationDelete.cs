using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigIosdevicefeaturesconfigurationDeleteParameter : IRestApiParameter
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
    public partial class IntuneDeviceconfigIosdevicefeaturesconfigurationDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-iosdevicefeaturesconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIosdevicefeaturesconfigurationDeleteResponse> IntuneDeviceconfigIosdevicefeaturesconfigurationDeleteAsync()
        {
            var p = new IntuneDeviceconfigIosdevicefeaturesconfigurationDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigIosdevicefeaturesconfigurationDeleteParameter, IntuneDeviceconfigIosdevicefeaturesconfigurationDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-iosdevicefeaturesconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIosdevicefeaturesconfigurationDeleteResponse> IntuneDeviceconfigIosdevicefeaturesconfigurationDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigIosdevicefeaturesconfigurationDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigIosdevicefeaturesconfigurationDeleteParameter, IntuneDeviceconfigIosdevicefeaturesconfigurationDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-iosdevicefeaturesconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIosdevicefeaturesconfigurationDeleteResponse> IntuneDeviceconfigIosdevicefeaturesconfigurationDeleteAsync(IntuneDeviceconfigIosdevicefeaturesconfigurationDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigIosdevicefeaturesconfigurationDeleteParameter, IntuneDeviceconfigIosdevicefeaturesconfigurationDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-iosdevicefeaturesconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIosdevicefeaturesconfigurationDeleteResponse> IntuneDeviceconfigIosdevicefeaturesconfigurationDeleteAsync(IntuneDeviceconfigIosdevicefeaturesconfigurationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigIosdevicefeaturesconfigurationDeleteParameter, IntuneDeviceconfigIosdevicefeaturesconfigurationDeleteResponse>(parameter, cancellationToken);
        }
    }
}
