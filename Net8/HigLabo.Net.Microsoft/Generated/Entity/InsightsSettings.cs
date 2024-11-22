using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/insightssettings?view=graph-rest-1.0
/// </summary>
public partial class InsightsSettings
{
    public string? DisabledForGroup { get; set; }
    public bool? IsEnabledInOrganization { get; set; }
}
