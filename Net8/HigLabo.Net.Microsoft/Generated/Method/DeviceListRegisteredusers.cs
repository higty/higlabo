using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/device-list-registeredusers?view=graph-rest-1.0
/// </summary>
public partial class DeviceListRegisteredUsersParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Devices_Id_RegisteredUsers: return $"/devices/{Id}/registeredUsers";
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
        Devices_Id_RegisteredUsers,
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
public partial class DeviceListRegisteredUsersResponse : RestApiResponse<DirectoryObject>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/device-list-registeredusers?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/device-list-registeredusers?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DeviceListRegisteredUsersResponse> DeviceListRegisteredUsersAsync()
    {
        var p = new DeviceListRegisteredUsersParameter();
        return await this.SendAsync<DeviceListRegisteredUsersParameter, DeviceListRegisteredUsersResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/device-list-registeredusers?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DeviceListRegisteredUsersResponse> DeviceListRegisteredUsersAsync(CancellationToken cancellationToken)
    {
        var p = new DeviceListRegisteredUsersParameter();
        return await this.SendAsync<DeviceListRegisteredUsersParameter, DeviceListRegisteredUsersResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/device-list-registeredusers?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DeviceListRegisteredUsersResponse> DeviceListRegisteredUsersAsync(DeviceListRegisteredUsersParameter parameter)
    {
        return await this.SendAsync<DeviceListRegisteredUsersParameter, DeviceListRegisteredUsersResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/device-list-registeredusers?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DeviceListRegisteredUsersResponse> DeviceListRegisteredUsersAsync(DeviceListRegisteredUsersParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<DeviceListRegisteredUsersParameter, DeviceListRegisteredUsersResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/device-list-registeredusers?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<DirectoryObject> DeviceListRegisteredUsersEnumerateAsync(DeviceListRegisteredUsersParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<DeviceListRegisteredUsersParameter, DeviceListRegisteredUsersResponse>(parameter, cancellationToken);
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
