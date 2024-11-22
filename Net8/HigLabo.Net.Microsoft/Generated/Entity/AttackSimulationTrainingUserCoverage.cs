using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/attacksimulationtrainingusercoverage?view=graph-rest-1.0
/// </summary>
public partial class AttackSimulationTrainingUserCoverage
{
    public AttackSimulationUser? AttackSimulationUser { get; set; }
    public UserTrainingStatusInfo[]? UserTrainings { get; set; }
}
