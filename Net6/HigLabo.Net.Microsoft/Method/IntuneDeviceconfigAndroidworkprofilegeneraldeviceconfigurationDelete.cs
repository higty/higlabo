using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigAndroidworkprofilegeneraldeviceconfigurationDeleteParameter : IRestApiParameter
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
    public partial class IntuneDeviceconfigAndroidworkprofilegeneraldeviceconfigurationDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-androidworkprofilegeneraldeviceconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigAndroidworkprofilegeneraldeviceconfigurationDeleteResponse> IntuneDeviceconfigAndroidworkprofilegeneraldeviceconfigurationDeleteAsync()
        {
            var p = new IntuneDeviceconfigAndroidworkprofilegeneraldeviceconfigurationDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigAndroidworkprofilegeneraldeviceconfigurationDeleteParameter, IntuneDeviceconfigAndroidworkprofilegeneraldeviceconfigurationDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-androidworkprofilegeneraldeviceconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigAndroidworkprofilegeneraldeviceconfigurationDeleteResponse> IntuneDeviceconfigAndroidworkprofilegeneraldeviceconfigurationDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigAndroidworkprofilegeneraldeviceconfigurationDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigAndroidworkprofilegeneraldeviceconfigurationDeleteParameter, IntuneDeviceconfigAndroidworkprofilegeneraldeviceconfigurationDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-androidworkprofilegeneraldeviceconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigAndroidworkprofilegeneraldeviceconfigurationDeleteResponse> IntuneDeviceconfigAndroidworkprofilegeneraldeviceconfigurationDeleteAsync(IntuneDeviceconfigAndroidworkprofilegeneraldeviceconfigurationDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigAndroidworkprofilegeneraldeviceconfigurationDeleteParameter, IntuneDeviceconfigAndroidworkprofilegeneraldeviceconfigurationDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-androidworkprofilegeneraldeviceconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigAndroidworkprofilegeneraldeviceconfigurationDeleteResponse> IntuneDeviceconfigAndroidworkprofilegeneraldeviceconfigurationDeleteAsync(IntuneDeviceconfigAndroidworkprofilegeneraldeviceconfigurationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigAndroidworkprofilegeneraldeviceconfigurationDeleteParameter, IntuneDeviceconfigAndroidworkprofilegeneraldeviceconfigurationDeleteResponse>(parameter, cancellationToken);
        }
    }
}
