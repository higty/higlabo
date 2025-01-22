using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/applicationenforcedrestrictionssessioncontrol?view=graph-rest-1.0
/// </summary>
public partial class ApplicationEnforcedRestrictionsSessionControl
{
    public bool? IsEnabled { get; set; }
}
