using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/synchronization-synchronizationjob?view=graph-rest-1.0
/// </summary>
public partial class SynchronizationJob
{
    public string? Id { get; set; }
    public SynchronizationSchedule? Schedule { get; set; }
    public SynchronizationStatus? Status { get; set; }
    public KeyValuePair? SynchronizationJobSettings { get; set; }
    public string? TemplateId { get; set; }
    public BulkUpload? BulkUpload { get; set; }
    public SynchronizationSchema? Schema { get; set; }
}
