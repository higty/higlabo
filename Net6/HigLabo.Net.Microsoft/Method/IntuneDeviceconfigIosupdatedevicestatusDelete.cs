using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigIosupdatedevicestatusDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_IosUpdateStatuses_IosUpdateDeviceStatusId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_IosUpdateStatuses_IosUpdateDeviceStatusId: return $"/deviceManagement/iosUpdateStatuses/{IosUpdateDeviceStatusId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string IosUpdateDeviceStatusId { get; set; }
    }
    public partial class IntuneDeviceconfigIosupdatedevicestatusDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-iosupdatedevicestatus-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIosupdatedevicestatusDeleteResponse> IntuneDeviceconfigIosupdatedevicestatusDeleteAsync()
        {
            var p = new IntuneDeviceconfigIosupdatedevicestatusDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigIosupdatedevicestatusDeleteParameter, IntuneDeviceconfigIosupdatedevicestatusDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-iosupdatedevicestatus-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIosupdatedevicestatusDeleteResponse> IntuneDeviceconfigIosupdatedevicestatusDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigIosupdatedevicestatusDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigIosupdatedevicestatusDeleteParameter, IntuneDeviceconfigIosupdatedevicestatusDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-iosupdatedevicestatus-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIosupdatedevicestatusDeleteResponse> IntuneDeviceconfigIosupdatedevicestatusDeleteAsync(IntuneDeviceconfigIosupdatedevicestatusDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigIosupdatedevicestatusDeleteParameter, IntuneDeviceconfigIosupdatedevicestatusDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-iosupdatedevicestatus-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIosupdatedevicestatusDeleteResponse> IntuneDeviceconfigIosupdatedevicestatusDeleteAsync(IntuneDeviceconfigIosupdatedevicestatusDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigIosupdatedevicestatusDeleteParameter, IntuneDeviceconfigIosupdatedevicestatusDeleteResponse>(parameter, cancellationToken);
        }
    }
}
