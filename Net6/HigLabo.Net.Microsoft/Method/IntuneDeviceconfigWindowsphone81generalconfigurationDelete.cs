using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigWindowsphone81generalconfigurationDeleteParameter : IRestApiParameter
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
    public partial class IntuneDeviceconfigWindowsphone81generalconfigurationDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsphone81generalconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsphone81generalconfigurationDeleteResponse> IntuneDeviceconfigWindowsphone81generalconfigurationDeleteAsync()
        {
            var p = new IntuneDeviceconfigWindowsphone81generalconfigurationDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigWindowsphone81generalconfigurationDeleteParameter, IntuneDeviceconfigWindowsphone81generalconfigurationDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsphone81generalconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsphone81generalconfigurationDeleteResponse> IntuneDeviceconfigWindowsphone81generalconfigurationDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigWindowsphone81generalconfigurationDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigWindowsphone81generalconfigurationDeleteParameter, IntuneDeviceconfigWindowsphone81generalconfigurationDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsphone81generalconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsphone81generalconfigurationDeleteResponse> IntuneDeviceconfigWindowsphone81generalconfigurationDeleteAsync(IntuneDeviceconfigWindowsphone81generalconfigurationDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigWindowsphone81generalconfigurationDeleteParameter, IntuneDeviceconfigWindowsphone81generalconfigurationDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsphone81generalconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsphone81generalconfigurationDeleteResponse> IntuneDeviceconfigWindowsphone81generalconfigurationDeleteAsync(IntuneDeviceconfigWindowsphone81generalconfigurationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigWindowsphone81generalconfigurationDeleteParameter, IntuneDeviceconfigWindowsphone81generalconfigurationDeleteResponse>(parameter, cancellationToken);
        }
    }
}
