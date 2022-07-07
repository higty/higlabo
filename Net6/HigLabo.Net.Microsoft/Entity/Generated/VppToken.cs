using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-onboarding-vpptoken?view=graph-rest-1.0
    /// </summary>
    public partial class VppToken
    {
        public enum VppTokenVppTokenAccountType
        {
            Business,
            Education,
        }
        public enum VppTokenVppTokenState
        {
            Unknown,
            Valid,
            Expired,
            Invalid,
            AssignedToExternalMDM,
        }
        public enum VppTokenVppTokenSyncStatus
        {
            None,
            InProgress,
            Completed,
            Failed,
        }

        public string? Id { get; set; }
        public string? OrganizationName { get; set; }
        public VppTokenAccountType? VppTokenAccountType { get; set; }
        public string? AppleId { get; set; }
        public DateTimeOffset? ExpirationDateTime { get; set; }
        public DateTimeOffset? LastSyncDateTime { get; set; }
        public string? Token { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public VppTokenState? State { get; set; }
        public VppTokenSyncStatus? LastSyncStatus { get; set; }
        public bool? AutomaticallyUpdateApps { get; set; }
        public string? CountryOrRegion { get; set; }
    }
}
