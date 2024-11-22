using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/accessreviewnotificationrecipientqueryscope?view=graph-rest-1.0
/// </summary>
public partial class AccessReviewNotificationRecipientQueryScope
{
    public string? Query { get; set; }
    public string? QueryRoot { get; set; }
    public string? QueryType { get; set; }
}
