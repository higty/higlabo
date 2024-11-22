using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/nameditem-list?view=graph-rest-1.0
/// </summary>
public partial class NamedItemListParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }
        public string? ItemPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Me_Drive_Items_Id_Workbook_Names: return $"/me/drive/items/{Id}/workbook/names";
                case ApiPath.Me_Drive_Root_ItemPath_Workbook_Names: return $"/me/drive/root:/{ItemPath}:/workbook/names";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Me_Drive_Items_Id_Workbook_Names,
        Me_Drive_Root_ItemPath_Workbook_Names,
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
public partial class NamedItemListResponse : RestApiResponse<NamedItem>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/nameditem-list?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/nameditem-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<NamedItemListResponse> NamedItemListAsync()
    {
        var p = new NamedItemListParameter();
        return await this.SendAsync<NamedItemListParameter, NamedItemListResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/nameditem-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<NamedItemListResponse> NamedItemListAsync(CancellationToken cancellationToken)
    {
        var p = new NamedItemListParameter();
        return await this.SendAsync<NamedItemListParameter, NamedItemListResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/nameditem-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<NamedItemListResponse> NamedItemListAsync(NamedItemListParameter parameter)
    {
        return await this.SendAsync<NamedItemListParameter, NamedItemListResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/nameditem-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<NamedItemListResponse> NamedItemListAsync(NamedItemListParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<NamedItemListParameter, NamedItemListResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/nameditem-list?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<NamedItem> NamedItemListEnumerateAsync(NamedItemListParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<NamedItemListParameter, NamedItemListResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<NamedItem>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
