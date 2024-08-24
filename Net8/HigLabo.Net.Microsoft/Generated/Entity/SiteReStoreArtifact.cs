using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/siterestoreartifact?view=graph-rest-1.0
    /// </summary>
    public partial class SiteReStoreArtifact
    {
        public enum SiteReStoreArtifactDestinationType
        {
            New,
            InPlace,
            UnknownFutureValue,
        }
        public enum SiteReStoreArtifactArtifactRestoreStatus
        {
            Added,
            Scheduling,
            Scheduled,
            InProgress,
            Succeeded,
            Failed,
            UnknownFutureValue,
        }

        public string? Id { get; set; }
        public DateTimeOffset? CompletionDateTime { get; set; }
        public SiteReStoreArtifact? DestinationType { get; set; }
        public PublicError? Error { get; set; }
        public string? RestoredSiteId { get; set; }
        public string? RestoredSiteName { get; set; }
        public string? RestoredSiteWebUrl { get; set; }
        public DateTimeOffset? StartDateTime { get; set; }
        public SiteReStoreArtifactArtifactRestoreStatus Status { get; set; }
        public ReStorePoint? RestorePoint { get; set; }
    }
}
