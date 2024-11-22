using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/itembody?view=graph-rest-1.0
/// </summary>
public partial class ItemBody
{
    public enum ItemBodyBodyType
    {
        Text,
        Html,
    }

    public string? Content { get; set; }
    public ItemBodyBodyType? ContentType { get; set; }
}
