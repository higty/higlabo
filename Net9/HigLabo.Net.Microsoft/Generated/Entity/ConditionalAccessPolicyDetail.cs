using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/conditionalaccesspolicydetail?view=graph-rest-1.0
/// </summary>
public partial class ConditionalAccessPolicyDetail
{
    public ConditionalAccessConditionSet? Conditions { get; set; }
    public ConditionalAccessGrantControls? GrantControls { get; set; }
    public ConditionalAccessSessionControls? SessionControls { get; set; }
}
