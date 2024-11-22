using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/device-list-registeredowners?view=graph-rest-1.0
/// </summary>
public partial class DeviceListRegisteredownersParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Devices_Id_RegisteredOwners: return $"/devices/{Id}/registeredOwners";
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
        Devices_Id_RegisteredOwners,
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
public partial class DeviceListRegisteredownersResponse : RestApiResponse<DirectoryObject>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/device-list-registeredowners?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/device-list-registeredowners?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DeviceListRegisteredownersResponse> DeviceListRegisteredownersAsync()
    {
        var p = new DeviceListRegisteredownersParameter();
        return await this.SendAsync<DeviceListRegisteredownersParameter, DeviceListRegisteredownersResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/device-list-registeredowners?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DeviceListRegisteredownersResponse> DeviceListRegisteredownersAsync(CancellationToken cancellationToken)
    {
        var p = new DeviceListRegisteredownersParameter();
        return await this.SendAsync<DeviceListRegisteredownersParameter, DeviceListRegisteredownersResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/device-list-registeredowners?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DeviceListRegisteredownersResponse> DeviceListRegisteredownersAsync(DeviceListRegisteredownersParameter parameter)
    {
        return await this.SendAsync<DeviceListRegisteredownersParameter, DeviceListRegisteredownersResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/device-list-registeredowners?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DeviceListRegisteredownersResponse> DeviceListRegisteredownersAsync(DeviceListRegisteredownersParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<DeviceListRegisteredownersParameter, DeviceListRegisteredownersResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/device-list-registeredowners?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<DirectoryObject> DeviceListRegisteredownersEnumerateAsync(DeviceListRegisteredownersParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<DeviceListRegisteredownersParameter, DeviceListRegisteredownersResponse>(parameter, cancellationToken);
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
