using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDevicesDetectedappDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_DetectedApps_DetectedAppId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DetectedApps_DetectedAppId: return $"/deviceManagement/detectedApps/{DetectedAppId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string DetectedAppId { get; set; }
    }
    public partial class IntuneDevicesDetectedappDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-detectedapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesDetectedappDeleteResponse> IntuneDevicesDetectedappDeleteAsync()
        {
            var p = new IntuneDevicesDetectedappDeleteParameter();
            return await this.SendAsync<IntuneDevicesDetectedappDeleteParameter, IntuneDevicesDetectedappDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-detectedapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesDetectedappDeleteResponse> IntuneDevicesDetectedappDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDevicesDetectedappDeleteParameter();
            return await this.SendAsync<IntuneDevicesDetectedappDeleteParameter, IntuneDevicesDetectedappDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-detectedapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesDetectedappDeleteResponse> IntuneDevicesDetectedappDeleteAsync(IntuneDevicesDetectedappDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneDevicesDetectedappDeleteParameter, IntuneDevicesDetectedappDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-detectedapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesDetectedappDeleteResponse> IntuneDevicesDetectedappDeleteAsync(IntuneDevicesDetectedappDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDevicesDetectedappDeleteParameter, IntuneDevicesDetectedappDeleteResponse>(parameter, cancellationToken);
        }
    }
}
