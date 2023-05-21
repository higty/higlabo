using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/simulation?view=graph-rest-1.0
    /// </summary>
    public partial class Simulation
    {
        public enum SimulationSimulationAttackTechnique
        {
            Unknown,
            CredentialHarvesting,
            AttachmentMalware,
            DriveByUrl,
            LinkInAttachment,
            LinkToMalwareFile,
            UnknownFutureValue,
        }
        public enum SimulationSimulationAttackType
        {
            Unknown,
            Social,
            Cloud,
            Endpoint,
            UnknownFutureValue,
        }
        public enum SimulationPayloadDeliveryPlatform
        {
            Unknown,
            Sms,
            Email,
            Teams,
            UnknownFutureValue,
        }
        public enum SimulationSimulationStatus
        {
            Unknown,
            Draft,
            Running,
            Scheduled,
            Succeeded,
            Failed,
            Cancelled,
            Excluded,
            UnknownFutureValue,
        }

        public SimulationSimulationAttackTechnique AttackTechnique { get; set; }
        public SimulationSimulationAttackType AttackType { get; set; }
        public string? AutomationId { get; set; }
        public DateTimeOffset? CompletionDateTime { get; set; }
        public EmailIdentity? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public bool? IsAutomated { get; set; }
        public EmailIdentity? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DateTimeOffset? LaunchDateTime { get; set; }
        public SimulationPayloadDeliveryPlatform PayloadDeliveryPlatform { get; set; }
        public SimulationReport? Report { get; set; }
        public SimulationSimulationStatus Status { get; set; }
    }
}
