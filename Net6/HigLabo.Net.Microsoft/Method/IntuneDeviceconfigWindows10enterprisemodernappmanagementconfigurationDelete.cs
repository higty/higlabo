using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationDeleteParameter : IRestApiParameter
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
    public partial class IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10enterprisemodernappmanagementconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationDeleteResponse> IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationDeleteAsync()
        {
            var p = new IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationDeleteParameter, IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10enterprisemodernappmanagementconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationDeleteResponse> IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationDeleteParameter, IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10enterprisemodernappmanagementconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationDeleteResponse> IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationDeleteAsync(IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationDeleteParameter, IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10enterprisemodernappmanagementconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationDeleteResponse> IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationDeleteAsync(IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationDeleteParameter, IntuneDeviceconfigWindows10enterprisemodernappmanagementconfigurationDeleteResponse>(parameter, cancellationToken);
        }
    }
}
