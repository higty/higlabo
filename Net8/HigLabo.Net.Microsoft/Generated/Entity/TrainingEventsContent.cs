using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/trainingeventscontent?view=graph-rest-1.0
/// </summary>
public partial class TrainingEventsContent
{
    public AssignedTrainingInfo[]? AssignedTrainingsInfos { get; set; }
    public Int32? TrainingsAssignedUserCount { get; set; }
}
