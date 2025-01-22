using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/group-list-transitivememberof?view=graph-rest-1.0
/// </summary>
public partial class GroupListTransitiveMemberofParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Groups_Id_TransitiveMemberOf: return $"/groups/{Id}/transitiveMemberOf";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Groups_Id_TransitiveMemberOf,
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
public partial class GroupListTransitiveMemberofResponse : RestApiResponse<DirectoryObject>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/group-list-transitivememberof?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-list-transitivememberof?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupListTransitiveMemberofResponse> GroupListTransitiveMemberofAsync()
    {
        var p = new GroupListTransitiveMemberofParameter();
        return await this.SendAsync<GroupListTransitiveMemberofParameter, GroupListTransitiveMemberofResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-list-transitivememberof?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupListTransitiveMemberofResponse> GroupListTransitiveMemberofAsync(CancellationToken cancellationToken)
    {
        var p = new GroupListTransitiveMemberofParameter();
        return await this.SendAsync<GroupListTransitiveMemberofParameter, GroupListTransitiveMemberofResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-list-transitivememberof?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupListTransitiveMemberofResponse> GroupListTransitiveMemberofAsync(GroupListTransitiveMemberofParameter parameter)
    {
        return await this.SendAsync<GroupListTransitiveMemberofParameter, GroupListTransitiveMemberofResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-list-transitivememberof?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupListTransitiveMemberofResponse> GroupListTransitiveMemberofAsync(GroupListTransitiveMemberofParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<GroupListTransitiveMemberofParameter, GroupListTransitiveMemberofResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-list-transitivememberof?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<DirectoryObject> GroupListTransitiveMemberofEnumerateAsync(GroupListTransitiveMemberofParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<GroupListTransitiveMemberofParameter, GroupListTransitiveMemberofResponse>(parameter, cancellationToken);
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
