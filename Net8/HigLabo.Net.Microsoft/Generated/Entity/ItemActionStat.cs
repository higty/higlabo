using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/itemactionstat?view=graph-rest-1.0
/// </summary>
public partial class ItemActionStat
{
    public Int32? ActionCount { get; set; }
    public Int32? ActorCount { get; set; }
}
