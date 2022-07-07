using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigWindows10teamgeneralconfigurationDeleteParameter : IRestApiParameter
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
    public partial class IntuneDeviceconfigWindows10teamgeneralconfigurationDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10teamgeneralconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10teamgeneralconfigurationDeleteResponse> IntuneDeviceconfigWindows10teamgeneralconfigurationDeleteAsync()
        {
            var p = new IntuneDeviceconfigWindows10teamgeneralconfigurationDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigWindows10teamgeneralconfigurationDeleteParameter, IntuneDeviceconfigWindows10teamgeneralconfigurationDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10teamgeneralconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10teamgeneralconfigurationDeleteResponse> IntuneDeviceconfigWindows10teamgeneralconfigurationDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigWindows10teamgeneralconfigurationDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigWindows10teamgeneralconfigurationDeleteParameter, IntuneDeviceconfigWindows10teamgeneralconfigurationDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10teamgeneralconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10teamgeneralconfigurationDeleteResponse> IntuneDeviceconfigWindows10teamgeneralconfigurationDeleteAsync(IntuneDeviceconfigWindows10teamgeneralconfigurationDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigWindows10teamgeneralconfigurationDeleteParameter, IntuneDeviceconfigWindows10teamgeneralconfigurationDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10teamgeneralconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10teamgeneralconfigurationDeleteResponse> IntuneDeviceconfigWindows10teamgeneralconfigurationDeleteAsync(IntuneDeviceconfigWindows10teamgeneralconfigurationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigWindows10teamgeneralconfigurationDeleteParameter, IntuneDeviceconfigWindows10teamgeneralconfigurationDeleteResponse>(parameter, cancellationToken);
        }
    }
}
