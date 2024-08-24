using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/device-list-transitivememberof?view=graph-rest-1.0
    /// </summary>
    public partial class DeviceListTransitiveMemberofParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class DeviceListTransitiveMemberofResponse : RestApiResponse<DirectoryObject>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/device-list-transitivememberof?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/device-list-transitivememberof?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DeviceListTransitiveMemberofResponse> DeviceListTransitiveMemberofAsync()
        {
            var p = new DeviceListTransitiveMemberofParameter();
            return await this.SendAsync<DeviceListTransitiveMemberofParameter, DeviceListTransitiveMemberofResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/device-list-transitivememberof?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DeviceListTransitiveMemberofResponse> DeviceListTransitiveMemberofAsync(CancellationToken cancellationToken)
        {
            var p = new DeviceListTransitiveMemberofParameter();
            return await this.SendAsync<DeviceListTransitiveMemberofParameter, DeviceListTransitiveMemberofResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/device-list-transitivememberof?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DeviceListTransitiveMemberofResponse> DeviceListTransitiveMemberofAsync(DeviceListTransitiveMemberofParameter parameter)
        {
            return await this.SendAsync<DeviceListTransitiveMemberofParameter, DeviceListTransitiveMemberofResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/device-list-transitivememberof?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DeviceListTransitiveMemberofResponse> DeviceListTransitiveMemberofAsync(DeviceListTransitiveMemberofParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DeviceListTransitiveMemberofParameter, DeviceListTransitiveMemberofResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/device-list-transitivememberof?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<DirectoryObject> DeviceListTransitiveMemberofEnumerateAsync(DeviceListTransitiveMemberofParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<DeviceListTransitiveMemberofParameter, DeviceListTransitiveMemberofResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<DirectoryObject>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
