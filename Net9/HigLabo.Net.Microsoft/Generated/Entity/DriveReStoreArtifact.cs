using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/driverestoreartifact?view=graph-rest-1.0
/// </summary>
public partial class DriveReStoreArtifact
{
    public enum DriveReStoreArtifactDestinationType
    {
        New,
        InPlace,
        UnknownFutureValue,
    }
    public enum DriveReStoreArtifactArtifactRestoreStatus
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
    public DriveReStoreArtifact? DestinationType { get; set; }
    public PublicError? Error { get; set; }
    public string? RestoredSiteId { get; set; }
    public string? RestoredSiteName { get; set; }
    public string? RestoredSiteWebUrl { get; set; }
    public DateTimeOffset? StartDateTime { get; set; }
    public DriveReStoreArtifactArtifactRestoreStatus Status { get; set; }
    public ReStorePoint? RestorePoint { get; set; }
}
