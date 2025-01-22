using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/simulationautomationrun?view=graph-rest-1.0
/// </summary>
public partial class SimulationAutomationRun
{
    public enum SimulationAutomationRunSimulationAutomationRunStatus
    {
        Unknown,
        Running,
        Succeeded,
        Failed,
        Skipped,
        UnknownFutureValue,
    }

    public DateTimeOffset? EndDateTime { get; set; }
    public string? Id { get; set; }
    public string? SimulationId { get; set; }
    public DateTimeOffset? StartDateTime { get; set; }
    public SimulationAutomationRunSimulationAutomationRunStatus Status { get; set; }
}
