using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/listitem-post-documentsetversions?view=graph-rest-1.0
/// </summary>
public partial class ListItemPostDocumentsetversionsParameter : IRestApiParameter
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
    string IRestApiParameter.HttpMethod { get; } = "POST";
    public string? Comment { get; set; }
    public bool? ShouldCaptureMinorVersion { get; set; }
    public IdentitySet? CreatedBy { get; set; }
    public DateTime? CreatedDateTime { get; set; }
    public string? Id { get; set; }
    public DocumentSetVersionItem[]? Items { get; set; }
    public IdentitySet? LastModifiedBy { get; set; }
    public TimeStamp? LastModifiedDateTime { get; set; }
    public PublicationFacet? Published { get; set; }
    public FieldValueSet? Fields { get; set; }
}
public partial class ListItemPostDocumentsetversionsResponse : RestApiResponse
{
    public string? Comment { get; set; }
    public IdentitySet? CreatedBy { get; set; }
    public DateTime? CreatedDateTime { get; set; }
    public string? Id { get; set; }
    public DocumentSetVersionItem[]? Items { get; set; }
    public IdentitySet? LastModifiedBy { get; set; }
    public TimeStamp? LastModifiedDateTime { get; set; }
    public PublicationFacet? Published { get; set; }
    public bool? ShouldCaptureMinorVersion { get; set; }
    public FieldValueSet? Fields { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/listitem-post-documentsetversions?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/listitem-post-documentsetversions?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ListItemPostDocumentsetversionsResponse> ListItemPostDocumentsetversionsAsync()
    {
        var p = new ListItemPostDocumentsetversionsParameter();
        return await this.SendAsync<ListItemPostDocumentsetversionsParameter, ListItemPostDocumentsetversionsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/listitem-post-documentsetversions?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ListItemPostDocumentsetversionsResponse> ListItemPostDocumentsetversionsAsync(CancellationToken cancellationToken)
    {
        var p = new ListItemPostDocumentsetversionsParameter();
        return await this.SendAsync<ListItemPostDocumentsetversionsParameter, ListItemPostDocumentsetversionsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/listitem-post-documentsetversions?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ListItemPostDocumentsetversionsResponse> ListItemPostDocumentsetversionsAsync(ListItemPostDocumentsetversionsParameter parameter)
    {
        return await this.SendAsync<ListItemPostDocumentsetversionsParameter, ListItemPostDocumentsetversionsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/listitem-post-documentsetversions?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ListItemPostDocumentsetversionsResponse> ListItemPostDocumentsetversionsAsync(ListItemPostDocumentsetversionsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ListItemPostDocumentsetversionsParameter, ListItemPostDocumentsetversionsResponse>(parameter, cancellationToken);
    }
}
