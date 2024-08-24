using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/granularmailboxrestoreartifact?view=graph-rest-1.0
    /// </summary>
    public partial class GranularMailboxReStoreArtifact
    {
        public enum GranularMailboxReStoreArtifactDestinationType
        {
            New,
            InPlace,
            UnknownFutureValue,
        }

        public int? ArtifactCount { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? CompletionDateTime { get; set; }
        public MailboxReStoreArtifact? DestinationType { get; set; }
        public PublicError? Error { get; set; }
        public string? RestoredFolderId { get; set; }
        public string? RestoredFolderName { get; set; }
        public string? SearchResponseId { get; set; }
        public DateTimeOffset? StartDateTime { get; set; }
        public MailboxReStoreArtifact? Status { get; set; }
        public ReStorePoint? RestorePoint { get; set; }
    }
}
