using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/device-update?view=graph-rest-1.0
    /// </summary>
    public partial class DeviceUpdateParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public bool? AccountEnabled { get; set; }
        public string? OperatingSystem { get; set; }
        public string? OperatingSystemVersion { get; set; }
        public string? DisplayName { get; set; }
        public bool? IsCompliant { get; set; }
        public bool? IsManaged { get; set; }
    }
    public partial class DeviceUpdateResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/device-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/device-update?view=graph-rest-1.0
        /// </summary>
        public async Task<DeviceUpdateResponse> DeviceUpdateAsync()
        {
            var p = new DeviceUpdateParameter();
            return await this.SendAsync<DeviceUpdateParameter, DeviceUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/device-update?view=graph-rest-1.0
        /// </summary>
        public async Task<DeviceUpdateResponse> DeviceUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new DeviceUpdateParameter();
            return await this.SendAsync<DeviceUpdateParameter, DeviceUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/device-update?view=graph-rest-1.0
        /// </summary>
        public async Task<DeviceUpdateResponse> DeviceUpdateAsync(DeviceUpdateParameter parameter)
        {
            return await this.SendAsync<DeviceUpdateParameter, DeviceUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/device-update?view=graph-rest-1.0
        /// </summary>
        public async Task<DeviceUpdateResponse> DeviceUpdateAsync(DeviceUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DeviceUpdateParameter, DeviceUpdateResponse>(parameter, cancellationToken);
        }
    }
}
