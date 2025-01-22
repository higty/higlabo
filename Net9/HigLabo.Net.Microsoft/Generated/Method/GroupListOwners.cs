using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/group-list-owners?view=graph-rest-1.0
/// </summary>
public partial class GroupListOwnersParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Groups_Id_Owners: return $"/groups/{Id}/owners";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Groups_Id_Owners,
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
public partial class GroupListOwnersResponse : RestApiResponse<User>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/group-list-owners?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-list-owners?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupListOwnersResponse> GroupListOwnersAsync()
    {
        var p = new GroupListOwnersParameter();
        return await this.SendAsync<GroupListOwnersParameter, GroupListOwnersResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-list-owners?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupListOwnersResponse> GroupListOwnersAsync(CancellationToken cancellationToken)
    {
        var p = new GroupListOwnersParameter();
        return await this.SendAsync<GroupListOwnersParameter, GroupListOwnersResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-list-owners?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupListOwnersResponse> GroupListOwnersAsync(GroupListOwnersParameter parameter)
    {
        return await this.SendAsync<GroupListOwnersParameter, GroupListOwnersResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-list-owners?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupListOwnersResponse> GroupListOwnersAsync(GroupListOwnersParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<GroupListOwnersParameter, GroupListOwnersResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-list-owners?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<User> GroupListOwnersEnumerateAsync(GroupListOwnersParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<GroupListOwnersParameter, GroupListOwnersResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<User>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
