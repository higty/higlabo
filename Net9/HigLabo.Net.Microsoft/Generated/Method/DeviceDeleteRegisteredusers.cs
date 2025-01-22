using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/device-delete-registeredusers?view=graph-rest-1.0
/// </summary>
public partial class DeviceDeleteRegisteredUsersParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? DevicesId { get; set; }
        public string? RegisteredUsersId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Devices_Id_RegisteredUsers_Id_ref: return $"/devices/{DevicesId}/registeredUsers/{RegisteredUsersId}/$ref";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Devices_Id_RegisteredUsers_Id_ref,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "DELETE";
}
public partial class DeviceDeleteRegisteredUsersResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/device-delete-registeredusers?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/device-delete-registeredusers?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DeviceDeleteRegisteredUsersResponse> DeviceDeleteRegisteredUsersAsync()
    {
        var p = new DeviceDeleteRegisteredUsersParameter();
        return await this.SendAsync<DeviceDeleteRegisteredUsersParameter, DeviceDeleteRegisteredUsersResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/device-delete-registeredusers?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DeviceDeleteRegisteredUsersResponse> DeviceDeleteRegisteredUsersAsync(CancellationToken cancellationToken)
    {
        var p = new DeviceDeleteRegisteredUsersParameter();
        return await this.SendAsync<DeviceDeleteRegisteredUsersParameter, DeviceDeleteRegisteredUsersResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/device-delete-registeredusers?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DeviceDeleteRegisteredUsersResponse> DeviceDeleteRegisteredUsersAsync(DeviceDeleteRegisteredUsersParameter parameter)
    {
        return await this.SendAsync<DeviceDeleteRegisteredUsersParameter, DeviceDeleteRegisteredUsersResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/device-delete-registeredusers?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DeviceDeleteRegisteredUsersResponse> DeviceDeleteRegisteredUsersAsync(DeviceDeleteRegisteredUsersParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<DeviceDeleteRegisteredUsersParameter, DeviceDeleteRegisteredUsersResponse>(parameter, cancellationToken);
    }
}
