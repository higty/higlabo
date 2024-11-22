using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/convertidresult?view=graph-rest-1.0
/// </summary>
public partial class ConvertIdResult
{
    public GenericError? ErrorDetails { get; set; }
    public string? SourceId { get; set; }
    public string? TargetId { get; set; }
}
