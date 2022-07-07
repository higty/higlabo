using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigAndroidcustomconfigurationDeleteParameter : IRestApiParameter
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
    public partial class IntuneDeviceconfigAndroidcustomconfigurationDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-androidcustomconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigAndroidcustomconfigurationDeleteResponse> IntuneDeviceconfigAndroidcustomconfigurationDeleteAsync()
        {
            var p = new IntuneDeviceconfigAndroidcustomconfigurationDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigAndroidcustomconfigurationDeleteParameter, IntuneDeviceconfigAndroidcustomconfigurationDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-androidcustomconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigAndroidcustomconfigurationDeleteResponse> IntuneDeviceconfigAndroidcustomconfigurationDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigAndroidcustomconfigurationDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigAndroidcustomconfigurationDeleteParameter, IntuneDeviceconfigAndroidcustomconfigurationDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-androidcustomconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigAndroidcustomconfigurationDeleteResponse> IntuneDeviceconfigAndroidcustomconfigurationDeleteAsync(IntuneDeviceconfigAndroidcustomconfigurationDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigAndroidcustomconfigurationDeleteParameter, IntuneDeviceconfigAndroidcustomconfigurationDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-androidcustomconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigAndroidcustomconfigurationDeleteResponse> IntuneDeviceconfigAndroidcustomconfigurationDeleteAsync(IntuneDeviceconfigAndroidcustomconfigurationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigAndroidcustomconfigurationDeleteParameter, IntuneDeviceconfigAndroidcustomconfigurationDeleteResponse>(parameter, cancellationToken);
        }
    }
}
