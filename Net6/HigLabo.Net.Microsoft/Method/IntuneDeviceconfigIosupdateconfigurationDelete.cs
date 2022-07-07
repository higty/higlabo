using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigIosupdateconfigurationDeleteParameter : IRestApiParameter
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
    public partial class IntuneDeviceconfigIosupdateconfigurationDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-iosupdateconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIosupdateconfigurationDeleteResponse> IntuneDeviceconfigIosupdateconfigurationDeleteAsync()
        {
            var p = new IntuneDeviceconfigIosupdateconfigurationDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigIosupdateconfigurationDeleteParameter, IntuneDeviceconfigIosupdateconfigurationDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-iosupdateconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIosupdateconfigurationDeleteResponse> IntuneDeviceconfigIosupdateconfigurationDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigIosupdateconfigurationDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigIosupdateconfigurationDeleteParameter, IntuneDeviceconfigIosupdateconfigurationDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-iosupdateconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIosupdateconfigurationDeleteResponse> IntuneDeviceconfigIosupdateconfigurationDeleteAsync(IntuneDeviceconfigIosupdateconfigurationDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigIosupdateconfigurationDeleteParameter, IntuneDeviceconfigIosupdateconfigurationDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-iosupdateconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIosupdateconfigurationDeleteResponse> IntuneDeviceconfigIosupdateconfigurationDeleteAsync(IntuneDeviceconfigIosupdateconfigurationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigIosupdateconfigurationDeleteParameter, IntuneDeviceconfigIosupdateconfigurationDeleteResponse>(parameter, cancellationToken);
        }
    }
}
