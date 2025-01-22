using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/list?view=graph-rest-1.0
/// </summary>
public partial class SiteList
{
    public string? DisplayName { get; set; }
    public ListInfo? List { get; set; }
    public System? System { get; set; }
    public ColumnDefinition[]? Columns { get; set; }
    public ContentType[]? ContentTypes { get; set; }
    public Drive? Drive { get; set; }
    public ListItem[]? Items { get; set; }
    public RichLongRunningOperation[]? Operations { get; set; }
    public Subscription[]? Subscriptions { get; set; }
}
