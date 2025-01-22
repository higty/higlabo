using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/grouplifecyclepolicy?view=graph-rest-1.0
/// </summary>
public partial class GroupLifecyclePolicy
{
    public string? AlternateNotificationEmails { get; set; }
    public Int32? GroupLifetimeInDays { get; set; }
    public string? Id { get; set; }
    public string? ManagedGroupTypes { get; set; }
}
