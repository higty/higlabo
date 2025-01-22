using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/group-list-acceptedsenders?view=graph-rest-1.0
/// </summary>
public partial class GroupListAcceptedsendersParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Groups_Id_AcceptedSenders: return $"/groups/{Id}/acceptedSenders";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Groups_Id_AcceptedSenders,
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
public partial class GroupListAcceptedsendersResponse : RestApiResponse<DirectoryObject>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/group-list-acceptedsenders?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-list-acceptedsenders?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupListAcceptedsendersResponse> GroupListAcceptedsendersAsync()
    {
        var p = new GroupListAcceptedsendersParameter();
        return await this.SendAsync<GroupListAcceptedsendersParameter, GroupListAcceptedsendersResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-list-acceptedsenders?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupListAcceptedsendersResponse> GroupListAcceptedsendersAsync(CancellationToken cancellationToken)
    {
        var p = new GroupListAcceptedsendersParameter();
        return await this.SendAsync<GroupListAcceptedsendersParameter, GroupListAcceptedsendersResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-list-acceptedsenders?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupListAcceptedsendersResponse> GroupListAcceptedsendersAsync(GroupListAcceptedsendersParameter parameter)
    {
        return await this.SendAsync<GroupListAcceptedsendersParameter, GroupListAcceptedsendersResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-list-acceptedsenders?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupListAcceptedsendersResponse> GroupListAcceptedsendersAsync(GroupListAcceptedsendersParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<GroupListAcceptedsendersParameter, GroupListAcceptedsendersResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-list-acceptedsenders?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<DirectoryObject> GroupListAcceptedsendersEnumerateAsync(GroupListAcceptedsendersParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<GroupListAcceptedsendersParameter, GroupListAcceptedsendersResponse>(parameter, cancellationToken);
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
