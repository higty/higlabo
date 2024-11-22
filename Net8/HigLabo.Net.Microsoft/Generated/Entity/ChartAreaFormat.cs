using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/chartareaformat?view=graph-rest-1.0
/// </summary>
public partial class ChartAreaFormat
{
    public ChartFill? Fill { get; set; }
    public ChartFont? Font { get; set; }
}
