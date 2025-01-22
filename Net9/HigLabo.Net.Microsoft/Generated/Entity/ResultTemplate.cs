using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/resulttemplate?view=graph-rest-1.0
/// </summary>
public partial class ResultTemplate
{
    public Json? Body { get; set; }
    public string? DisplayName { get; set; }
    public string? Key { get; set; }
}
