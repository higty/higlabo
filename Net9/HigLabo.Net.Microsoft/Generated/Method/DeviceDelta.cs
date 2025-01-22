using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/device-delta?view=graph-rest-1.0
/// </summary>
public partial class DeviceDeltaParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Devices_Delta: return $"/devices/delta";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Devices_Delta,
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
public partial class DeviceDeltaResponse : RestApiResponse<Device>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/device-delta?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/device-delta?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DeviceDeltaResponse> DeviceDeltaAsync()
    {
        var p = new DeviceDeltaParameter();
        return await this.SendAsync<DeviceDeltaParameter, DeviceDeltaResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/device-delta?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DeviceDeltaResponse> DeviceDeltaAsync(CancellationToken cancellationToken)
    {
        var p = new DeviceDeltaParameter();
        return await this.SendAsync<DeviceDeltaParameter, DeviceDeltaResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/device-delta?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DeviceDeltaResponse> DeviceDeltaAsync(DeviceDeltaParameter parameter)
    {
        return await this.SendAsync<DeviceDeltaParameter, DeviceDeltaResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/device-delta?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DeviceDeltaResponse> DeviceDeltaAsync(DeviceDeltaParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<DeviceDeltaParameter, DeviceDeltaResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/device-delta?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<Device> DeviceDeltaEnumerateAsync(DeviceDeltaParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<DeviceDeltaParameter, DeviceDeltaResponse>(parameter, cancellationToken);
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
