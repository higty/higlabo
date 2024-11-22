using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/changetrackedentity?view=graph-rest-1.0
/// </summary>
public partial class ChangeTrackedEntity
{
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? Id { get; set; }
    public IdentitySet? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedDateTime { get; set; }
}
