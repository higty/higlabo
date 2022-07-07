using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigWindows10customconfigurationDeleteParameter : IRestApiParameter
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
    public partial class IntuneDeviceconfigWindows10customconfigurationDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10customconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10customconfigurationDeleteResponse> IntuneDeviceconfigWindows10customconfigurationDeleteAsync()
        {
            var p = new IntuneDeviceconfigWindows10customconfigurationDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigWindows10customconfigurationDeleteParameter, IntuneDeviceconfigWindows10customconfigurationDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10customconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10customconfigurationDeleteResponse> IntuneDeviceconfigWindows10customconfigurationDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigWindows10customconfigurationDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigWindows10customconfigurationDeleteParameter, IntuneDeviceconfigWindows10customconfigurationDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10customconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10customconfigurationDeleteResponse> IntuneDeviceconfigWindows10customconfigurationDeleteAsync(IntuneDeviceconfigWindows10customconfigurationDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigWindows10customconfigurationDeleteParameter, IntuneDeviceconfigWindows10customconfigurationDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10customconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10customconfigurationDeleteResponse> IntuneDeviceconfigWindows10customconfigurationDeleteAsync(IntuneDeviceconfigWindows10customconfigurationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigWindows10customconfigurationDeleteParameter, IntuneDeviceconfigWindows10customconfigurationDeleteResponse>(parameter, cancellationToken);
        }
    }
}
