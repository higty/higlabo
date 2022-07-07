using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DeviceListTransitivememberofParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Devices_IdOrUserPrincipalName_TransitiveMemberOf,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Devices_IdOrUserPrincipalName_TransitiveMemberOf: return $"/devices/{IdOrUserPrincipalName}/transitiveMemberOf";
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
        public string IdOrUserPrincipalName { get; set; }
    }
    public partial class DeviceListTransitivememberofResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/device-list-transitivememberof?view=graph-rest-1.0
        /// </summary>
        public async Task<DeviceListTransitivememberofResponse> DeviceListTransitivememberofAsync()
        {
            var p = new DeviceListTransitivememberofParameter();
            return await this.SendAsync<DeviceListTransitivememberofParameter, DeviceListTransitivememberofResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/device-list-transitivememberof?view=graph-rest-1.0
        /// </summary>
        public async Task<DeviceListTransitivememberofResponse> DeviceListTransitivememberofAsync(CancellationToken cancellationToken)
        {
            var p = new DeviceListTransitivememberofParameter();
            return await this.SendAsync<DeviceListTransitivememberofParameter, DeviceListTransitivememberofResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/device-list-transitivememberof?view=graph-rest-1.0
        /// </summary>
        public async Task<DeviceListTransitivememberofResponse> DeviceListTransitivememberofAsync(DeviceListTransitivememberofParameter parameter)
        {
            return await this.SendAsync<DeviceListTransitivememberofParameter, DeviceListTransitivememberofResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/device-list-transitivememberof?view=graph-rest-1.0
        /// </summary>
        public async Task<DeviceListTransitivememberofResponse> DeviceListTransitivememberofAsync(DeviceListTransitivememberofParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DeviceListTransitivememberofParameter, DeviceListTransitivememberofResponse>(parameter, cancellationToken);
        }
    }
}
