using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/usersimulationdetails?view=graph-rest-1.0
/// </summary>
public partial class UserSimulationDetails
{
    public Int32? AssignedTrainingsCount { get; set; }
    public Int32? CompletedTrainingsCount { get; set; }
    public DateTimeOffset? CompromisedDateTime { get; set; }
    public Int32? InProgressTrainingsCount { get; set; }
    public bool? IsCompromised { get; set; }
    public DateTimeOffset? ReportedPhishDateTime { get; set; }
    public UserSimulationEventInfo[]? SimulationEvents { get; set; }
    public AttackSimulationUser? SimulationUser { get; set; }
    public UserTrainingEventInfo[]? TrainingEvents { get; set; }
}
