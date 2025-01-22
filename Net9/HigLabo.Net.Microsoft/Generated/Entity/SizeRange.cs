using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/sizerange?view=graph-rest-1.0
/// </summary>
public partial class SizeRange
{
    public Int32? MaximumSize { get; set; }
    public Int32? MinimumSize { get; set; }
}
