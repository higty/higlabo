using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/formatprotection?view=graph-rest-1.0
/// </summary>
public partial class FormatProtection
{
    public bool? FormulaHidden { get; set; }
    public bool? Locked { get; set; }
}
