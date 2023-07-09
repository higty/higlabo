using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/device-delete?view=graph-rest-1.0
    /// </summary>
    public partial class DeviceDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Devices_Id: return $"/devices/{Id}";
                    case ApiPath.Devices: return $"/devices";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Devices_Id,
            Devices,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class DeviceDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/device-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/device-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DeviceDeleteResponse> DeviceDeleteAsync()
        {
            var p = new DeviceDeleteParameter();
            return await this.SendAsync<DeviceDeleteParameter, DeviceDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/device-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DeviceDeleteResponse> DeviceDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new DeviceDeleteParameter();
            return await this.SendAsync<DeviceDeleteParameter, DeviceDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/device-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DeviceDeleteResponse> DeviceDeleteAsync(DeviceDeleteParameter parameter)
        {
            return await this.SendAsync<DeviceDeleteParameter, DeviceDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/device-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DeviceDeleteResponse> DeviceDeleteAsync(DeviceDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DeviceDeleteParameter, DeviceDeleteResponse>(parameter, cancellationToken);
        }
    }
}
