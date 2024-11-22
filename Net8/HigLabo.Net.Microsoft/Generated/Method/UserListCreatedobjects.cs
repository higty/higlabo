using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/user-list-createdobjects?view=graph-rest-1.0
/// </summary>
public partial class UserListCreatedObjectsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? IdOrUserPrincipalName { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Users_IdOrUserPrincipalName_CreatedObjects: return $"/users/{IdOrUserPrincipalName}/createdObjects";
                case ApiPath.Me_CreatedObjects: return $"/me/createdObjects";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Users_IdOrUserPrincipalName_CreatedObjects,
        Me_CreatedObjects,
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
public partial class UserListCreatedObjectsResponse : RestApiResponse<DirectoryObject>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/user-list-createdobjects?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-createdobjects?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UserListCreatedObjectsResponse> UserListCreatedObjectsAsync()
    {
        var p = new UserListCreatedObjectsParameter();
        return await this.SendAsync<UserListCreatedObjectsParameter, UserListCreatedObjectsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-createdobjects?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UserListCreatedObjectsResponse> UserListCreatedObjectsAsync(CancellationToken cancellationToken)
    {
        var p = new UserListCreatedObjectsParameter();
        return await this.SendAsync<UserListCreatedObjectsParameter, UserListCreatedObjectsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-createdobjects?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UserListCreatedObjectsResponse> UserListCreatedObjectsAsync(UserListCreatedObjectsParameter parameter)
    {
        return await this.SendAsync<UserListCreatedObjectsParameter, UserListCreatedObjectsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-createdobjects?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UserListCreatedObjectsResponse> UserListCreatedObjectsAsync(UserListCreatedObjectsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<UserListCreatedObjectsParameter, UserListCreatedObjectsResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-createdobjects?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<DirectoryObject> UserListCreatedObjectsEnumerateAsync(UserListCreatedObjectsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<UserListCreatedObjectsParameter, UserListCreatedObjectsResponse>(parameter, cancellationToken);
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
