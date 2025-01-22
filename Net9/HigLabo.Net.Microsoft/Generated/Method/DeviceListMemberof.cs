using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/device-list-memberof?view=graph-rest-1.0
/// </summary>
public partial class DeviceListMemberofParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Devices_Id_MemberOf: return $"/devices/{Id}/memberOf";
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
        Devices_Id_MemberOf,
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
public partial class DeviceListMemberofResponse : RestApiResponse<DirectoryObject>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/device-list-memberof?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/device-list-memberof?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DeviceListMemberofResponse> DeviceListMemberofAsync()
    {
        var p = new DeviceListMemberofParameter();
        return await this.SendAsync<DeviceListMemberofParameter, DeviceListMemberofResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/device-list-memberof?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DeviceListMemberofResponse> DeviceListMemberofAsync(CancellationToken cancellationToken)
    {
        var p = new DeviceListMemberofParameter();
        return await this.SendAsync<DeviceListMemberofParameter, DeviceListMemberofResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/device-list-memberof?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DeviceListMemberofResponse> DeviceListMemberofAsync(DeviceListMemberofParameter parameter)
    {
        return await this.SendAsync<DeviceListMemberofParameter, DeviceListMemberofResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/device-list-memberof?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DeviceListMemberofResponse> DeviceListMemberofAsync(DeviceListMemberofParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<DeviceListMemberofParameter, DeviceListMemberofResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/device-list-memberof?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<DirectoryObject> DeviceListMemberofEnumerateAsync(DeviceListMemberofParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<DeviceListMemberofParameter, DeviceListMemberofResponse>(parameter, cancellationToken);
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
