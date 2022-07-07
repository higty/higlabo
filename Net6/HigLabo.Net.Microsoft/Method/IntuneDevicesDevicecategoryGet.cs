using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDevicesDevicecategoryGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_DetectedApps_DetectedAppId_ManagedDevices_ManagedDeviceId_DeviceCategory,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DetectedApps_DetectedAppId_ManagedDevices_ManagedDeviceId_DeviceCategory: return $"/deviceManagement/detectedApps/{DetectedAppId}/managedDevices/{ManagedDeviceId}/deviceCategory";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string DetectedAppId { get; set; }
        public string ManagedDeviceId { get; set; }
    }
    public partial class IntuneDevicesDevicecategoryGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-devicecategory-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesDevicecategoryGetResponse> IntuneDevicesDevicecategoryGetAsync()
        {
            var p = new IntuneDevicesDevicecategoryGetParameter();
            return await this.SendAsync<IntuneDevicesDevicecategoryGetParameter, IntuneDevicesDevicecategoryGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-devicecategory-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesDevicecategoryGetResponse> IntuneDevicesDevicecategoryGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDevicesDevicecategoryGetParameter();
            return await this.SendAsync<IntuneDevicesDevicecategoryGetParameter, IntuneDevicesDevicecategoryGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-devicecategory-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesDevicecategoryGetResponse> IntuneDevicesDevicecategoryGetAsync(IntuneDevicesDevicecategoryGetParameter parameter)
        {
            return await this.SendAsync<IntuneDevicesDevicecategoryGetParameter, IntuneDevicesDevicecategoryGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-devicecategory-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesDevicecategoryGetResponse> IntuneDevicesDevicecategoryGetAsync(IntuneDevicesDevicecategoryGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDevicesDevicecategoryGetParameter, IntuneDevicesDevicecategoryGetResponse>(parameter, cancellationToken);
        }
    }
}
