using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/conditionalaccessfilter?view=graph-rest-1.0
/// </summary>
public partial class ConditionalAccessFilter
{
    public enum ConditionalAccessFilterFilterMode
    {
        Include,
        Exclude,
    }

    public ConditionalAccessFilterFilterMode Mode { get; set; }
    public string? Rule { get; set; }
}
