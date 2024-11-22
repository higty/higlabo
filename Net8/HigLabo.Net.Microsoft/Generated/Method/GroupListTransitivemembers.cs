using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/group-list-transitivemembers?view=graph-rest-1.0
/// </summary>
public partial class GroupListTransitiveMembersParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Groups_Id_TransitiveMembers: return $"/groups/{Id}/transitiveMembers";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Groups_Id_TransitiveMembers,
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
public partial class GroupListTransitiveMembersResponse : RestApiResponse<DirectoryObject>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/group-list-transitivemembers?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-list-transitivemembers?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupListTransitiveMembersResponse> GroupListTransitiveMembersAsync()
    {
        var p = new GroupListTransitiveMembersParameter();
        return await this.SendAsync<GroupListTransitiveMembersParameter, GroupListTransitiveMembersResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-list-transitivemembers?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupListTransitiveMembersResponse> GroupListTransitiveMembersAsync(CancellationToken cancellationToken)
    {
        var p = new GroupListTransitiveMembersParameter();
        return await this.SendAsync<GroupListTransitiveMembersParameter, GroupListTransitiveMembersResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-list-transitivemembers?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupListTransitiveMembersResponse> GroupListTransitiveMembersAsync(GroupListTransitiveMembersParameter parameter)
    {
        return await this.SendAsync<GroupListTransitiveMembersParameter, GroupListTransitiveMembersResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-list-transitivemembers?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupListTransitiveMembersResponse> GroupListTransitiveMembersAsync(GroupListTransitiveMembersParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<GroupListTransitiveMembersParameter, GroupListTransitiveMembersResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-list-transitivemembers?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<DirectoryObject> GroupListTransitiveMembersEnumerateAsync(GroupListTransitiveMembersParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<GroupListTransitiveMembersParameter, GroupListTransitiveMembersResponse>(parameter, cancellationToken);
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
