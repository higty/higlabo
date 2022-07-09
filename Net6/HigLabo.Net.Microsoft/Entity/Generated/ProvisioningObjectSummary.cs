using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/provisioningobjectsummary?view=graph-rest-1.0
    /// </summary>
    public partial class ProvisioningObjectSummary
    {
        public enum ProvisioningObjectSummaryProvisioningAction
        {
            Create,
            Update,
            Delete,
            Stageddelete,
            Disable,
            Other,
            UnknownFutureValue,
        }

        public ProvisioningObjectSummaryProvisioningAction ProvisioningAction { get; set; }
        public DateTimeOffset? ActivityDateTime { get; set; }
        public string? ChangeId { get; set; }
        public string? CycleId { get; set; }
        public Int32? DurationInMilliseconds { get; set; }
        public string? Id { get; set; }
        public Initiator? InitiatedBy { get; set; }
        public string? JobId { get; set; }
        public ModifiedProperty[]? ModifiedProperties { get; set; }
        public ProvisioningStep[]? ProvisioningSteps { get; set; }
        public ProvisioningServicePrincipal[]? ServicePrincipal { get; set; }
        public ProvisionedIdentity? SourceIdentity { get; set; }
        public ProvisioningSystem? SourceSystem { get; set; }
        public ProvisioningStatusInfo? ProvisioningStatusInfo { get; set; }
        public ProvisionedIdentity? TargetIdentity { get; set; }
        public ProvisioningSystem? TargetSystem { get; set; }
        public string? TenantId { get; set; }
    }
}
