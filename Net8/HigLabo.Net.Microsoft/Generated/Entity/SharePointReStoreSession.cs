using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/sharepointrestoresession?view=graph-rest-1.0
    /// </summary>
    public partial class SharePointReStoreSession
    {
        public enum SharePointReStoreSessionRestoreSessionStatus
        {
            Draft,
            Activating,
            Active,
            CompletedWithError,
            Completed,
            UnknownFutureValue,
            Failed,
        }

        public string? Id { get; set; }
        public DateTimeOffset? CompletedDateTime { get; set; }
        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public PublicError? Error { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public SharePointReStoreSession? Status { get; set; }
        public SiteReStoreArtifact[]? SiteRestoreArtifacts { get; set; }
    }
}
