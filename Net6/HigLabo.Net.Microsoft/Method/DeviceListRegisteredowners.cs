using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DeviceListRegisteredownersParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Devices_Id_RegisteredOwners: return $"/devices/{Id}/registeredOwners";
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
            Devices_Id_RegisteredOwners,
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
    public partial class DeviceListRegisteredownersResponse : RestApiResponse
    {
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
