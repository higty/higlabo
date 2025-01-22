using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/list-list-columns?view=graph-rest-1.0
/// </summary>
public partial class ListListColumnsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? SiteId { get; set; }
        public string? ListId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Sites_SiteId_Lists_ListId_Columns: return $"/sites/{SiteId}/lists/{ListId}/columns";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Sites_SiteId_Lists_ListId_Columns,
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
public partial class ListListColumnsResponse : RestApiResponse<ColumnDefinition>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/list-list-columns?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/list-list-columns?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ListListColumnsResponse> ListListColumnsAsync()
    {
        var p = new ListListColumnsParameter();
        return await this.SendAsync<ListListColumnsParameter, ListListColumnsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/list-list-columns?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ListListColumnsResponse> ListListColumnsAsync(CancellationToken cancellationToken)
    {
        var p = new ListListColumnsParameter();
        return await this.SendAsync<ListListColumnsParameter, ListListColumnsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/list-list-columns?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ListListColumnsResponse> ListListColumnsAsync(ListListColumnsParameter parameter)
    {
        return await this.SendAsync<ListListColumnsParameter, ListListColumnsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/list-list-columns?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ListListColumnsResponse> ListListColumnsAsync(ListListColumnsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ListListColumnsParameter, ListListColumnsResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/list-list-columns?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<ColumnDefinition> ListListColumnsEnumerateAsync(ListListColumnsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<ListListColumnsParameter, ListListColumnsResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<ColumnDefinition>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
