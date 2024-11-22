using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/deletedteam?view=graph-rest-1.0
/// </summary>
public partial class DeletedTeam
{
    public string? Id { get; set; }
    public Channel[]? Channels { get; set; }
}
