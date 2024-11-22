using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/termcolumn?view=graph-rest-1.0
/// </summary>
public partial class TermColumn
{
    public bool? AllowMultipleValues { get; set; }
    public bool? ShowFullyQualifiedName { get; set; }
    public TermStoreTerm? ParentTerm { get; set; }
    public TermStoreSet? TermSet { get; set; }
}
