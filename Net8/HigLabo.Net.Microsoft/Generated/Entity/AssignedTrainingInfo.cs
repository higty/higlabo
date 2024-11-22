using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/assignedtraininginfo?view=graph-rest-1.0
/// </summary>
public partial class AssignedTrainingInfo
{
    public Int32? AssignedUserCount { get; set; }
    public Int32? CompletedUserCount { get; set; }
    public string? DisplayName { get; set; }
}
