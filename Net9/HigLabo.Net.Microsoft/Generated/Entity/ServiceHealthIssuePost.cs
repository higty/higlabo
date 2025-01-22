using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/servicehealthissuepost?view=graph-rest-1.0
/// </summary>
public partial class ServiceHealthIssuePost
{
    public enum ServiceHealthIssuePostPostType
    {
        Regular,
        Quick,
        Strategic,
        UnknownFutureValue,
    }

    public DateTimeOffset? CreatedDateTime { get; set; }
    public ItemBody? Description { get; set; }
    public ServiceHealthIssuePostPostType PostType { get; set; }
}
