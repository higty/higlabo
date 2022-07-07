using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigMacosgeneraldeviceconfigurationDeleteParameter : IRestApiParameter
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
    public partial class IntuneDeviceconfigMacosgeneraldeviceconfigurationDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-macosgeneraldeviceconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigMacosgeneraldeviceconfigurationDeleteResponse> IntuneDeviceconfigMacosgeneraldeviceconfigurationDeleteAsync()
        {
            var p = new IntuneDeviceconfigMacosgeneraldeviceconfigurationDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigMacosgeneraldeviceconfigurationDeleteParameter, IntuneDeviceconfigMacosgeneraldeviceconfigurationDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-macosgeneraldeviceconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigMacosgeneraldeviceconfigurationDeleteResponse> IntuneDeviceconfigMacosgeneraldeviceconfigurationDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigMacosgeneraldeviceconfigurationDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigMacosgeneraldeviceconfigurationDeleteParameter, IntuneDeviceconfigMacosgeneraldeviceconfigurationDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-macosgeneraldeviceconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigMacosgeneraldeviceconfigurationDeleteResponse> IntuneDeviceconfigMacosgeneraldeviceconfigurationDeleteAsync(IntuneDeviceconfigMacosgeneraldeviceconfigurationDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigMacosgeneraldeviceconfigurationDeleteParameter, IntuneDeviceconfigMacosgeneraldeviceconfigurationDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-macosgeneraldeviceconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigMacosgeneraldeviceconfigurationDeleteResponse> IntuneDeviceconfigMacosgeneraldeviceconfigurationDeleteAsync(IntuneDeviceconfigMacosgeneraldeviceconfigurationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigMacosgeneraldeviceconfigurationDeleteParameter, IntuneDeviceconfigMacosgeneraldeviceconfigurationDeleteResponse>(parameter, cancellationToken);
        }
    }
}
