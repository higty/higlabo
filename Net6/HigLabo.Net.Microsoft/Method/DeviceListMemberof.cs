using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DeviceListMemberofParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Devices_Id_MemberOf: return $"/devices/{Id}/memberOf";
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
            Devices_Id_MemberOf,
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
    public partial class DeviceListMemberofResponse : RestApiResponse
    {
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
