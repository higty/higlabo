using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/user-list-ownedobjects?view=graph-rest-1.0
/// </summary>
public partial class UserListOwnedObjectsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? IdOrUserPrincipalName { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Me_OwnedObjects: return $"/me/ownedObjects";
                case ApiPath.Users_IdOrUserPrincipalName_OwnedObjects: return $"/users/{IdOrUserPrincipalName}/ownedObjects";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Me_OwnedObjects,
        Users_IdOrUserPrincipalName_OwnedObjects,
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
public partial class UserListOwnedObjectsResponse : RestApiResponse<DirectoryObject>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/user-list-ownedobjects?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-ownedobjects?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UserListOwnedObjectsResponse> UserListOwnedObjectsAsync()
    {
        var p = new UserListOwnedObjectsParameter();
        return await this.SendAsync<UserListOwnedObjectsParameter, UserListOwnedObjectsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-ownedobjects?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UserListOwnedObjectsResponse> UserListOwnedObjectsAsync(CancellationToken cancellationToken)
    {
        var p = new UserListOwnedObjectsParameter();
        return await this.SendAsync<UserListOwnedObjectsParameter, UserListOwnedObjectsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-ownedobjects?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UserListOwnedObjectsResponse> UserListOwnedObjectsAsync(UserListOwnedObjectsParameter parameter)
    {
        return await this.SendAsync<UserListOwnedObjectsParameter, UserListOwnedObjectsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-ownedobjects?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UserListOwnedObjectsResponse> UserListOwnedObjectsAsync(UserListOwnedObjectsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<UserListOwnedObjectsParameter, UserListOwnedObjectsResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-ownedobjects?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<DirectoryObject> UserListOwnedObjectsEnumerateAsync(UserListOwnedObjectsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<UserListOwnedObjectsParameter, UserListOwnedObjectsResponse>(parameter, cancellationToken);
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
