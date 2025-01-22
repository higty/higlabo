using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/device-list?view=graph-rest-1.0
/// </summary>
public partial class DeviceListParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
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
public partial class DeviceListResponse : RestApiResponse<Device>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/device-list?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/device-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DeviceListResponse> DeviceListAsync()
    {
        var p = new DeviceListParameter();
        return await this.SendAsync<DeviceListParameter, DeviceListResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/device-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DeviceListResponse> DeviceListAsync(CancellationToken cancellationToken)
    {
        var p = new DeviceListParameter();
        return await this.SendAsync<DeviceListParameter, DeviceListResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/device-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DeviceListResponse> DeviceListAsync(DeviceListParameter parameter)
    {
        return await this.SendAsync<DeviceListParameter, DeviceListResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/device-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DeviceListResponse> DeviceListAsync(DeviceListParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<DeviceListParameter, DeviceListResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/device-list?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<Device> DeviceListEnumerateAsync(DeviceListParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<DeviceListParameter, DeviceListResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<Device>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
