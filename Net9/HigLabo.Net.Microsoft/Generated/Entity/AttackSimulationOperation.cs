using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/attacksimulationoperation?view=graph-rest-1.0
/// </summary>
public partial class AttackSimulationOperation
{
    public enum AttackSimulationOperationLongRunningOperationStatus
    {
        NotStarted,
        Running,
        Succeeded,
        Failed,
        UnknownFutureValue,
    }
    public enum AttackSimulationOperationAttackSimulationOperationType
    {
        CreateSimulation,
        UpdateSimulation,
        UnknownFutureValue,
    }

    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? Id { get; set; }
    public DateTimeOffset? LastActionDateTime { get; set; }
    public Int32? PercentageCompleted { get; set; }
    public string? ResourceLocation { get; set; }
    public AttackSimulationOperationLongRunningOperationStatus Status { get; set; }
    public string? StatusDetail { get; set; }
    public string? TenantId { get; set; }
    public AttackSimulationOperationAttackSimulationOperationType Type { get; set; }
}
