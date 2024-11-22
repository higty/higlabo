using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/mailboxrestoreartifact?view=graph-rest-1.0
/// </summary>
public partial class MailboxReStoreArtifact
{
    public enum MailboxReStoreArtifactDestinationType
    {
        New,
        InPlace,
        UnknownFutureValue,
    }

    public string? Id { get; set; }
    public DateTimeOffset? CompletionDateTime { get; set; }
    public MailboxReStoreArtifact? DestinationType { get; set; }
    public PublicError? Error { get; set; }
    public string? RestoredFolderId { get; set; }
    public string? RestoredFolderName { get; set; }
    public DateTimeOffset? StartDateTime { get; set; }
    public MailboxReStoreArtifact? Status { get; set; }
    public ReStorePoint? RestorePoint { get; set; }
}
