using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/simulationautomation?view=graph-rest-1.0
/// </summary>
public partial class SimulationAutomation
{
    public enum SimulationAutomationSimulationAutomationStatus
    {
        Unknown,
        Draft,
        NotRunning,
        Running,
        Completed,
        UnknownFutureValue,
    }

    public EmailIdentity? CreatedBy { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? Description { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public EmailIdentity? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedDateTime { get; set; }
    public DateTimeOffset? LastRunDateTime { get; set; }
    public DateTimeOffset? NextRunDateTime { get; set; }
    public SimulationAutomationSimulationAutomationStatus Status { get; set; }
    public SimulationAutomationRun[]? Runs { get; set; }
}
