using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/serviceannouncement?view=graph-rest-1.0
/// </summary>
public partial class ServiceAnnouncement
{
    public ServiceHealth[]? HealthOverviews { get; set; }
    public ServiceHealthIssue[]? Issues { get; set; }
    public ServiceUpdateMessage[]? Messages { get; set; }
}
