using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/serviceapp?view=graph-rest-1.0
    /// </summary>
    public partial class ServiceApp
    {
        public enum ServiceAppServiceAppStatus
        {
            Inactive,
            Active,
            PendingActive,
            PendingInactive,
            UnknownFutureValue,
        }

        public Identity? Application { get; set; }
        public DateTimeOffset? EffectiveDateTime { get; set; }
        public string? Id { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DateTimeOffset? RegistrationDateTime { get; set; }
        public ServiceApp? Status { get; set; }
    }
}
