using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/listitem-list-documentsetversions?view=graph-rest-1.0
/// </summary>
public partial class ListItemListDocumentsetversionsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? SiteId { get; set; }
        public string? ListId { get; set; }
        public string? ItemId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Sites_SiteId_Lists_ListId_Items_ItemId_DocumentSetVersions: return $"/sites/{SiteId}/lists/{ListId}/items/{ItemId}/documentSetVersions";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Sites_SiteId_Lists_ListId_Items_ItemId_DocumentSetVersions,
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
public partial class ListItemListDocumentsetversionsResponse : RestApiResponse<DocumentSetVersion>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/listitem-list-documentsetversions?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/listitem-list-documentsetversions?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ListItemListDocumentsetversionsResponse> ListItemListDocumentsetversionsAsync()
    {
        var p = new ListItemListDocumentsetversionsParameter();
        return await this.SendAsync<ListItemListDocumentsetversionsParameter, ListItemListDocumentsetversionsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/listitem-list-documentsetversions?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ListItemListDocumentsetversionsResponse> ListItemListDocumentsetversionsAsync(CancellationToken cancellationToken)
    {
        var p = new ListItemListDocumentsetversionsParameter();
        return await this.SendAsync<ListItemListDocumentsetversionsParameter, ListItemListDocumentsetversionsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/listitem-list-documentsetversions?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ListItemListDocumentsetversionsResponse> ListItemListDocumentsetversionsAsync(ListItemListDocumentsetversionsParameter parameter)
    {
        return await this.SendAsync<ListItemListDocumentsetversionsParameter, ListItemListDocumentsetversionsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/listitem-list-documentsetversions?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ListItemListDocumentsetversionsResponse> ListItemListDocumentsetversionsAsync(ListItemListDocumentsetversionsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ListItemListDocumentsetversionsParameter, ListItemListDocumentsetversionsResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/listitem-list-documentsetversions?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<DocumentSetVersion> ListItemListDocumentsetversionsEnumerateAsync(ListItemListDocumentsetversionsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<ListItemListDocumentsetversionsParameter, ListItemListDocumentsetversionsResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<DocumentSetVersion>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
