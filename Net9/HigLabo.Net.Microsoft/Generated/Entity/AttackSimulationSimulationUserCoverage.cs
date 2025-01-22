using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/attacksimulationsimulationusercoverage?view=graph-rest-1.0
/// </summary>
public partial class AttackSimulationSimulationUserCoverage
{
    public AttackSimulationUser? AttackSimulationUser { get; set; }
    public Int32? ClickCount { get; set; }
    public Int32? CompromisedCount { get; set; }
    public DateTimeOffset? LatestSimulationDateTime { get; set; }
    public Int32? SimulationCount { get; set; }
}
