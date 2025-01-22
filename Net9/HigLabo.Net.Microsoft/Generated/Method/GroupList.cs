using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/group-list?view=graph-rest-1.0
/// </summary>
public partial class GroupListParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Groups: return $"/groups";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Groups,
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
public partial class GroupListResponse : RestApiResponse<Group>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/group-list?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupListResponse> GroupListAsync()
    {
        var p = new GroupListParameter();
        return await this.SendAsync<GroupListParameter, GroupListResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupListResponse> GroupListAsync(CancellationToken cancellationToken)
    {
        var p = new GroupListParameter();
        return await this.SendAsync<GroupListParameter, GroupListResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupListResponse> GroupListAsync(GroupListParameter parameter)
    {
        return await this.SendAsync<GroupListParameter, GroupListResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupListResponse> GroupListAsync(GroupListParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<GroupListParameter, GroupListResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-list?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<Group> GroupListEnumerateAsync(GroupListParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<GroupListParameter, GroupListResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<Group>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
