using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DevicePostRegisteredUsersParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Devices_Id_RegisteredUsers_ref: return $"/devices/{Id}/registeredUsers/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Devices_Id_RegisteredUsers_ref,
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
    public partial class DevicePostRegisteredUsersResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/device-post-registeredusers?view=graph-rest-1.0
        /// </summary>
        public async Task<DevicePostRegisteredUsersResponse> DevicePostRegisteredUsersAsync()
        {
            var p = new DevicePostRegisteredUsersParameter();
            return await this.SendAsync<DevicePostRegisteredUsersParameter, DevicePostRegisteredUsersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/device-post-registeredusers?view=graph-rest-1.0
        /// </summary>
        public async Task<DevicePostRegisteredUsersResponse> DevicePostRegisteredUsersAsync(CancellationToken cancellationToken)
        {
            var p = new DevicePostRegisteredUsersParameter();
            return await this.SendAsync<DevicePostRegisteredUsersParameter, DevicePostRegisteredUsersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/device-post-registeredusers?view=graph-rest-1.0
        /// </summary>
        public async Task<DevicePostRegisteredUsersResponse> DevicePostRegisteredUsersAsync(DevicePostRegisteredUsersParameter parameter)
        {
            return await this.SendAsync<DevicePostRegisteredUsersParameter, DevicePostRegisteredUsersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/device-post-registeredusers?view=graph-rest-1.0
        /// </summary>
        public async Task<DevicePostRegisteredUsersResponse> DevicePostRegisteredUsersAsync(DevicePostRegisteredUsersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DevicePostRegisteredUsersParameter, DevicePostRegisteredUsersResponse>(parameter, cancellationToken);
        }
    }
}
