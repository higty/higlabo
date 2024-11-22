using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/site?view=graph-rest-1.0
/// </summary>
public partial class Site
{
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? Description { get; set; }
    public string? DisplayName { get; set; }
    public string? ETag { get; set; }
    public string? Id { get; set; }
    public DateTimeOffset? LastModifiedDateTime { get; set; }
    public string? Name { get; set; }
    public Root? Root { get; set; }
    public SharePointIds? SharepointIds { get; set; }
    public SiteCollection[]? SiteCollection { get; set; }
    public string? WebUrl { get; set; }
    public ItemAnalytics? Analytics { get; set; }
    public ColumnDefinition[]? Columns { get; set; }
    public ContentType[]? ContentTypes { get; set; }
    public Drive? Drive { get; set; }
    public Drive[]? Drives { get; set; }
    public BaseItem[]? Items { get; set; }
    public SiteList[]? Lists { get; set; }
    public Onenote? Onenote { get; set; }
    public RichLongRunningOperation[]? Operations { get; set; }
    public Permission[]? Permissions { get; set; }
    public Site[]? Sites { get; set; }
    public TermStoreStore? TermStore { get; set; }
    public TermStoreStore[]? TermStores { get; set; }
}
