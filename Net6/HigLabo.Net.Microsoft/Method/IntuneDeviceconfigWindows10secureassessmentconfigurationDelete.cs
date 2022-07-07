using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigWindows10secureassessmentconfigurationDeleteParameter : IRestApiParameter
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
    public partial class IntuneDeviceconfigWindows10secureassessmentconfigurationDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10secureassessmentconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10secureassessmentconfigurationDeleteResponse> IntuneDeviceconfigWindows10secureassessmentconfigurationDeleteAsync()
        {
            var p = new IntuneDeviceconfigWindows10secureassessmentconfigurationDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigWindows10secureassessmentconfigurationDeleteParameter, IntuneDeviceconfigWindows10secureassessmentconfigurationDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10secureassessmentconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10secureassessmentconfigurationDeleteResponse> IntuneDeviceconfigWindows10secureassessmentconfigurationDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigWindows10secureassessmentconfigurationDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigWindows10secureassessmentconfigurationDeleteParameter, IntuneDeviceconfigWindows10secureassessmentconfigurationDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10secureassessmentconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10secureassessmentconfigurationDeleteResponse> IntuneDeviceconfigWindows10secureassessmentconfigurationDeleteAsync(IntuneDeviceconfigWindows10secureassessmentconfigurationDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigWindows10secureassessmentconfigurationDeleteParameter, IntuneDeviceconfigWindows10secureassessmentconfigurationDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10secureassessmentconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10secureassessmentconfigurationDeleteResponse> IntuneDeviceconfigWindows10secureassessmentconfigurationDeleteAsync(IntuneDeviceconfigWindows10secureassessmentconfigurationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigWindows10secureassessmentconfigurationDeleteParameter, IntuneDeviceconfigWindows10secureassessmentconfigurationDeleteResponse>(parameter, cancellationToken);
        }
    }
}
