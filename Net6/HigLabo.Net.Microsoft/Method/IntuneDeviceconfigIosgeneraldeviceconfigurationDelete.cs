using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigIosgeneraldeviceconfigurationDeleteParameter : IRestApiParameter
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
    public partial class IntuneDeviceconfigIosgeneraldeviceconfigurationDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-iosgeneraldeviceconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIosgeneraldeviceconfigurationDeleteResponse> IntuneDeviceconfigIosgeneraldeviceconfigurationDeleteAsync()
        {
            var p = new IntuneDeviceconfigIosgeneraldeviceconfigurationDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigIosgeneraldeviceconfigurationDeleteParameter, IntuneDeviceconfigIosgeneraldeviceconfigurationDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-iosgeneraldeviceconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIosgeneraldeviceconfigurationDeleteResponse> IntuneDeviceconfigIosgeneraldeviceconfigurationDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigIosgeneraldeviceconfigurationDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigIosgeneraldeviceconfigurationDeleteParameter, IntuneDeviceconfigIosgeneraldeviceconfigurationDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-iosgeneraldeviceconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIosgeneraldeviceconfigurationDeleteResponse> IntuneDeviceconfigIosgeneraldeviceconfigurationDeleteAsync(IntuneDeviceconfigIosgeneraldeviceconfigurationDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigIosgeneraldeviceconfigurationDeleteParameter, IntuneDeviceconfigIosgeneraldeviceconfigurationDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-iosgeneraldeviceconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIosgeneraldeviceconfigurationDeleteResponse> IntuneDeviceconfigIosgeneraldeviceconfigurationDeleteAsync(IntuneDeviceconfigIosgeneraldeviceconfigurationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigIosgeneraldeviceconfigurationDeleteParameter, IntuneDeviceconfigIosgeneraldeviceconfigurationDeleteResponse>(parameter, cancellationToken);
        }
    }
}
