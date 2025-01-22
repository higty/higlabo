using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/teamworktagmember?view=graph-rest-1.0
/// </summary>
public partial class TeamworkTagMember
{
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public string? TenantId { get; set; }
    public string? UserId { get; set; }
}
