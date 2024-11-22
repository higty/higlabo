using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/teamsummary?view=graph-rest-1.0
/// </summary>
public partial class TeamSummary
{
    public Int32? GuestsCount { get; set; }
    public Int32? MembersCount { get; set; }
    public Int32? OwnersCount { get; set; }
}
