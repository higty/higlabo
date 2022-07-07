using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigWindows10generalconfigurationDeleteParameter : IRestApiParameter
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
    public partial class IntuneDeviceconfigWindows10generalconfigurationDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10generalconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10generalconfigurationDeleteResponse> IntuneDeviceconfigWindows10generalconfigurationDeleteAsync()
        {
            var p = new IntuneDeviceconfigWindows10generalconfigurationDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigWindows10generalconfigurationDeleteParameter, IntuneDeviceconfigWindows10generalconfigurationDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10generalconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10generalconfigurationDeleteResponse> IntuneDeviceconfigWindows10generalconfigurationDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigWindows10generalconfigurationDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigWindows10generalconfigurationDeleteParameter, IntuneDeviceconfigWindows10generalconfigurationDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10generalconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10generalconfigurationDeleteResponse> IntuneDeviceconfigWindows10generalconfigurationDeleteAsync(IntuneDeviceconfigWindows10generalconfigurationDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigWindows10generalconfigurationDeleteParameter, IntuneDeviceconfigWindows10generalconfigurationDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10generalconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10generalconfigurationDeleteResponse> IntuneDeviceconfigWindows10generalconfigurationDeleteAsync(IntuneDeviceconfigWindows10generalconfigurationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigWindows10generalconfigurationDeleteParameter, IntuneDeviceconfigWindows10generalconfigurationDeleteResponse>(parameter, cancellationToken);
        }
    }
}
