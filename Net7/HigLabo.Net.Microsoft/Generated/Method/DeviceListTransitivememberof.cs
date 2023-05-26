using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/device-list-transitivememberof?view=graph-rest-1.0
    /// </summary>
    public partial class DeviceListTransitivememberofParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Devices_IdOrUserPrincipalName_TransitiveMemberOf: return $"/devices/{IdOrUserPrincipalName}/transitiveMemberOf";
                    case ApiPath.Devices: return $"/devices";
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
            Devices_IdOrUserPrincipalName_TransitiveMemberOf,
            Devices,
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
    public partial class DeviceListTransitivememberofResponse : RestApiResponse
    {
        public DirectoryObject[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/device-list-transitivememberof?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/device-list-transitivememberof?view=graph-rest-1.0
        /// </summary>
        public async Task<DeviceListTransitivememberofResponse> DeviceListTransitivememberofAsync()
        {
            var p = new DeviceListTransitivememberofParameter();
            return await this.SendAsync<DeviceListTransitivememberofParameter, DeviceListTransitivememberofResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/device-list-transitivememberof?view=graph-rest-1.0
        /// </summary>
        public async Task<DeviceListTransitivememberofResponse> DeviceListTransitivememberofAsync(CancellationToken cancellationToken)
        {
            var p = new DeviceListTransitivememberofParameter();
            return await this.SendAsync<DeviceListTransitivememberofParameter, DeviceListTransitivememberofResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/device-list-transitivememberof?view=graph-rest-1.0
        /// </summary>
        public async Task<DeviceListTransitivememberofResponse> DeviceListTransitivememberofAsync(DeviceListTransitivememberofParameter parameter)
        {
            return await this.SendAsync<DeviceListTransitivememberofParameter, DeviceListTransitivememberofResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/device-list-transitivememberof?view=graph-rest-1.0
        /// </summary>
        public async Task<DeviceListTransitivememberofResponse> DeviceListTransitivememberofAsync(DeviceListTransitivememberofParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DeviceListTransitivememberofParameter, DeviceListTransitivememberofResponse>(parameter, cancellationToken);
        }
    }
}
