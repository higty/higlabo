using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/accessreviewinactiveusersqueryscope?view=graph-rest-1.0
/// </summary>
public partial class AccessReviewInactiveUsersQueryScope
{
    public string? InactiveDuration { get; set; }
    public string? Query { get; set; }
    public string? QueryRoot { get; set; }
    public string? QueryType { get; set; }
}
