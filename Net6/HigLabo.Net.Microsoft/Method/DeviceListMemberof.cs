using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DeviceListMemberofParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Devices_Id_MemberOf,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Devices_Id_MemberOf: return $"/devices/{Id}/memberOf";
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
    public partial class DeviceListMemberofResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/device-list-memberof?view=graph-rest-1.0
        /// </summary>
        public async Task<DeviceListMemberofResponse> DeviceListMemberofAsync()
        {
            var p = new DeviceListMemberofParameter();
            return await this.SendAsync<DeviceListMemberofParameter, DeviceListMemberofResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/device-list-memberof?view=graph-rest-1.0
        /// </summary>
        public async Task<DeviceListMemberofResponse> DeviceListMemberofAsync(CancellationToken cancellationToken)
        {
            var p = new DeviceListMemberofParameter();
            return await this.SendAsync<DeviceListMemberofParameter, DeviceListMemberofResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/device-list-memberof?view=graph-rest-1.0
        /// </summary>
        public async Task<DeviceListMemberofResponse> DeviceListMemberofAsync(DeviceListMemberofParameter parameter)
        {
            return await this.SendAsync<DeviceListMemberofParameter, DeviceListMemberofResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/device-list-memberof?view=graph-rest-1.0
        /// </summary>
        public async Task<DeviceListMemberofResponse> DeviceListMemberofAsync(DeviceListMemberofParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DeviceListMemberofParameter, DeviceListMemberofResponse>(parameter, cancellationToken);
        }
    }
}
