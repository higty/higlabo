using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigAndroidgeneraldeviceconfigurationDeleteParameter : IRestApiParameter
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
    public partial class IntuneDeviceconfigAndroidgeneraldeviceconfigurationDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-androidgeneraldeviceconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigAndroidgeneraldeviceconfigurationDeleteResponse> IntuneDeviceconfigAndroidgeneraldeviceconfigurationDeleteAsync()
        {
            var p = new IntuneDeviceconfigAndroidgeneraldeviceconfigurationDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigAndroidgeneraldeviceconfigurationDeleteParameter, IntuneDeviceconfigAndroidgeneraldeviceconfigurationDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-androidgeneraldeviceconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigAndroidgeneraldeviceconfigurationDeleteResponse> IntuneDeviceconfigAndroidgeneraldeviceconfigurationDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigAndroidgeneraldeviceconfigurationDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigAndroidgeneraldeviceconfigurationDeleteParameter, IntuneDeviceconfigAndroidgeneraldeviceconfigurationDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-androidgeneraldeviceconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigAndroidgeneraldeviceconfigurationDeleteResponse> IntuneDeviceconfigAndroidgeneraldeviceconfigurationDeleteAsync(IntuneDeviceconfigAndroidgeneraldeviceconfigurationDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigAndroidgeneraldeviceconfigurationDeleteParameter, IntuneDeviceconfigAndroidgeneraldeviceconfigurationDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-androidgeneraldeviceconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigAndroidgeneraldeviceconfigurationDeleteResponse> IntuneDeviceconfigAndroidgeneraldeviceconfigurationDeleteAsync(IntuneDeviceconfigAndroidgeneraldeviceconfigurationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigAndroidgeneraldeviceconfigurationDeleteParameter, IntuneDeviceconfigAndroidgeneraldeviceconfigurationDeleteResponse>(parameter, cancellationToken);
        }
    }
}
