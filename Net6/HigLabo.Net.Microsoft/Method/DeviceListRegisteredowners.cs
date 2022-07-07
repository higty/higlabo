using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DeviceListRegisteredownersParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Devices_Id_RegisteredOwners,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Devices_Id_RegisteredOwners: return $"/devices/{Id}/registeredOwners";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
        public string Id { get; set; }
    }
    public partial class DeviceListRegisteredownersResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/directoryobject?view=graph-rest-1.0
        /// </summary>
        public partial class DirectoryObject
        {
            public DateTimeOffset? DeletedDateTime { get; set; }
            public string? Id { get; set; }
        }

        public DirectoryObject[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/device-list-registeredowners?view=graph-rest-1.0
        /// </summary>
        public async Task<DeviceListRegisteredownersResponse> DeviceListRegisteredownersAsync()
        {
            var p = new DeviceListRegisteredownersParameter();
            return await this.SendAsync<DeviceListRegisteredownersParameter, DeviceListRegisteredownersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/device-list-registeredowners?view=graph-rest-1.0
        /// </summary>
        public async Task<DeviceListRegisteredownersResponse> DeviceListRegisteredownersAsync(CancellationToken cancellationToken)
        {
            var p = new DeviceListRegisteredownersParameter();
            return await this.SendAsync<DeviceListRegisteredownersParameter, DeviceListRegisteredownersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/device-list-registeredowners?view=graph-rest-1.0
        /// </summary>
        public async Task<DeviceListRegisteredownersResponse> DeviceListRegisteredownersAsync(DeviceListRegisteredownersParameter parameter)
        {
            return await this.SendAsync<DeviceListRegisteredownersParameter, DeviceListRegisteredownersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/device-list-registeredowners?view=graph-rest-1.0
        /// </summary>
        public async Task<DeviceListRegisteredownersResponse> DeviceListRegisteredownersAsync(DeviceListRegisteredownersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DeviceListRegisteredownersParameter, DeviceListRegisteredownersResponse>(parameter, cancellationToken);
        }
    }
}
