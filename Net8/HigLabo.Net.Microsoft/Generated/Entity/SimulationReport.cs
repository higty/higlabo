using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/simulationreport?view=graph-rest-1.0
/// </summary>
public partial class SimulationReport
{
    public SimulationReportOverview? Overview { get; set; }
    public UserSimulationDetails[]? SimulationUsers { get; set; }
}
