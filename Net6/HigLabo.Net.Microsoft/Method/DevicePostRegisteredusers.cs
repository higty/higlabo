using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DevicePostRegisteredusersParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Devices_Id_RegisteredUsers_ref,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Devices_Id_RegisteredUsers_ref: return $"/devices/{Id}/registeredUsers/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Id { get; set; }
    }
    public partial class DevicePostRegisteredusersResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/device-post-registeredusers?view=graph-rest-1.0
        /// </summary>
        public async Task<DevicePostRegisteredusersResponse> DevicePostRegisteredusersAsync()
        {
            var p = new DevicePostRegisteredusersParameter();
            return await this.SendAsync<DevicePostRegisteredusersParameter, DevicePostRegisteredusersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/device-post-registeredusers?view=graph-rest-1.0
        /// </summary>
        public async Task<DevicePostRegisteredusersResponse> DevicePostRegisteredusersAsync(CancellationToken cancellationToken)
        {
            var p = new DevicePostRegisteredusersParameter();
            return await this.SendAsync<DevicePostRegisteredusersParameter, DevicePostRegisteredusersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/device-post-registeredusers?view=graph-rest-1.0
        /// </summary>
        public async Task<DevicePostRegisteredusersResponse> DevicePostRegisteredusersAsync(DevicePostRegisteredusersParameter parameter)
        {
            return await this.SendAsync<DevicePostRegisteredusersParameter, DevicePostRegisteredusersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/device-post-registeredusers?view=graph-rest-1.0
        /// </summary>
        public async Task<DevicePostRegisteredusersResponse> DevicePostRegisteredusersAsync(DevicePostRegisteredusersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DevicePostRegisteredusersParameter, DevicePostRegisteredusersResponse>(parameter, cancellationToken);
        }
    }
}
