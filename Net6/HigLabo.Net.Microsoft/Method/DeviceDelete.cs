using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DeviceDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Devices_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Devices_Id: return $"/devices/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string Id { get; set; }
    }
    public partial class DeviceDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/device-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<DeviceDeleteResponse> DeviceDeleteAsync()
        {
            var p = new DeviceDeleteParameter();
            return await this.SendAsync<DeviceDeleteParameter, DeviceDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/device-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<DeviceDeleteResponse> DeviceDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new DeviceDeleteParameter();
            return await this.SendAsync<DeviceDeleteParameter, DeviceDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/device-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<DeviceDeleteResponse> DeviceDeleteAsync(DeviceDeleteParameter parameter)
        {
            return await this.SendAsync<DeviceDeleteParameter, DeviceDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/device-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<DeviceDeleteResponse> DeviceDeleteAsync(DeviceDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DeviceDeleteParameter, DeviceDeleteResponse>(parameter, cancellationToken);
        }
    }
}
