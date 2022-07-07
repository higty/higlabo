using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DeviceDeleteRegisteredusersParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Devices_Id_RegisteredUsers_Id_ref,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Devices_Id_RegisteredUsers_Id_ref: return $"/devices/{DevicesId}/registeredUsers/{RegisteredUsersId}/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string DevicesId { get; set; }
        public string RegisteredUsersId { get; set; }
    }
    public partial class DeviceDeleteRegisteredusersResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/device-delete-registeredusers?view=graph-rest-1.0
        /// </summary>
        public async Task<DeviceDeleteRegisteredusersResponse> DeviceDeleteRegisteredusersAsync()
        {
            var p = new DeviceDeleteRegisteredusersParameter();
            return await this.SendAsync<DeviceDeleteRegisteredusersParameter, DeviceDeleteRegisteredusersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/device-delete-registeredusers?view=graph-rest-1.0
        /// </summary>
        public async Task<DeviceDeleteRegisteredusersResponse> DeviceDeleteRegisteredusersAsync(CancellationToken cancellationToken)
        {
            var p = new DeviceDeleteRegisteredusersParameter();
            return await this.SendAsync<DeviceDeleteRegisteredusersParameter, DeviceDeleteRegisteredusersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/device-delete-registeredusers?view=graph-rest-1.0
        /// </summary>
        public async Task<DeviceDeleteRegisteredusersResponse> DeviceDeleteRegisteredusersAsync(DeviceDeleteRegisteredusersParameter parameter)
        {
            return await this.SendAsync<DeviceDeleteRegisteredusersParameter, DeviceDeleteRegisteredusersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/device-delete-registeredusers?view=graph-rest-1.0
        /// </summary>
        public async Task<DeviceDeleteRegisteredusersResponse> DeviceDeleteRegisteredusersAsync(DeviceDeleteRegisteredusersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DeviceDeleteRegisteredusersParameter, DeviceDeleteRegisteredusersResponse>(parameter, cancellationToken);
        }
    }
}
