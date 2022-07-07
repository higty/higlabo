using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigWindowsphone81customconfigurationDeleteParameter : IRestApiParameter
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
    public partial class IntuneDeviceconfigWindowsphone81customconfigurationDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsphone81customconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsphone81customconfigurationDeleteResponse> IntuneDeviceconfigWindowsphone81customconfigurationDeleteAsync()
        {
            var p = new IntuneDeviceconfigWindowsphone81customconfigurationDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigWindowsphone81customconfigurationDeleteParameter, IntuneDeviceconfigWindowsphone81customconfigurationDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsphone81customconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsphone81customconfigurationDeleteResponse> IntuneDeviceconfigWindowsphone81customconfigurationDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigWindowsphone81customconfigurationDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigWindowsphone81customconfigurationDeleteParameter, IntuneDeviceconfigWindowsphone81customconfigurationDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsphone81customconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsphone81customconfigurationDeleteResponse> IntuneDeviceconfigWindowsphone81customconfigurationDeleteAsync(IntuneDeviceconfigWindowsphone81customconfigurationDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigWindowsphone81customconfigurationDeleteParameter, IntuneDeviceconfigWindowsphone81customconfigurationDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsphone81customconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsphone81customconfigurationDeleteResponse> IntuneDeviceconfigWindowsphone81customconfigurationDeleteAsync(IntuneDeviceconfigWindowsphone81customconfigurationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigWindowsphone81customconfigurationDeleteParameter, IntuneDeviceconfigWindowsphone81customconfigurationDeleteResponse>(parameter, cancellationToken);
        }
    }
}
