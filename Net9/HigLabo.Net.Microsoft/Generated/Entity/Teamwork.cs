using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/teamwork?view=graph-rest-1.0
/// </summary>
public partial class Teamwork
{
    public string? Id { get; set; }
    public bool? IsTeamsEnabled { get; set; }
    public string? Region { get; set; }
    public DeletedTeam[]? DeletedTeams { get; set; }
    public DeletedChat[]? DeletedChats { get; set; }
    public TeamsAppSettings? TeamsAppSettings { get; set; }
}
