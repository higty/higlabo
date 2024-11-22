using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/restorepointsearchresult?view=graph-rest-1.0
/// </summary>
public partial class ReStorePointSearchResult
{
    public int? ArtifactHitCount { get; set; }
    public ReStorePoint? RestorePoint { get; set; }
}
