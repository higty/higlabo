using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigWindows10endpointprotectionconfigurationDeleteParameter : IRestApiParameter
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
    public partial class IntuneDeviceconfigWindows10endpointprotectionconfigurationDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10endpointprotectionconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10endpointprotectionconfigurationDeleteResponse> IntuneDeviceconfigWindows10endpointprotectionconfigurationDeleteAsync()
        {
            var p = new IntuneDeviceconfigWindows10endpointprotectionconfigurationDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigWindows10endpointprotectionconfigurationDeleteParameter, IntuneDeviceconfigWindows10endpointprotectionconfigurationDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10endpointprotectionconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10endpointprotectionconfigurationDeleteResponse> IntuneDeviceconfigWindows10endpointprotectionconfigurationDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigWindows10endpointprotectionconfigurationDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigWindows10endpointprotectionconfigurationDeleteParameter, IntuneDeviceconfigWindows10endpointprotectionconfigurationDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10endpointprotectionconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10endpointprotectionconfigurationDeleteResponse> IntuneDeviceconfigWindows10endpointprotectionconfigurationDeleteAsync(IntuneDeviceconfigWindows10endpointprotectionconfigurationDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigWindows10endpointprotectionconfigurationDeleteParameter, IntuneDeviceconfigWindows10endpointprotectionconfigurationDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10endpointprotectionconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10endpointprotectionconfigurationDeleteResponse> IntuneDeviceconfigWindows10endpointprotectionconfigurationDeleteAsync(IntuneDeviceconfigWindows10endpointprotectionconfigurationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigWindows10endpointprotectionconfigurationDeleteParameter, IntuneDeviceconfigWindows10endpointprotectionconfigurationDeleteResponse>(parameter, cancellationToken);
        }
    }
}
