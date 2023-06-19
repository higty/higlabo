using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/device-delete-registeredowners?view=graph-rest-1.0
    /// </summary>
    public partial class DeviceDeleteRegisteredownersParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? DevicesId { get; set; }
            public string? RegisteredOwnersId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Devices_Id_RegisteredOwners_Id_ref: return $"/devices/{DevicesId}/registeredOwners/{RegisteredOwnersId}/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Devices_Id_RegisteredOwners_Id_ref,
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
    public partial class DeviceDeleteRegisteredownersResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/device-delete-registeredowners?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/device-delete-registeredowners?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DeviceDeleteRegisteredownersResponse> DeviceDeleteRegisteredownersAsync()
        {
            var p = new DeviceDeleteRegisteredownersParameter();
            return await this.SendAsync<DeviceDeleteRegisteredownersParameter, DeviceDeleteRegisteredownersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/device-delete-registeredowners?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DeviceDeleteRegisteredownersResponse> DeviceDeleteRegisteredownersAsync(CancellationToken cancellationToken)
        {
            var p = new DeviceDeleteRegisteredownersParameter();
            return await this.SendAsync<DeviceDeleteRegisteredownersParameter, DeviceDeleteRegisteredownersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/device-delete-registeredowners?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DeviceDeleteRegisteredownersResponse> DeviceDeleteRegisteredownersAsync(DeviceDeleteRegisteredownersParameter parameter)
        {
            return await this.SendAsync<DeviceDeleteRegisteredownersParameter, DeviceDeleteRegisteredownersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/device-delete-registeredowners?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DeviceDeleteRegisteredownersResponse> DeviceDeleteRegisteredownersAsync(DeviceDeleteRegisteredownersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DeviceDeleteRegisteredownersParameter, DeviceDeleteRegisteredownersResponse>(parameter, cancellationToken);
        }
    }
}
