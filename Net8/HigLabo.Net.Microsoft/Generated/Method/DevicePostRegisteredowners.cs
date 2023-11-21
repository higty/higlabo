using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/device-post-registeredowners?view=graph-rest-1.0
    /// </summary>
    public partial class DevicePostRegisteredownersParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Devices_Id_RegisteredOwners_ref: return $"/devices/{Id}/registeredOwners/$ref";
                    case ApiPath.Devices: return $"/devices";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Devices_Id_RegisteredOwners_ref,
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
    }
    public partial class DevicePostRegisteredownersResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/device-post-registeredowners?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/device-post-registeredowners?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DevicePostRegisteredownersResponse> DevicePostRegisteredownersAsync()
        {
            var p = new DevicePostRegisteredownersParameter();
            return await this.SendAsync<DevicePostRegisteredownersParameter, DevicePostRegisteredownersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/device-post-registeredowners?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DevicePostRegisteredownersResponse> DevicePostRegisteredownersAsync(CancellationToken cancellationToken)
        {
            var p = new DevicePostRegisteredownersParameter();
            return await this.SendAsync<DevicePostRegisteredownersParameter, DevicePostRegisteredownersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/device-post-registeredowners?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DevicePostRegisteredownersResponse> DevicePostRegisteredownersAsync(DevicePostRegisteredownersParameter parameter)
        {
            return await this.SendAsync<DevicePostRegisteredownersParameter, DevicePostRegisteredownersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/device-post-registeredowners?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DevicePostRegisteredownersResponse> DevicePostRegisteredownersAsync(DevicePostRegisteredownersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DevicePostRegisteredownersParameter, DevicePostRegisteredownersResponse>(parameter, cancellationToken);
        }
    }
}
