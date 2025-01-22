using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/conditionalaccesssessioncontrols?view=graph-rest-1.0
/// </summary>
public partial class ConditionalAccessSessionControls
{
    public ApplicationEnforcedRestrictionsSessionControl? ApplicationEnforcedRestrictions { get; set; }
    public CloudAppSecuritySessionControl? CloudAppSecurity { get; set; }
    public bool? DisableResilienceDefaults { get; set; }
    public PersistentBrowserSessionControl? PersistentBrowser { get; set; }
    public SignInFrequencySessionControl? SignInFrequency { get; set; }
}
