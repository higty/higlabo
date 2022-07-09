using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
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
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Devices_Id_RegisteredOwners_ref,
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/device-post-registeredowners?view=graph-rest-1.0
        /// </summary>
        public async Task<DevicePostRegisteredownersResponse> DevicePostRegisteredownersAsync()
        {
            var p = new DevicePostRegisteredownersParameter();
            return await this.SendAsync<DevicePostRegisteredownersParameter, DevicePostRegisteredownersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/device-post-registeredowners?view=graph-rest-1.0
        /// </summary>
        public async Task<DevicePostRegisteredownersResponse> DevicePostRegisteredownersAsync(CancellationToken cancellationToken)
        {
            var p = new DevicePostRegisteredownersParameter();
            return await this.SendAsync<DevicePostRegisteredownersParameter, DevicePostRegisteredownersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/device-post-registeredowners?view=graph-rest-1.0
        /// </summary>
        public async Task<DevicePostRegisteredownersResponse> DevicePostRegisteredownersAsync(DevicePostRegisteredownersParameter parameter)
        {
            return await this.SendAsync<DevicePostRegisteredownersParameter, DevicePostRegisteredownersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/device-post-registeredowners?view=graph-rest-1.0
        /// </summary>
        public async Task<DevicePostRegisteredownersResponse> DevicePostRegisteredownersAsync(DevicePostRegisteredownersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DevicePostRegisteredownersParameter, DevicePostRegisteredownersResponse>(parameter, cancellationToken);
        }
    }
}
