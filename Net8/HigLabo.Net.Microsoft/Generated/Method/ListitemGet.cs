using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/listitem-get?view=graph-rest-1.0
/// </summary>
public partial class ListItemGetParameter : IRestApiParameter, IQueryParameterProperty
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
                case ApiPath.Sites_SiteId_Lists_ListId_Items_ItemId: return $"/sites/{SiteId}/lists/{ListId}/items/{ItemId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Sites_SiteId_Lists_ListId_Items_ItemId,
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
public partial class ListItemGetResponse : RestApiResponse
{
    public ContentTypeInfo? ContentType { get; set; }
    public ItemActivity[]? Activities { get; set; }
    public ItemAnalytics? Analytics { get; set; }
    public DocumentSetVersion[]? DocumentSetVersions { get; set; }
    public DriveItem? DriveItem { get; set; }
    public FieldValueSet? Fields { get; set; }
    public ListItemVersion[]? Versions { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/listitem-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/listitem-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ListItemGetResponse> ListItemGetAsync()
    {
        var p = new ListItemGetParameter();
        return await this.SendAsync<ListItemGetParameter, ListItemGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/listitem-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ListItemGetResponse> ListItemGetAsync(CancellationToken cancellationToken)
    {
        var p = new ListItemGetParameter();
        return await this.SendAsync<ListItemGetParameter, ListItemGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/listitem-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ListItemGetResponse> ListItemGetAsync(ListItemGetParameter parameter)
    {
        return await this.SendAsync<ListItemGetParameter, ListItemGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/listitem-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ListItemGetResponse> ListItemGetAsync(ListItemGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ListItemGetParameter, ListItemGetResponse>(parameter, cancellationToken);
    }
}
