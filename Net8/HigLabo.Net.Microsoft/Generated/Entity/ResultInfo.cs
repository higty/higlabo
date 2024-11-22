using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/resultinfo?view=graph-rest-1.0
/// </summary>
public partial class ResultInfo
{
    public Int32? Code { get; set; }
    public string? Message { get; set; }
    public Int32? Subcode { get; set; }
}
