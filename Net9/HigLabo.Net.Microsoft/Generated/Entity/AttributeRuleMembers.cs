using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/attributerulemembers?view=graph-rest-1.0
/// </summary>
public partial class AttributeRuleMembers
{
    public string? Description { get; set; }
    public string? MembershipRule { get; set; }
}
