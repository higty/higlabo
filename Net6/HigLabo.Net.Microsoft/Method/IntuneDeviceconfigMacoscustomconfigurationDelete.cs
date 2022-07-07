using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigMacoscustomconfigurationDeleteParameter : IRestApiParameter
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
    public partial class IntuneDeviceconfigMacoscustomconfigurationDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-macoscustomconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigMacoscustomconfigurationDeleteResponse> IntuneDeviceconfigMacoscustomconfigurationDeleteAsync()
        {
            var p = new IntuneDeviceconfigMacoscustomconfigurationDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigMacoscustomconfigurationDeleteParameter, IntuneDeviceconfigMacoscustomconfigurationDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-macoscustomconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigMacoscustomconfigurationDeleteResponse> IntuneDeviceconfigMacoscustomconfigurationDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigMacoscustomconfigurationDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigMacoscustomconfigurationDeleteParameter, IntuneDeviceconfigMacoscustomconfigurationDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-macoscustomconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigMacoscustomconfigurationDeleteResponse> IntuneDeviceconfigMacoscustomconfigurationDeleteAsync(IntuneDeviceconfigMacoscustomconfigurationDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigMacoscustomconfigurationDeleteParameter, IntuneDeviceconfigMacoscustomconfigurationDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-macoscustomconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigMacoscustomconfigurationDeleteResponse> IntuneDeviceconfigMacoscustomconfigurationDeleteAsync(IntuneDeviceconfigMacoscustomconfigurationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigMacoscustomconfigurationDeleteParameter, IntuneDeviceconfigMacoscustomconfigurationDeleteResponse>(parameter, cancellationToken);
        }
    }
}
