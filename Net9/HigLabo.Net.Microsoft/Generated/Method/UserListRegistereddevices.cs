using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/user-list-registereddevices?view=graph-rest-1.0
/// </summary>
public partial class UserListRegistereddevicesParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? IdOrUserPrincipalName { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Me_RegisteredDevices: return $"/me/registeredDevices";
                case ApiPath.Users_IdOrUserPrincipalName_RegisteredDevices: return $"/users/{IdOrUserPrincipalName}/registeredDevices";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Me_RegisteredDevices,
        Users_IdOrUserPrincipalName_RegisteredDevices,
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
public partial class UserListRegistereddevicesResponse : RestApiResponse<DirectoryObject>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/user-list-registereddevices?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-registereddevices?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UserListRegistereddevicesResponse> UserListRegistereddevicesAsync()
    {
        var p = new UserListRegistereddevicesParameter();
        return await this.SendAsync<UserListRegistereddevicesParameter, UserListRegistereddevicesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-registereddevices?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UserListRegistereddevicesResponse> UserListRegistereddevicesAsync(CancellationToken cancellationToken)
    {
        var p = new UserListRegistereddevicesParameter();
        return await this.SendAsync<UserListRegistereddevicesParameter, UserListRegistereddevicesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-registereddevices?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UserListRegistereddevicesResponse> UserListRegistereddevicesAsync(UserListRegistereddevicesParameter parameter)
    {
        return await this.SendAsync<UserListRegistereddevicesParameter, UserListRegistereddevicesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-registereddevices?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UserListRegistereddevicesResponse> UserListRegistereddevicesAsync(UserListRegistereddevicesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<UserListRegistereddevicesParameter, UserListRegistereddevicesResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-registereddevices?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<DirectoryObject> UserListRegistereddevicesEnumerateAsync(UserListRegistereddevicesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<UserListRegistereddevicesParameter, UserListRegistereddevicesResponse>(parameter, cancellationToken);
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
