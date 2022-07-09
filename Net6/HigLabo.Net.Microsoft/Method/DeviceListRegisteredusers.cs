using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DeviceListRegisteredUsersParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Devices_Id_RegisteredUsers: return $"/devices/{Id}/registeredUsers";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            DeletedDateTime,
            Id,
        }
        public enum ApiPath
        {
            Devices_Id_RegisteredUsers,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
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
    }
    public partial class DeviceListRegisteredUsersResponse : RestApiResponse
    {
        public DirectoryObject[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/device-list-registeredusers?view=graph-rest-1.0
        /// </summary>
        public async Task<DeviceListRegisteredUsersResponse> DeviceListRegisteredUsersAsync()
        {
            var p = new DeviceListRegisteredUsersParameter();
            return await this.SendAsync<DeviceListRegisteredUsersParameter, DeviceListRegisteredUsersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/device-list-registeredusers?view=graph-rest-1.0
        /// </summary>
        public async Task<DeviceListRegisteredUsersResponse> DeviceListRegisteredUsersAsync(CancellationToken cancellationToken)
        {
            var p = new DeviceListRegisteredUsersParameter();
            return await this.SendAsync<DeviceListRegisteredUsersParameter, DeviceListRegisteredUsersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/device-list-registeredusers?view=graph-rest-1.0
        /// </summary>
        public async Task<DeviceListRegisteredUsersResponse> DeviceListRegisteredUsersAsync(DeviceListRegisteredUsersParameter parameter)
        {
            return await this.SendAsync<DeviceListRegisteredUsersParameter, DeviceListRegisteredUsersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/device-list-registeredusers?view=graph-rest-1.0
        /// </summary>
        public async Task<DeviceListRegisteredUsersResponse> DeviceListRegisteredUsersAsync(DeviceListRegisteredUsersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DeviceListRegisteredUsersParameter, DeviceListRegisteredUsersResponse>(parameter, cancellationToken);
        }
    }
}
